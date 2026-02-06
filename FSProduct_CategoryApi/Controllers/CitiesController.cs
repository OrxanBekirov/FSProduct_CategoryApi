using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.Entities;
using FSProduct_CategoryApi.Entities.Dtos.Cities;
using FSProduct_CategoryApi.Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSProduct_CategoryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly FSDBApiContext _context;
        private readonly IMapper _mapper;

        public CitiesController(FSDBApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAllCities()
        {
           var city =  _context.Cities.Include(p=>p.Country).ToListAsync();
            var list = _mapper.Map<List<GetAllCitiesDto>>(city);
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetCityById(int id)
        {

            if (id <= 0)
                return BadRequest("Id 0-dan böyük olmalıdır");

            var city = await _context.Cities.Include(p => p.Country).FirstOrDefaultAsync(p => p.Id == id);
            var dto = _mapper.Map<GetCityByIdDto>(city);
            return Ok(dto);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var deleted = await _context.Cities.FirstOrDefaultAsync(p => p.Id == id);
            _context.Cities.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok("City silindi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return Ok("City yaradildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, UpdateCityDto updateDto)
        {
            var city = await _context.Cities.FindAsync(id);
            _mapper.Map(updateDto, city);
            await _context.SaveChangesAsync();
            return Ok("product yenilendi");

        }
    }
}
