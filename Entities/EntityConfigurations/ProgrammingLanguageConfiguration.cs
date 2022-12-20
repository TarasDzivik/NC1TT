using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(pl => pl.Name)
                .HasColumnName("Language")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
