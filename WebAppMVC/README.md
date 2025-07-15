# WebApp MVC - Enhanced C# MVC Application

A comprehensive C# MVC web application with authentication, user management, profile features, and file upload capabilities.

## Features

### ✅ Core Features
- **User Authentication** - Login/Logout with cookie-based authentication
- **User Registration** - New user sign-up with validation
- **User Profile Management** - View and edit user profiles
- **Profile Picture Upload** - Upload and manage profile pictures
- **File Upload System** - Upload and manage files with validation
- **SQLite Database** - Lightweight, file-based database
- **Responsive Design** - Bootstrap-based responsive UI

### 🔧 Technical Stack
- **Framework**: ASP.NET Core MVC 8.0
- **Database**: SQLite with Entity Framework Core
- **Authentication**: Cookie-based authentication
- **Frontend**: Bootstrap 5, jQuery, Razor Views
- **Security**: Password hashing with SHA256
- **File Storage**: Local file system storage

## Project Structure

```
WebAppMVC/
├── Controllers/
│   ├── AccountController.cs    # Authentication & registration
│   └── HomeController.cs       # Main application features
├── Models/
│   ├── User.cs                 # User entity
│   ├── LoginViewModel.cs       # Login form model
│   ├── RegisterViewModel.cs    # Registration form model
│   ├── ProfileViewModel.cs     # Profile display model
│   └── UploadedFile.cs         # File upload entity
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml        # Login page
│   │   └── Register.cshtml     # Registration page
│   ├── Home/
│   │   ├── Dashboard.cshtml    # User dashboard
│   │   ├── Profile.cshtml      # User profile page
│   │   ├── Upload.cshtml       # File upload page
│   │   └── MyFiles.cshtml      # File management page
│   └── Shared/
│       └── _Layout.cshtml      # Main layout template
├── Services/
│   ├── IAuthService.cs         # Authentication interface
│   └── AuthService.cs          # Authentication implementation
├── Data/
│   └── ApplicationDbContext.cs # Entity Framework context
└── wwwroot/
    ├── uploads/
    │   ├── profiles/           # Profile pictures
    │   └── files/              # Uploaded files
    └── css/site.css            # Custom styles
```

## Setup Instructions

### 1. Database Setup
The application uses SQLite with automatic database creation and seeding.

### 2. Running the Application
```bash
# Navigate to project directory
cd WebAppMVC

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

### 3. Access the Application
- **Home Page**: http://localhost:5000
- **Login**: http://localhost:5000/Account/Login
- **Register**: http://localhost:5000/Account/Register
- **Dashboard**: http://localhost:5000/Home/Dashboard (requires login)

## Usage Guide

### User Registration
1. Click "Register" in the navigation menu
2. Fill in the registration form:
   - Username (unique)
   - Email (unique)
   - Password (min 6 characters)
   - Confirm password
   - First Name (optional)
   - Last Name (optional)
3. Submit the form to create your account

### User Login
1. Click "Login" in the navigation menu
2. Enter your username and password
3. Click "Login" to access your dashboard

### Profile Management
1. After login, click "Profile" in the navigation menu
2. Update your first name and last name
3. Upload a profile picture (optional)
4. Click "Update Profile" to save changes

### File Upload
1. After login, click "Upload" in the navigation menu
2. Select a file to upload (max 5MB)
3. Supported file types: jpg, jpeg, png, gif, pdf, doc, docx, txt
4. Click "Upload" to save the file

### File Management
1. After login, click "My Files" in the navigation menu
2. View and manage your uploaded files

## Database Configuration

The application uses SQLite with the following configuration:

**Connection String** (in appsettings.json):
```json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=WebAppMVCDb.sqlite"
}
```

## Security Features

- **Password Hashing**: SHA256 with salt
- **Input Validation**: Server-side validation with ModelState
- **CSRF Protection**: Anti-forgery tokens on all forms
- **File Upload Security**: File type and size validation
- **Authentication**: Cookie-based with secure settings

## File Upload Configuration

- **Profile Pictures**: Stored in `wwwroot/uploads/profiles/`
- **Uploaded Files**: Stored in `wwwroot/uploads/files/`
- **Max File Size**: 5MB
- **Allowed Extensions**: .jpg, .jpeg, .png, .gif, .pdf, .doc, .docx, .txt

## Development Notes

### Adding New Features
1. Create new models in the `Models/` folder
2. Update the database context in `Data/ApplicationDbContext.cs`
3. Create new controllers in the `Controllers/` folder
4. Create corresponding views in the `Views/` folder
5. Update navigation in `Views/Shared/_Layout.cshtml`

### Database Migrations
```bash
# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

## Troubleshooting

### Common Issues
1. **Database not found**: The database will be created automatically on first run
2. **File upload errors**: Check file size and type restrictions
3. **Login issues**: Ensure username and password are correct
4. **Profile picture not showing**: Check file permissions in `wwwroot/uploads/`

## Future Enhancements
- Email verification
- Password reset functionality
- File sharing between users
- Admin panel for user management
- Advanced file search and filtering
- User roles and permissions
- API endpoints for mobile apps
