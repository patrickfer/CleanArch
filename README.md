# Clean Architecture (.NET 8)

## Overview

This project follows **Clean Architecture** principles to develop a modular, scalable, and maintainable system. It is divided into several layers, each with a specific responsibility, ensuring clear separation of concerns. The project uses **ASP.NET Core Identity** for user authentication and authorization, and **JWT Bearer** tokens for secure communication.

## Project Structure

1. **CleanArch.API**:  
   The main entry point of the application. It exposes the API endpoints, handles requests, and uses **JWT Bearer Authentication** to secure access.  
   - Authentication is implemented using **ASP.NET Core Identity** for login, and tokens are managed through **JWT**.
  
2. **CleanArch.Application**:  
   Contains the application’s business logic and use cases. Follows the **CQRS** (Command Query Responsibility Segregation) pattern, separating command operations (such as creating and updating data) from query operations (reading data).

3. **CleanArch.Domain**:  
   Holds the core business entities and domain logic, independent of external frameworks or technologies.

4. **CleanArch.Domain.Tests**:  
   Includes unit tests for the domain layer. **xUnit** is used for testing to ensure the correctness of business rules and logic.

5. **CleanArch.Infra.Data**:  
   Manages data persistence and integrates with the database. Implements repository and data access patterns.

6. **CleanArch.Infra.IoC**:  
   Handles dependency injection, managing the registration of services and their lifetimes across the application.

7. **CleanArch.WEBUI**:  
   The user interface layer, providing frontend interaction, potentially using MVC or Razor Pages in **ASP.NET Core**.

## Key Features

- **Authentication with JWT Bearer Tokens**:  
  The application uses **JWT Bearer Authentication** to secure API endpoints, with **ASP.NET Core Identity** managing user registration and login.

- **CQRS Pattern**:  
  Implemented in the **Application** layer to separate commands (write operations) from queries (read operations), improving scalability and organization.

- **xUnit for Testing**:  
  Unit tests for the domain and other layers are written using **xUnit**, ensuring that the business logic functions as expected and follows clean architecture principles.

## Technologies Used

- **ASP.NET Core** with **JWT Bearer Authentication**
- **ASP.NET Core Identity** for login and user management
- **CQRS** (Command Query Responsibility Segregation) pattern
- **Entity Framework Core** for data access
- **xUnit** for unit testing
- **Dependency Injection** via the **IoC** container

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/) 

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/patrickfer/cleanarch.git
   cd cleanarch
2. Set up the database:
   - Update the connection string in CleanArch.API and CleanArch.WebUI to point to your PostgreSQL.
   - Apply migrations:
   ```bash
   dotnet ef database update --project CleanArch.Infra.Data
2. Run the API:
   ```bash
    cd CleanArch.API
    dotnet run
