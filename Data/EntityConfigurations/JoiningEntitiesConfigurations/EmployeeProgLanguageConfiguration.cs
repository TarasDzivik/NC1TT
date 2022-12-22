using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC1TestTask.Data.Entities;
using NC1TestTask.Data.Entities.JoiningEntities;

namespace NC1TestTask.Data.EntityConfigurations.JoiningEntitiesConfigurations
{
    public class EmployeeProgLanguageConfiguration : IEntityTypeConfiguration<EmployeeProgLanguage>
    {
        public void Configure(EntityTypeBuilder<EmployeeProgLanguage> builder)
        {
            builder.HasKey(epl => new { epl.EmpId, epl.LenId });

            builder.HasOne<Employee>(epl => epl.Empl)
                .WithMany(e => e.EmloyeeProgLanguages)
                .HasForeignKey(epl => epl.EmpId);

            builder.HasOne<ProgrammingLanguage>(epl => epl.PrLanguage)
                .WithMany(pl => pl.EmployeeProgLanguages)
                .HasForeignKey(epl => epl.LenId);
        }
    }
}
