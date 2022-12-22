namespace NC1TestTask.Data.Entities.JoiningEntities
{
    /// <summary>
    /// These Objects are used to realize the Many-to-Many relationship between Employees and Programming Language.
    /// </summary>
    public class EmployeeProgLanguage
    {
        /// <summary>
        /// Employee Id. 
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// Refferance to the current Employee.
        /// </summary>
        public Employee Empl { get; set; }

        /// <summary>
        /// Programming Language Id.
        /// </summary>
        public int LenId { get; set; }
        /// <summary>
        /// Refferance to the current Programming Language.
        /// </summary>
        public ProgrammingLanguage PrLanguage { get; set; }
    }
}
