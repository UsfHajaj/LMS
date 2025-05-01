# Learning Management System - ASP.NET Core Web API 9.0

A clean and modular **Learning Management System (LMS)** built with **ASP.NET Core 9.0**.  
This backend provides user authentication, course and lesson management, student enrollment, quizzes, assignments, and more.

---

## Features

### Authentication & User Roles
- JWT-based login and registration
- Role-based access (Admin, Instructor, Student)
- Email confirmation and password reset
- Profile update and account security

### Course Management
- Full CRUD for courses
- Course publishing status
- Assign instructors to courses
- Add course details, descriptions, and pricing

### Modules & Lessons
- Add modules per course
- Each module includes multiple lessons
- Lessons contain videos, PDFs, and descriptions

### Student Enrollment & Progress
- Students enroll in published courses
- Track lesson/module completion
- View enrolled courses with progress stats

### Quizzes & Assignments
- Link quizzes and assignments to lessons
- Submit answers and auto-grade quizzes
- Instructor feedback on assignments

### Discussions & Comments
- Course-based discussion threads
- Students and instructors can comment
- Real-time updates via notifications

---

## Project Structure
```
LMS/
├── Controllers/                    # API Controllers (Auth, Courses, Quiz, etc.)
├── Config/                         # Configuration and seeding
│   └── ApplicationDbSeedData.cs   # Seed roles and admin user
├── DTOs/                           # Data Transfer Objects
├── Extensions/                     # AutoMapper & custom extensions
├── Migrations/                     # EF Core migrations
├── Models/                         # Database models
│   ├── Auth/                      # User & roles
│   ├── Courses/                   # Courses, modules, lessons
│   ├── Interaction/              # Quizzes, answers, assignments
│   └── Social/                   # Discussions, comments, notifications
├── Context/                        # ApplicationDbContext
├── Repositories/                  # Data access layer
│   ├── Interfaces/               # Repository interfaces
│   └── Implementations/          # Concrete repository logic
├── Services/                      # Business logic
│   ├── Interfaces/               # Service interfaces
│   └── Implement/                # Service implementations
├── Properties/                    # Project settings
├── LMS.csproj                     # Project file
├── LMS.sln                        # Visual Studio solution
├── Program.cs                     # App entry point
├── appsettings.json               # Main config
├── appsettings.Development.json   # Dev config
├── .gitignore                     # Git ignored files
└── .gitattributes                 # Git settings
```

Technologies Used
ASP.NET Core 9.0

Entity Framework Core

SQL Server

AutoMapper

JWT Authentication

RESTful API design

Swagger (for API testing)


## Getting Started
Follow these steps to run the project locally:

1. Clone the repository
```
   git clone https://github.com/UsfHajaj/LMS.git
   cd LMS
```
2. Update the database
```
dotnet ef database update
```
3. Run the app
```
dotnet run
```
4. Test the API
Open Swagger UI:
```
https://localhost:5001/swagger/index.html
```
