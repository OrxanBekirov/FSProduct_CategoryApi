using FSProduct_CategoryApi.Core.Repositories.Concrete.EntityFramework;
using FSProduct_CategoryApi.DAL.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.DAL.Repositories.Concrete.EntityFramework
{
    public class EfCategoryrepository : EfBaseRepository<Category, FSDBApiContext>, ICategoryRepository
    {
        public EfCategoryrepository(FSDBApiContext context) : base(context)
        {
        }
    }
}
