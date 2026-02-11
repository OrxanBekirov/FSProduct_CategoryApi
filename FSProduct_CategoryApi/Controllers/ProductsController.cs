using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.DAL.Repositories.Abstract;
using FSProduct_CategoryApi.Entities;
using FSProduct_CategoryApi.Entities.Dtos.Categories;
using FSProduct_CategoryApi.Entities.Dtos.Cities;
using FSProduct_CategoryApi.Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSProduct_CategoryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository product,IMapper mapper)
        {
            _repo = product;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products= await _repo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet]
        public async Task<IActionResult>GetProductById(int id)
        {
           var product= await _repo.GetAsync(p=>p.Id==id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repo.AddAsync(product);
            await _repo.SaveAsync();
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _repo.GetAsync(p=>p.Id==id);
            _repo.Delete(deleted);
            await _repo.SaveAsync();
            return Ok("Product silindi");
        }

      
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id,UpdateProductDto updateProduct)
        {

            var update = await _repo.GetAsync(p => p.Id == id);
            _mapper.Map(updateProduct,update);
            await _repo.SaveAsync();
            return Ok("product yenilendi");
        }
     

    };
}
