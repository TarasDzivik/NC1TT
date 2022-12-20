using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Entities.EntityConfigurations
{
    /// <summary>
    /// The obgect using to configure fielsds of the Programming Language Table.
    /// </summary>
    public class ProgrammingLanguageConfiguration :
        IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.Name)
                .HasColumnName("Language")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
