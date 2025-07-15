// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Form validation enhancement
$(document).ready(function () {
    // Add Bootstrap classes to validation messages
    $('.field-validation-error').addClass('invalid-feedback d-block');
    $('.input-validation-error').addClass('is-invalid');
    
    // Add loading spinner to login form
    $('#loginForm').on('submit', function () {
        var submitBtn = $(this).find('button[type="submit"]');
        submitBtn.prop('disabled', true);
        submitBtn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Logging in...');
    });
    
    // Auto-hide alerts after 5 seconds
    $('.alert').delay(5000).fadeOut('slow');
    
    // Add smooth scrolling to anchor links
    $('a[href*="#"]').on('click', function (e) {
        e.preventDefault();
        $('html, body').animate({
            scrollTop: $($(this).attr('href')).offset().top
        }, 500, 'linear');
    });
});

// Utility functions
function showAlert(message, type = 'info') {
    var alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    $('.container').first().prepend(alertHtml);
}

function confirmLogout() {
    return confirm('Are you sure you want to logout?');
}

// Dashboard functionality
function refreshDashboard() {
    location.reload();
}

// Form helpers
function validateForm(formId) {
    var form = document.getElementById(formId);
    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
    }
    form.classList.add('was-validated');
}
