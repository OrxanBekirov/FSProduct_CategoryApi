using FSProduct_CategoryApi.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.Core.Repositories.Concrete.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : class, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfBaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] inculudes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(inculudes);
            return filter == null ? await query.ToListAsync() : await query.Where(filter).ToListAsync();



        }

        public async Task<List<TEntity>> GetAllPaginationAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] inculudes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(inculudes);
            return filter == null ? await query.Skip((page-1)*size).Take(size).ToListAsync() 
                : await query.Skip((page - 1) * size).Take(size).Where(filter).ToListAsync();

        }

        public  async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] inculudes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = GetQuery(inculudes);
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();

        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

        }
        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
