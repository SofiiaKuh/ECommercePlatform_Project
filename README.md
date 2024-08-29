# ECommercePlatform_Project
Application Description
The ECommercePlatform is an e-commerce application built using ASP.NET Core and Entity Framework Core. It provides a comprehensive solution for managing a shopping cart, including features such as adding items to the cart, removing items, updating item quantities, and viewing the cart. The application uses an in-memory database for testing purposes and SQL Server for production scenarios.

Features
Cart Management: Users can add items to their cart, remove items, and update item quantities.
Product Management: Basic functionality for product handling (e.g., viewing product details).
User Authentication: Optional integration for user authentication (not covered in the current implementation).
Database Integration: Utilizes EF Core for data access, with support for both in-memory and SQL Server databases.
Instructions
Prerequisites
.NET SDK: Ensure that you have the .NET SDK installed. The application is built with .NET 6.0 or later.
SQL Server: If using SQL Server for production, ensure it is installed and accessible. You can also use the in-memory database for testing.
Getting Started
1. Clone the Repository
bash
git clone https://github.com/yourusername/ECommercePlatform.git
cd ECommercePlatform
2. Restore NuGet Packages
bash
dotnet restore
3. Configure the Database Connection
In-Memory Database: Used for local development and testing.
SQL Server: Update the appsettings.json file with your SQL Server connection string.
Example appsettings.json configuration for SQL Server:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=yourserver;Database=yourdatabase;User Id=yourusername;Password=yourpassword;"
  },
  // Other settings...
}
4. Run Migrations (For SQL Server)
If using SQL Server, apply the migrations to set up the database schema:

bash
dotnet ef database update
5. Run the Application
To start the application, use the following command:

bash
dotnet run
The application will be available at http://localhost:5000 by default.

6. Run Unit Tests
To run the unit tests for the application, use the following command:

bash
dotnet test
Running the Application in Development Mode
For development purposes, you can run the application in debug mode using Visual Studio or any IDE of your choice. Open the solution file ECommercePlatform.sln and start debugging.

Troubleshooting
InvalidOperationException: If you encounter InvalidOperationException related to items not being found, ensure that the data is correctly seeded in the database before running the tests or application.

Database Connection Issues: Verify that the connection string in appsettings.json is correct and that the database server is running.

Contribution
Feel free to contribute to the project by submitting issues or pull requests. Ensure that you follow the coding guidelines and run the tests before submitting.
