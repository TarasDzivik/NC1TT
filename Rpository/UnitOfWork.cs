using NC1TestTask.Data;
using NC1TestTask.Data.Entities;
using NC1TestTask.IRpository;

namespace NC1TestTask.Rpository
{
    /// <summary>
    /// The Object to register generic repositories relative to a class T.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly AppDbContext _context;
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<Department> _departments;
        private IGenericRepository<ProgrammingLanguage> _progLanguages;
        #endregion
        #region CTOR
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        public IGenericRepository<Employee> Employees => _employees ??=
            new GenericRepository<Employee>(_context);
        public IGenericRepository<Department> Departments => _departments ??=
            new GenericRepository<Department>(_context);
        public IGenericRepository<ProgrammingLanguage> ProgLanguages => _progLanguages ??=
            new GenericRepository<ProgrammingLanguage>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
