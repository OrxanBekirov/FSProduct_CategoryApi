using FSProduct_CategoryApi.Core.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace FSProduct_CategoryApi.DAL.Repositories.Abstract
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
      

    }
}
