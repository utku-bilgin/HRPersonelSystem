using HRPersonnelSystem.UI.Areas.Admin.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs
{
    public class CreateCompanyDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Şirket Adı alanı zorunludur.")]
        [MaxLength(30, ErrorMessage = "Şirket Adı en fazla 30 karakter olmalıdır!")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Şirket Ünvanı alanı zorunludur.")]
        [MaxLength(30, ErrorMessage = "Şirket Ünvanı en fazla 30 karakter olmalıdır!")]
        public string CompanyTitle { get; set; }


        [Required(ErrorMessage = "Mersis numarası zorunludur.")]
        [TurkishMersisNumber(ErrorMessage = "Geçerli bir Mersis numarası giriniz!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mersis numarası 10 haneli olmalıdır.")]
        public string MersisNumber { get; set; }

        [MaxLength(100, ErrorMessage = "Vergi Dairesi en fazla 100 karakter olmalıdır!")]
        [Required(ErrorMessage = "Vergi Dairesi alanı zorunludur.")]
        public string TaxOffice { get; set; }


        [Required(ErrorMessage = "Vergi numarası alanı zorunludur.")]
        [TurkishTaxNumber(ErrorMessage = "Geçerli bir vergi numarası giriniz!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Vergi numarası 10 haneli olmalıdır.")]
        public string TaxNumber { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Required(ErrorMessage = "Telefon numarası alanı zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçersiz telefon numarası girdiniz!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres alanını boş bırakmayınız!")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Adres alanı en az 3 en fazla 250 karakterden oluşmalıdır.")]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz!")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        public string Email { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Çalışan Sayısı 0 veya daha fazla olmalıdır!")]
        [Required(ErrorMessage = "Çalışan sayısı alanı zorunludur.")]
        public int NumberOfEmployees { get; set; }

        [Required(ErrorMessage = "Tarih seçiniz!")]
        public DateTime YearOfEstablishment { get; set; }

        [Required(ErrorMessage = "Tarih seçiniz!")]
        public DateTime ContractStartDate { get; set; }

        [Required(ErrorMessage = "Tarih seçiniz!")]
        public DateTime ContractEndDate { get; set; }

        public bool IsActive { get; set; } = true;

        
        public string ImagePath { get; set; }
    }

}
