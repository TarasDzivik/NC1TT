using FluentValidation;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Srvices.Validation
{
    public class DepartmentValidation : AbstractValidator<Department>
    {
        public DepartmentValidation() 
        {
            RuleFor(e => e.Name).Length(2, 40);
            RuleFor(e => e.Floor).InclusiveBetween(-50, 400);
        }
    }
}
