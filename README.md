# Leave Request API
This project is to provide backend ASP.NET Core API for Leave Request App. 
It was created from Visual Studio 2019 using ASP.NET Core 3.1 API project template and EF Core.

## SQL Server database
It is setup to use SQL Express.

  "ConnectionString": {
    "LeaveRequestDB": "server=.\\SQLEXPRESS;database=LeaveRequestDB;Integrated Security=true;"
  },

Please create a database "LeaveRequestDB" on your SQL Express.

## Data migration
The following command will apply migration to the target database.

[Command line]
dotnet ef database update

Alternately you can generate migration script and run on your database.

[Command Line]
dotnet ef migrations script

## Build and Run
dotnet build
dotnet run

## References

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio

https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/?view=aspnetcore-5.0

https://www.learnentityframeworkcore.com/

https://code-maze.com/net-core-web-api-ef-core-code-first/

http://codingsonata.com/build-restful-apis-using-asp-net-core-and-entity-framework-core/
