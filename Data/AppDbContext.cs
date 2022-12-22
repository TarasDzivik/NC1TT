using Microsoft.EntityFrameworkCore;
using NC1TestTask.Data.Entities;
using System.Reflection;
using NC1TestTask.Data.DTOs;

namespace NC1TestTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }

        public DbSet<EmployeeDto> EmployeeDto { get; set; }

        public DbSet<ProgrammingLanguageDto> ProgrammingLanguageDto { get; set; }

        public DbSet<DepartmentDto> DepartmentDto { get; set; }
    }
}
