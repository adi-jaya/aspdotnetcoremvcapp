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

## Additional Information
- For more details about ASP.NET Core and Entity Framework Core, refer to the official Microsoft documentation.
- If you encounter any issues, check your environment setup and review the steps above.

Happy coding! 🎉
