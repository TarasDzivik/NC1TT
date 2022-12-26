using Microsoft.EntityFrameworkCore;
using NC1TestTask.Data;
using NC1TestTask.IRpository;
using System.Linq.Expressions;

namespace NC1TestTask.Rpository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;
        #endregion
        #region CTOR
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        #endregion
        #region Creating
        public async Task Insert(T entity)
        {
            try
            {
                await _db.AddAsync(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            try
            {
                await _db.AddRangeAsync(entities); 
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Getting
        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {   
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includedProp in includes)
                {
                    query = query.Include(includedProp);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);   
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null)
        {
            try
            {
                IQueryable<T> query = _db;
                if (expression != null)
                {
                    query = query.Where(expression);
                }
                if (includes != null)
                {
                    foreach (var includedProp in includes)
                    {
                        query = query.Include(includedProp);
                    }
                }
                if (orderBy != null)
                {
                    query = orderBy(query);
                }
                return await query.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public Task<IPagedList<Task>> GetPagedList(PaginationParams paginationParams = null, List<string> includes = null)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Updating
        public void Update(T entity)
        {
            try
            {
                _db.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region Deleting
        public async Task Delete(int id)
        {
            try
            {
                var entity = await _db.FindAsync(id);
                _db.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _db.RemoveRange(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
