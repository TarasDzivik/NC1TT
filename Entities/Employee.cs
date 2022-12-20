namespace NC1TestTask.Entities;

public class Employee
{
    /// <summary>
    /// The Id of the employee.
    /// </summary>
    public long Id { get; set; }
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
    /// Employee's gender (should be Male, Femail or Other).
    /// </summary>
    public string Gender { get; set; }
    /// <summary>
    /// Reference to the Department that the employee belongs.
    /// </summary>
    public Department Department { get; set; }
    /// <summary>
    /// Reference to the programming language the employee works with.
    /// </summary>
    public ProgrammingLanguage ProgrammingLanguage { get; set; }
}
