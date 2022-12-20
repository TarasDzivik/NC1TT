using FluentValidation;
using NC1TestTask.Data.Entities;
using NC1TestTask.Data.Enums;

namespace NC1TestTask.Srvices.Validation
{
    /// <summary>
    /// The object is used to validate entered fields before creating a new item in the database.
    /// </summary>
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        EmployeeValidation()
        {
            RuleFor(e => e.Name).Length(2, 20);
            RuleFor(e => e.Surname).Length(2, 20);
            RuleFor(e => e.Age).InclusiveBetween(18, 99);
            RuleFor(e => e.Gender).IsInEnum<Employee, GenderType>();
        }
    }
}
