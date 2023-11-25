namespace HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNumber { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime YearOfEstablishment { get; set; } // Kuruluş Yılı
        public DateTime ContractStartDate { get; set; } // Sözleşme Başlangıç Tarihi
        public DateTime ContractEndDate { get; set; } // Sözleşme Bitiş Tarihi

        public bool IsActive { get; set; }

        public string? ImagePath { get; set; } //logo
    }
}
