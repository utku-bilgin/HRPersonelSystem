using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Auths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public ChangePasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("change")]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordResetDTO passwordResetDTO)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, passwordResetDTO.PreviousPassword, passwordResetDTO.NewPassword);

            if (changePasswordResult.Succeeded)
            {
                return Ok("Şifre başarıyla değiştirildi.");
            }
            else
            {
                return BadRequest("Şifre değiştirme işlemi başarısız oldu.");
            }
        }
    }
}

