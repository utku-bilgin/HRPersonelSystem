using HRPersonnelSystem.UI.Areas.Employee.Models.Entity;
using HRPersonnelSystem.UI.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ChangePasswordController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> ChangePassword(PasswordResetViewModel passwordResetViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login"); // Kullanıcı mevcut değilse, giriş sayfasına yönlendir
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, passwordResetViewModel.PreviousPassword, passwordResetViewModel.NewPassword);

                if (changePasswordResult.Succeeded)
                {
                    // Şifre değiştirme başarılı ise kullanıcıyı otomatik olarak çıkış yapmaya zorla
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login");
                }

                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(passwordResetViewModel);
        }
    }
}