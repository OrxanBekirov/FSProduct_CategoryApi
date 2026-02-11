using FSProduct_CategoryApi.Core.Repositories.Concrete.EntityFramework;
using FSProduct_CategoryApi.DAL.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.DAL.Repositories.Concrete.EntityFramework
{
    public class EfProductRepository : EfBaseRepository<Product, FSDBApiContext>, IProductRepository
    {
        public EfProductRepository(FSDBApiContext context) : base(context)
        {
        }
    }
}
