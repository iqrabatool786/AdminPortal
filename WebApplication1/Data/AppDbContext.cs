using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new Employee { EmployeeId = 2, Username = "employee1", Password = "password1", Role = "Employee" },
                new Employee { EmployeeId = 3, Username = "employee2", Password = "password2", Role = "Employee" },
                new Employee { EmployeeId = 4, Username = "employee3", Password = "password3", Role = "Employee" }
            );
        }
    }
}
