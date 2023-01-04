using NC1TestTask.Data.Entities;

namespace NC1TestTask.IRpository
{
    /// <summary>
    /// The interface going to register for every variation
    /// of the generic repository relative to a class T. 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Generate the table for Employees.
        /// </summary>
        IGenericRepository<Employee> Employees { get; }
        /// <summary>
        /// Generate the table for Departments.
        /// </summary>
        IGenericRepository<Department> Departments { get; }
        /// <summary>
        /// Generatee the table for Programming Languages.
        /// </summary>
        IGenericRepository<ProgrammingLanguage> ProgLanguages { get; }
        Task Save();
    }
}
