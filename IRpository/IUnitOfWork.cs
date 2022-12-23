using NC1TestTask.Data.Entities;

namespace NC1TestTask.IRpository
{
    /// <summary>
    /// The interface going to register for every variation
    /// of the generic repository relative to a class T. 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<ProgrammingLanguage> ProgLanguages { get; }
        Task Save();
    }
}
