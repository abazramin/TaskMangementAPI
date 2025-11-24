#  Task Management API (Clean Architecture + JWT Authentication)

A modular, scalable **Task Management API** built with **ASP.NET Core**, following the principles of **Clean Architecture**.  
The system supports **User Accounts, Authentication, Role-based Access, and Task Assignment** with a clean separation of concerns.

---

##  Features

 Clean Architecture (Domain, Application, Infrastructure, API)  
 Entity Framework Core with SQL Server  
 JWT Authentication & Authorization  
 Users with Roles (Admin / Member)  
 Tasks assigned to users  
 Status tracking (New, InProgress, Completed)  
 Repository & Service abstraction  
 Fluent Validation (if added)  
 RESTful endpoints  
 Ready for extension & contribution  

---

##  Project Structure

src/
├── Domain
│ ├── Entities
│ ├── Enums
│ └── Interfaces
│
├── Application
│ ├── DTOs
│ ├── Services
│ └── Contracts
│
├── Infrastructure
│ ├── Persistence (DbContext, Migrations)
│ ├── Repositories
│ └── Jwt Services
│
└── API
├── Controllers
├── Auth Endpoints
└── Program.cs / DI setup



---

##  Authentication

The API uses **JWT tokens** for secure access.

###  Register

###  Login

Response includes:
```json
{
  "token": "<jwt_token>",
  "expiresIn": 3600
}
Authorization: Bearer <token>
```
## Tasks Module

POST /api/tasks
Get User Tasks
GET /api/task
Update Status
PUT /api/tasks/{id}/status

## Database Setup

use dotnet ef database update

dotnet ef migrations add InitialCreate

## Running the Project
dotnet run --project src/API

## Using Visual Studio / VS Code

Open solution folder

Select API project as startup

Run

## Requirements

.NET 8 SDK (or version used)

SQL Server / LocalDB

VS Code or Visual Studio


## Roadmap (Planned Enhancements)

 Pagination
 Filtering & Search
 Refresh Tokens
 Email Notifications
 Admin Dashboard (React)
 Docker Support


## Contributing

Contributions are welcome!

Fork the repository

Create a feature branch

Commit changes

Open a Pull Request

## License

This project is released under the MIT License, meaning:

 Free to use
 Free to modify
 Free to distribute


## Support the Project

If you find this useful:

 Star the repository ⭐
 Share it with other developers
 Contribute improvements


## Author

Abazr Amin
.NET Developer — Sudan
Passionate about building practical solutions and open-source tools.
