# WebApp MVC - ASP.NET Core MVC Application

A modern ASP.NET Core MVC web application with secure authentication, user management, and clean architecture following the MVC pattern.

## Features

- **Secure Authentication**: Cookie-based authentication with login/logout functionality
- **User Management**: Registration and user profile management
- **MVC Architecture**: Clean separation of concerns with Models, Views, and Controllers
- **Entity Framework**: Database integration with Entity Framework Core
- **Responsive Design**: Bootstrap 5 responsive UI
- **Validation**: Client-side and server-side validation
- **Error Handling**: Comprehensive error handling and user feedback

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Language**: C#
- **Database**: SQL Server (LocalDB)
- **Frontend**: Bootstrap 5, jQuery
- **ORM**: Entity Framework Core 8.0
- **Authentication**: ASP.NET Core Identity with Cookie Authentication

## Project Structure

```
WebAppMVC/
├── Controllers/          # MVC Controllers
│   ├── AccountController.cs    # Authentication logic
│   └── HomeController.cs       # Main application pages
├── Models/              # Data models and ViewModels
│   ├── User.cs                # User entity
│   ├── LoginViewModel.cs      # Login form model
│   └── ErrorViewModel.cs      # Error page model
├── Services/            # Business logic services
│   ├── IAuthService.cs        # Authentication interface
│   ├── AuthService.cs         # Authentication implementation
│   └── DatabaseSeeder.cs      # Database seeding utility
├── Data/                # Database context
│   └── ApplicationDbContext.cs
├── Views/               # Razor views
│   ├── Account/              # Authentication views
│   ├── Home/                 # Main application views
│   └── Shared/               # Shared layouts and partials
├── wwwroot/             # Static files
│   ├── css/
│   └── js/
└── Program.cs          # Application entry point
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server LocalDB (comes with Visual Studio)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd WebAppMVC
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database** (if needed)
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   ```
   https://localhost:5001
   ```

### Demo Credentials

The application comes with pre-seeded demo users:

| Username | Password | Role |
|----------|----------|------|
| admin    | admin123 | Admin |
| demo     | password123 | User |
| testuser | password123 | User |

## Usage

### Login Process
1. Navigate to the application homepage
2. Click "Login" in the navigation bar
3. Enter username and password
4. Click "Login" to authenticate

### Features Available
- **Home Page**: Welcome page with feature overview
- **Login Page**: Secure authentication form
- **Dashboard**: Protected area for authenticated users
- **Privacy Policy**: Information about data handling
- **Responsive Design**: Works on desktop, tablet, and mobile

### Navigation
- **Public Pages**: Home, Privacy, Login
- **Protected Pages**: Dashboard (requires authentication)

## Development

### Adding New Features

1. **Models**: Add new models in the `Models/` folder
2. **Controllers**: Create new controllers in the `Controllers/` folder
3. **Views**: Add corresponding views in the `Views/` folder
4. **Services**: Implement business logic in the `Services/` folder

### Database Changes

1. **Add new migrations**
   ```bash
   dotnet ef migrations add [MigrationName]
   ```

2. **Update database**
   ```bash
   dotnet ef database update
   ```

### Configuration

Key configuration files:
- `appsettings.json`: Application settings and connection strings
- `Program.cs`: Service configuration and middleware setup

## Security Features

- **Password Hashing**: SHA256 with salt for secure password storage
- **Cookie Authentication**: Secure HTTP-only cookies
- **Anti-forgery Tokens**: CSRF protection on forms
- **Input Validation**: Client and server-side validation
- **HTTPS**: Enforced in production

## Troubleshooting

### Common Issues

1. **Database Connection Error**
   - Ensure SQL Server LocalDB is installed
   - Check connection string in `appsettings.json`

2. **Login Issues**
   - Verify demo credentials
   - Check if database is seeded

3. **Port Already in Use**
   - Change port in `launchSettings.json`
   - Or use `dotnet run --urls "https://localhost:5002"`

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
