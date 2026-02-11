using FSProduct_CategoryApi.Entities;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.Core.Repositories.Abstract
{
    public interface IBaseRepository<TEntity>
        where TEntity : class,new()
        
    {
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] inculudes);

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] inculudes);
        public Task<List<TEntity>> GetAllPaginationAsync(int page,int size,Expression<Func<TEntity, bool>> filter = null,params string[] inculudes);


        public Task AddAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task SaveAsync();

    }
}
