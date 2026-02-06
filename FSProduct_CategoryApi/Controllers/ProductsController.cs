using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.Entities;
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
        private readonly FSDBApiContext _context;
        private readonly  IMapper _mapper;
        public ProductsController( FSDBApiContext context,IMapper mapper)
        {
             _context = context;
            _mapper = mapper;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var result = _mapper.Map<List<GetAllProductsDto>>(products);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {

            if (id <= 0)
                return BadRequest("Id 0-dan böyük olmalıdır");

            var products = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            var dto = _mapper.Map<GetProductByIdDto>(products);
            return Ok(dto);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _context.Products.FirstOrDefaultAsync(p=>p.Id==id);
            _context.Products.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok("Mehsul silindi");
        }
        [HttpPost]
        public async Task<IActionResult>CreateProduct(CreateProductDto productDto)
        {
            var products = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(products);
           await  _context.SaveChangesAsync();
            return Ok("product yaradildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id,UpdateProductDto updateDto)
        {
            var products = await _context.Products.FindAsync(id);
            _mapper.Map(updateDto, products);
            await _context.SaveChangesAsync();
            return Ok("product yenilendi");

        }
    };
}
