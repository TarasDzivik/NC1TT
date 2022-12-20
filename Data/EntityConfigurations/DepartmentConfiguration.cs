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
        builder.HasKey(d => d.Name);
        builder.Property(d => d.Name)
            .HasColumnName("Department")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(d => d.Floor)
            .HasColumnName("Floor")
            .HasColumnType("smallint") // Used the "smallint" because the floor can have a negative range.
            .IsRequired();

        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(d => d.Id);

    }
}
