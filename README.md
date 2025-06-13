# Create New Project

This guide provides a step-by-step walkthrough for setting up a new ASP.NET Core MVC project, configuring it, and ensuring it's ready for development.

---

## Prerequisites
- **C# Dev Kit for Visual Studio Code**
- **.NET 9 SDK**

---

## Steps

### 1. Create a New ASP.NET Core MVC Project
Run the following command to create a new project:
```bash
dotnet new mvc
```

### 2. Add Assets for Build and Debug
1. Open **Command Palette** in Visual Studio Code.
2. Type `.NET` in the search box.
3. Select **.NET: Generate Assets for Build and Debug**.
   - This will add a `.vscode` folder with `launch.json` and `tasks.json` files.

### 3. Trust the HTTPS Development Certificate
Enable HTTPS for development:
```bash
dotnet dev-certs https --trust
```

### 4. Run the Application
Start the application using:
```bash
dotnet run
```

### 5. Check Installed .NET Tools
To see the globally installed tools:
```bash
dotnet tool list --global
```

### 6. Install Required Tools
Install the necessary CLI tools:
```bash
dotnet tool uninstall --global dotnet-aspnet-codegenerator
```
```bash
dotnet tool install --global dotnet-aspnet-codegenerator
```
```bash
dotnet tool uninstall --global dotnet-ef
```
```bash
dotnet tool install --global dotnet-ef
```

### 7. Set PATH for Tools (macOS/Linux)
Add tools to your `PATH` environment variable:
```bash
export PATH=$HOME/.dotnet/tools:$PATH
```
To remove the path, use:
```bash
export PATH=$(echo $PATH | sed -e "s|$HOME/.dotnet/tools:||" -e "s|:$HOME/.dotnet/tools||" -e "s|$HOME/.dotnet/tools||")
```

### 8. Add NuGet Packages
Install the required packages for Entity Framework Core and scaffolding:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.SQLite
```
```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 9. Configure Connection Strings
Add the connection strings to `appsettings.json`:
```json
{
    "ConnectionStrings": {
        "SqliteConnection": "Data Source=database.db",
        "SqlServerConnection": "Server=localhost;Database=Database;Trusted_Connection=True;MultipleActiveResultSets=true",
        "MySqlConnection": "Server=localhost;Database=database;User=root;Password=;"
    }
}
```

### 10. Scaffold Database Context
Generate database contexts using Entity Framework:
- **SQLite**:
```bash
dotnet ef dbcontext scaffold Name=SqliteConnection Microsoft.EntityFrameworkCore.Sqlite -c DevelopmentDbContext -o Data
```
- **SQL Server**:
```bash
dotnet ef dbcontext scaffold Name=SqlServerConnection Microsoft.EntityFrameworkCore.SqlServer -c ProductionDbContext -o Data
```

### 11. Register Database Context in `Program.cs`
Add the database context to `Program.cs`:
```csharp
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<DevelopmentDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
}
else
{
    builder.Services.AddDbContext<ProductionDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
}
```

---

# Clone Project

## Prerequisites

Ensure the following tools and SDKs are installed on your machine:

* **C# Dev Kit for Visual Studio Code**: Enhances Visual Studio Code with C# support.
* **.NET 9 SDK**: Required for building and running the project.

## Getting Started

### Clone the Repository

Clone the repository to your local machine:

```bash
git clone <repository_url>
```

### Generate Build and Debug Assets

1. Open the project in **Visual Studio Code**.
2. Open **Command Palette** (`Ctrl+Shift+P` or `Cmd+Shift+P` on macOS).
3. Search for `.NET: Generate Assets for Build and Debug` and select it.
4. This will generate a `.vscode` folder with the necessary configuration files (`launch.json`, `tasks.json`).

### Trust the HTTPS Development Certificate

For secure local development with HTTPS:

```bash
dotnet dev-certs https --trust
```

### Restore Dependencies

Install all required packages for the project:

```bash
dotnet restore
```

## Running the Application

To run the application:

```bash
dotnet run
```

## Managing Packages

### List Installed Packages

View all packages installed in the project:

```bash
dotnet list package --project
```

### Add New Packages

Install additional NuGet packages as needed:

```bash
dotnet add package <package_name>
```

## Managing .NET Tools

### Check Installed Tools

View globally installed .NET tools:

```bash
dotnet tool list --global
```

### Install EF Core and ASP.NET Scaffolding Tools

Install or update the following tools for database migrations and scaffolding:

```bash
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator

dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
```

### Configure Tool Path (macOS/Linux Only)

Add the tools to your `PATH`:

```bash
export PATH=$HOME/.dotnet/tools:$PATH
```

## Using Scaffolding Tool

Generate Create, Read, Update, and Delete (CRUD) pages for your models. Example for a `Movie` model:

```bash
dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

## Database Migrations

### Apply Migrations

To ensure your database schema matches the EF Core model, apply migrations:

```bash
dotnet ef database update
```

---

For further assistance, refer to the [Microsoft Documentation](https://learn.microsoft.com/aspnet/core/).


## Additional Information
- For more details about ASP.NET Core and Entity Framework Core, refer to the official Microsoft documentation.
- If you encounter any issues, check your environment setup and review the steps above.

Happy coding! 🎉
