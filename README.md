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
