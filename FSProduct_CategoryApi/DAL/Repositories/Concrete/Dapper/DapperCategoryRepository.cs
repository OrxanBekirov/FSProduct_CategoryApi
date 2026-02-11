using FSProduct_CategoryApi.DAL.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.DAL.Repositories.Concrete.Dapper
{         

    //Eger sistem deyisimi dapper kecirilerse burda rahat sekilde kecirdirik 
    public class DapperCategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChange(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
