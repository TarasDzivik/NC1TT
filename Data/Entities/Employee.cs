using NC1TestTask.Data.Entities.JoiningEntities;
using NC1TestTask.Data.Enums;

namespace NC1TestTask.Data.Entities;

public class Employee
{
    /// <summary>
    /// The Id of the employee.
    /// </summary>
    public int EmployeeId { get; set; }
    /// <summary>
    /// The first name of the employee.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The second name of the employee.
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Age of the employee.
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// Employee's gender (should be "0" - Femail, "1" - Male or "2" - Other).
    /// </summary>
    public GenderType Gender { get; set; }
    /// <summary>
    /// Foreign key to Department entity.
    /// </summary>
    public int? CurrentDepartmentId { get; set; }
    /// <summary>
    /// Reference to the Department that the employee belongs.
    /// </summary>
    public Department? Department { get; set; }
    /// <summary>
    /// Reference to the programming language the employee works with.
    /// </summary>
    public virtual IList<EmployeeProgLanguage>? EmloyeeProgLanguages { get; set; }
}
