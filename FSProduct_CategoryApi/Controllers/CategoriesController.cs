using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.Entities;
using FSProduct_CategoryApi.Entities.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSProduct_CategoryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly FSDBApiContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(FSDBApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async  Task<ActionResult<GetDto>> GetAll()
        {

            var categories = await _context.Categories.ToListAsync();

            var dtoList = _mapper.Map<List<GetDto>>(categories);

            return Ok(dtoList);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
          var result = await _context.Categories.FirstOrDefaultAsync(p=>p.Id == Id);
            await _context.SaveChangesAsync();
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreatCategory(CreateCategoryDto createdto)
        {
            //Category category = new Category
            //{
            //    Name = createdto.Name
            //};

            var category = _mapper.Map<Category>(createdto);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return Ok(category);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var deleted = await _context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
            _context.Categories.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int Id,UpdateCategoryDto updatedto)
        {

            var updated = await _context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
            _mapper.Map(updatedto,updated);
            _context.Categories.Update(updated);
            await _context.SaveChangesAsync();
            return Ok(updated);

        }
    }
}
