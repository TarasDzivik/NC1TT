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
            builder.HasKey(pl => pl.PLId);

            builder.Property(pl => pl.Name)
                .HasColumnName("Language")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            #region HasData
            builder.HasData(
                new ProgrammingLanguage
                {
                    PLId = 1,
                    Name = "C#"
                },
                new ProgrammingLanguage
                {
                    PLId = 2,
                    Name = "Java"
                },
                new ProgrammingLanguage
                {
                    PLId = 3,
                    Name = "Pyton"
                },
                new ProgrammingLanguage
                {
                    PLId = 4,
                    Name = "Scala"
                },
                new ProgrammingLanguage
                {
                    PLId = 5,
                    Name = "Java Script"
                },
                new ProgrammingLanguage
                {
                    PLId = 6,
                    Name = "C"
                },
                new ProgrammingLanguage
                {
                    PLId = 7,
                    Name = "C++"
                },
                new ProgrammingLanguage
                {
                    PLId = 8,
                    Name = "PHP"
                },
                new ProgrammingLanguage
                {
                    PLId = 9,
                    Name = "Visual Basic"
                },
                new ProgrammingLanguage
                {
                    PLId = 10,
                    Name = "Swift"
                },
                new ProgrammingLanguage
                {
                    PLId = 11,
                    Name = "NodeJS"
                });
            #endregion
        }
    }
}
