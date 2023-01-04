using Microsoft.EntityFrameworkCore;
using NC1TestTask.Data.Entities;
using NC1TestTask.Data.EntityConfigurations.JoiningEntitiesConfigurations;
using NC1TestTask.Entities.EntityConfigurations;
using System.Reflection;

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
                modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
                modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
                modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
                modelBuilder.ApplyConfiguration(new EmployeeProgLanguageConfiguration());
            }
        }
    }
}
