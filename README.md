# 📚 Library Management System (ASP.NET Core)

## 🚀 Features
- 📖 Book management (CRUD)
- 👤 Member/User management
- 🔐 Authentication & Authorization (JWT / ASP.NET Core Identity)
- 🔄 Borrow & return books
- ✅ Input validation (FluentValidation, Data Annotations)
- ⚠️ Global exception handling (Middleware)
- 🗄️ PostgreSQL database integration
- 🐳 Docker support

## 🛠️ Tech Stack
- **Backend:** C#, ASP.NET Core  
- **Security:** JWT, ASP.NET Core Identity  
- **Persistence:** Entity Framework Core  
- **Database:** PostgreSQL  
- **Build Tool:** .NET SDK (CLI)  
- **Containerization:** Docker, Docker Compose  

## 📁 Project Structure
```
LibraryManagement/
│
└── src/
├── LMS.API/ # REST API project
│ ├── Controllers/ # API endpoints
│ │ ├── BookController.cs
│ │ ├── BorrowRecordController.cs
│ │ └── UserController.cs
│ ├── Middleware/ # Exception handling & other middleware
│ │ └── ExceptionHandlingMiddleware.cs
│ └── Properties/ # launchSettings.json
│ └── launchSettings.json
│
├── LMS.Application/ # Business logic
│ ├── DTOs/ # Data Transfer Objects
│ │ ├── Book/
│ │ ├── BorrowRecords/
│ │ └── User/
│ ├── Interfaces/ # Service interfaces
│ ├── Services/ # Business logic implementations
│ └── Common/Exceptions/ # Custom exception classes
│
├── LMS.Domain/ # Entities & repository interfaces
│ ├── Entities/
│ ├── Enums/
│ └── Interfaces/
│
└── LMS.Infrastructure/ # EF Core, repositories & security
├── Data/ # DbContext & EF configurations
├── Migrations/ # EF migrations
├── Repositories/ # Repository implementations
└── Security/ # JWT & password hashing
```

## 🔑 API Overview (Sample Endpoints)
| Method | Endpoint | Description |
|--------|---------|-------------|
| POST   | /api/user/register | Register a new user |
| POST   | /api/user/login    | User login |
| GET    | /api/books         | Get all books |
| POST   | /api/books         | Add a new book |
| PATCH  | /api/books/        | Update book |
| DELETE | /api/books/        | Delete book |
| POST   | /api/borrow-records/ | Borrow a book |
| GET    | /api/borrow-records/ | Borrow record info |
| POST   | /api/borrow-records/return/ | Return a book |

## ⚙️ Configuration
Update your `.env` or `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=lms_db;Username=postgres;Password=your_password"
  },
  "JwtSettings": {
    "Secret": "your_secret_key",
    "ExpiryMinutes": 1440
  }
}
▶️ Running the Project
Option 1: Run locally with .NET
# Clone the repository
git clone https://github.com/your-username/library-management-system-dotnet.git

# Navigate to project
cd LibraryManagement

# Restore dependencies
dotnet restore

# Run the API
dotnet run --project src/LMS.API/LMS.API.csproj
The API will be available at:

http://localhost:5000
Option 2: Run with Docker
# Build and start services using Docker Compose
docker-compose up --build
This will run both the API and PostgreSQL database in Docker containers.

🧪 Testing
You can test the APIs using:

Postman

cURL

🎯 Learning Goals
Building RESTful APIs with ASP.NET Core

Writing clean, maintainable backend code

Implementing authentication & authorization with JWT

Working with relational databases using EF Core & PostgreSQL

Exception handling and validation best practices

Containerizing apps with Docker

📌 Future Improvements
Swagger/OpenAPI documentation

Role-based access control (Admin/User)

Pagination & filtering

More advanced Docker setups

Unit & integration tests

👨‍💻 Author
Owais Al-Hajri
Final-year Software Engineering student
Focused on Backend Development with C# / ASP.NET Core

📄 License
This project is for educational purposes.