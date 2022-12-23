using FluentValidation;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Srvices.Validation
{
    public class ProgrammingLanguageValidation : AbstractValidator<ProgrammingLanguage>
    {
        public ProgrammingLanguageValidation() 
        {
            RuleFor(e => e.Name).Length(1, 40);
        }
    }
}
