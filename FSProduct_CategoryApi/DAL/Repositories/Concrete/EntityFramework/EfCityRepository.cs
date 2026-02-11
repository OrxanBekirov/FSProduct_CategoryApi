using FSProduct_CategoryApi.Core.Repositories.Concrete.EntityFramework;
using FSProduct_CategoryApi.DAL.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;

namespace FSProduct_CategoryApi.DAL.Repositories.Concrete.EntityFramework
{
    public class EfCityRepository : EfBaseRepository<City, FSDBApiContext>, ICityRepository
    {
        public EfCityRepository(FSDBApiContext context) : base(context)
        {
        }
    }
}
