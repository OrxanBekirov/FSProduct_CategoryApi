using AutoMapper;
using FSProduct_CategoryApi.DAL;
using FSProduct_CategoryApi.Entities;
using FSProduct_CategoryApi.Entities.Dtos.Countiries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSProduct_CategoryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountiriesController : ControllerBase
    {
        private readonly FSDBApiContext _context;
        private readonly IMapper _mapper;

        public CountiriesController(FSDBApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCountryDto>> GetAllCountry() {

         var countiries = await _context.Countries.ToListAsync();
            var list = _mapper.Map<List<GetAllCountryDto>>(countiries); 
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult>GetCountryById(int id)
        {
            var countiries = await  _context.Countries.FirstOrDefaultAsync(p => p.Id == id);
            var result = _mapper.Map<GetCountryByIdDto>(countiries);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCountry(int id)
        {
            var deleted = await _context.Countries.FirstOrDefaultAsync(p => p.Id == id);
            _context.Countries.Remove(deleted);
           await _context.SaveChangesAsync();
            return Ok("Country silindi");

        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreatCountryDto countryDto)
        {

            var country = _mapper.Map<Country>(countryDto);
            var countries = await _context.Countries.AddAsync(country);

            await _context.SaveChangesAsync();
            return Ok(countries);


        }
        [HttpPut]
        public async Task<IActionResult>UpdateCountry(int id ,UpdateCountryDto countryDto)
        {
            var contry =await _context.Countries.FindAsync(id);
            _mapper.Map(countryDto,contry);
            await _context.SaveChangesAsync();
            return Ok("Ugurla yenilendi");
        }
    }
}
