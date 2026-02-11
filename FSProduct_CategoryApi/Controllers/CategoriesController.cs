using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.DAL.Repositories.Abstract;
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
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllcategory()
        {
            return Ok(await _repo.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _repo.GetAsync(c=>c.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult>CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repo.AddAsync(category);
            await _repo.SaveAsync();
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id ,UpdateCategoryDto updateCategoryDto)
        {
            var update = await _repo.GetAsync(c => c.Id == id);
            _mapper.Map(update, update);
            await _repo.SaveAsync();
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteCategory(int id)
        {
            var delete = await _repo.GetAsync(c => c.Id == id);
            _repo.Delete(delete);
            await _repo.SaveAsync();
            return Ok(delete);
        }
    }
}
