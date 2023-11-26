using HRPersonnelSystem.UI.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace HRPersonnelSystem.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }

        // GET: AuthController/Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: AuthController/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "/api/Auth/login");

                    request.Content = new StringContent($"{{\"email\":\"{model.Email}\",\"password\":\"{model.Password}\"}}");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await _httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var token = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("Token");
                        Console.WriteLine(token);

                        // Token'ı Session'a saklamak için:
                        HttpContext.Session.SetString("JwtToken", token);
                        
                        var role = GetRoleFromToken(token);
                        var id = GetUserIdFromToken(token);
                        HttpContext.Session.SetString("UserId", id);

                        switch (role)
                        {
                            case "Employee":
                                return RedirectToAction("Index", "Employee", new { area = "Employee" });
                            case "CompanyDirector":
                                return RedirectToAction("Index", "CompanyDirector", new { area = "CompanyDirector" });
                            case "Admin":
                                return RedirectToAction("Index", "Admin", new { area = "Admin" });
                            default:
                                return RedirectToAction("Index", "Home"); // Tanımlanmamış bir rol için varsayılan yönlendirme
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda ilgili işlemleri yapabilirsiniz.
                    ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                }
            }

            return View(model);
        }

        private string GetRoleFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            Console.WriteLine(roleClaim);
            return roleClaim?.Value;

        }

        private string GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth", new { Area = "" }); 
        }
    }
}
