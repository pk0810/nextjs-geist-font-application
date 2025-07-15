using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppMVC.Models;
using WebAppMVC.Services;

namespace WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewData["ReturnUrl"] = model.ReturnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authService.AuthenticateAsync(model.Username, model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            // Create claims for the authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FirstName", user.FirstName ?? string.Empty),
                new Claim("LastName", user.LastName ?? string.Empty)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(1)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if username already exists
            if (await _authService.UsernameExistsAsync(model.Username))
            {
                ModelState.AddModelError(nameof(model.Username), "Username already exists");
                return View(model);
            }

            // Check if email already exists
            if (await _authService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Email already exists");
                return View(model);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true
            };

            var result = await _authService.RegisterAsync(user, model.Password);
            if (result)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return View(model);
        }
    }
}
