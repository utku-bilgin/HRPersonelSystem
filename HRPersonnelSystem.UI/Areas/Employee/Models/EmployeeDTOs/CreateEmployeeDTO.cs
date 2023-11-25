using HRPersonnelSystem.UI.Areas.CompanyDirector.CustomValidationCompanyDirector;
using HRPersonnelSystem.UI.Areas.Employee.CustomValidation;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(20, ErrorMessage = "Ad en fazla 20 karakter olmalıdır.")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "İkinci Ad en fazla 20 karakter olmalıdır.")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [MaxLength(30, ErrorMessage = "Soyad en fazla 30 karakter olmalıdır.")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "İkinci Soyad en fazla 20 karakter olmalıdır.")]
        public string? SecondLastName { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı zorunludur.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi alanı zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Doğum Yeri alanı zorunludur.")]
        [MaxLength(25, ErrorMessage = "Doğum Yeri en fazla 25 karakter olmalıdır.")]
        public string BirthPlace { get; set; }


        [Required(ErrorMessage = "TC Kimlik Numarası alanı zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "TC Kimlik Numarası 11 haneli olmalıdır.")]
        public string TCNumber { get; set; }


        [Required(ErrorMessage = "İşe Giriş Tarihi alanı zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        [BirthDateBeforeHireDateAndAtLeast18("DateOfHire", ErrorMessage = "Doğum tarihi ile İşe başlama tarihi arasında en az 18 Yıl olmalıdır.")]
        public DateTime DateOfHire { get; set; }
        [DataType(DataType.Date)]

        [Required(ErrorMessage = "Meslek alanı zorunludur.")]
        [MaxLength(60, ErrorMessage = "Meslek en fazla 60 karakter olmalıdır.")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Departman alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Departman en fazla 50 karakter olmalıdır.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Maaş alanı zorunludur.")]
        [Range(0, 100000, ErrorMessage = "Maaş 0 ile 100000 arasında olmalıdır.")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Şirket Adı alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Şirket Adı en fazla 100 karakter olmalıdır.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Telefon Numarası alanı zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefon en fazla 11 karakter olmalıdır.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        [MaxLength(200, ErrorMessage = "Adres en fazla 200 karakter olmalıdır.")]
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;

        public Guid RoleId { get; set; } = Guid.Parse("cba7d3c3-51e2-4694-9003-4177b2c43808");
        public string? ImagePath { get; set; }
        //public IFormFile? Photo { get; set; }


    }
}
