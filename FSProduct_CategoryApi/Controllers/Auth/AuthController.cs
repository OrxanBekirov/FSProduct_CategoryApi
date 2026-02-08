using AutoMapper;
using FSProduct_CategoryApi.Entities.Auth;
using FSProduct_CategoryApi.Entities.Auth.Extendsions;
using FSProduct_CategoryApi.Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FSProduct_CategoryApi.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly TokenOption _tokenOptions;


        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config, Entities.Auth.TokenOption tokenOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;

            _config = config;
            _tokenOptions = _config.GetSection("TokenOptions").Get<Entities.Auth.TokenOption>();
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
        [HttpPost]
     public async Task <IActionResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if(user is null)
            {
                return NotFound();
            }
          var password =  await _userManager.CheckPasswordAsync(user,login.Password);
            if (!password)
            {
                return Unauthorized();
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _tokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(signingCredentials);//3cu yarat icine bax ne isteyir
           

            List<Claim> claims = new List<Claim>()
            {

    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Name, user.Email),
    new Claim(ClaimTypes.Email, user.Email),

            };
            claims.AddFullName(user.FullName);
            foreach(var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            JwtPayload payload = new JwtPayload
                (issuer:_tokenOptions.Issuer,audience:_tokenOptions.Audience,claims:claims,notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration));//2ci ayarat icine bax ne isteyir
            JwtSecurityToken securityToken = new JwtSecurityToken(header,payload);//biirnci yarat
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string jwt = tokenHandler.WriteToken(securityToken);
            return Ok(new
            {
                Token=jwt,
                Expire=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration)

            });

        } 

        }
    }

