using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var token = GenerateJwtToken(user, userRoles);
                return Ok(token);
            }

            // LoginDTO kullanarak istemciden gelen kullanıcı adı ve şifre bilgilerini alır ve bu bilgilerle kullanıcıyı doğrular. Başarılı bir giriş işlemi sonucunda bir JWT token oluşturulur ve kullanıcıya döndürülür.

            return Unauthorized();
        }


        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("Bu, kimlik doğrulaması gerektiren bir özel endpoint'tir.");
        }




        private string GenerateJwtToken(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>();

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    }
}
