namespace NC1TestTask.Data.Entities;

/// <summary>
/// The object contains information on the department and on which floor it is placed.
/// </summary>
public class Department
{
    /// <summary>
    /// Department Id.
    /// </summary>
    public int DepartmentId { get; set; }
    /// <summary>
    /// Department name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The Floor where the current department is placed.
    /// </summary>
    public int? Floor { get; set; }
    /// <summary>
    /// The List of Employees that belongs to the current department.
    /// </summary>
    public List<Employee>? Employees { get; set; }

}