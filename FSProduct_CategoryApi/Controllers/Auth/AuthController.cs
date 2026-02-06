using AutoMapper;
using FSProduct_CategoryApi.Entities.Auth;
using FSProduct_CategoryApi.Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FSProduct_CategoryApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
              var user  = _mapper.Map<AppUser>(register);
          var addedUser =   await _userManager.CreateAsync(user, register.Password);
            if (!addedUser.Succeeded) {

                return BadRequest(new
                {
                    Error = addedUser.Errors,
                    code = 400
                });
            
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new
            {
                Message = "User registered successfully"
            });

        }
        

        }
    }

