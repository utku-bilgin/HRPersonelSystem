using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Models.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Mail Adresinizi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz!")]
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
    }
}
