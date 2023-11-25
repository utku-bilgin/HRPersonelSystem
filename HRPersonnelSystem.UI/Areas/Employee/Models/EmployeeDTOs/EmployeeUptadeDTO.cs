using HRPersonnelSystem.UI.Areas.Employee.Models.Images;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs
{
    public class EmployeeUptadeDTO
    {
        public Guid Id { get; set; }
        //public Image? Image { get; set; }
        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "Adres alanını boş bırakmayınız.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Adres alanı en az 3 en fazla 250 karakterden oluşmalıdır.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Telefon alanını boş bırakmayınız.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçersiz telefon numarası girdiniz.")]
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
    }
}
