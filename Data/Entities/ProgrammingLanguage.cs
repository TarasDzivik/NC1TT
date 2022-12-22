using NC1TestTask.Data.Entities.JoiningEntities;

namespace NC1TestTask.Data.Entities;

/// <summary>
/// The object contains the name of the Programming language.
/// </summary>
public class ProgrammingLanguage
{
    /// <summary>
    /// Programming Language Id.
    /// </summary>
    public int PLId { get; set; }
    /// <summary>
    /// The name of the Programming language.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// THe list of references to Employees that working with this Programming Language
    /// </summary>
    public virtual List<EmployeeProgLanguage> EmployeeProgLanguages { get; set; }
}
