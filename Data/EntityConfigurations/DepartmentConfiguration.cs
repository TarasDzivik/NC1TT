using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Entities.EntityConfigurations;

/// <summary>
/// The obgect using to configure fielsds of the Department Table.
/// </summary>
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.DepartmentId);

        builder.Property(d => d.Name)
            .HasColumnName("Department")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.Floor)
            .HasColumnName("Floor")
            .HasColumnType("smallint");

        builder.HasMany<Employee>(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.CurrentDepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        #region HasData
        builder.HasData(
            new Department
            {
                DepartmentId= 1,
                Name = "Engenering",
                Floor = -1,
            },
            new Department
            {
                DepartmentId= 2,
                Name = "Human Resources",
                Floor = 0
            },
            new Department
            {
                DepartmentId= 3,
                Name = "Design Head",
                Floor = 1
            });
        #endregion
    }
}
