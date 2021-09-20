using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace LeaveRequestAPI.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccrual> EmployeeAccruals { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = "eulee",
                FirstName = "Eugene",
                LastName = "Lee",
                IsSupervisor = false,
                SupervisorId = "nichaud"
            }, new Employee
            {
                EmployeeId = "nichaud",
                FirstName = "Nishchal",
                LastName = "Chaudhary",
                IsSupervisor = true,
                SupervisorId = ""
            });

            modelBuilder.Entity<EmployeeAccrual>().HasData(new EmployeeAccrual
            {
                EmployeeId = "eulee",
                AccrualType = "Vacation",
                Hours = 112.5M
            }, new EmployeeAccrual
            {
                EmployeeId = "eulee",
                AccrualType = "Personal Leave",
                Hours = 36
            }, new EmployeeAccrual
            {
                EmployeeId = "eulee",
                AccrualType = "Sick Leave",
                Hours = 785.8M
            }, new EmployeeAccrual
            {
                EmployeeId = "nichaud",
                AccrualType = "Vacation",
                Hours = 96.4M
            }, new EmployeeAccrual
            {
                EmployeeId = "nichaud",
                AccrualType = "Personal Leave",
                Hours = 42
            }, new EmployeeAccrual
            {
                EmployeeId = "nichaud",
                AccrualType = "Sick Leave",
                Hours = 320.3M
            });
        }
    }
}
