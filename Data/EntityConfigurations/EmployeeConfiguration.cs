using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Entities.EntityConfigurations
{
    /// <summary>
    /// The obgect using to configure fielsds of the Employee Table.
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nVarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Surname)
                .HasColumnName("Surname")
                .HasColumnType("nVarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Age)
                .HasColumnName("Age")
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasColumnName("Gender")
                .HasColumnType("varchar")
                .HasMaxLength(6)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(d => d.Name);

            builder.HasOne(e => e.ProgrammingLanguage)
                .WithOne()
                .HasForeignKey<ProgrammingLanguage>(pl => pl.Id);
        }
    }
}
