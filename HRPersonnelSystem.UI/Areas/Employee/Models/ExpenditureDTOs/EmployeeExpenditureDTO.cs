using HRPersonnelSystem.UI.Areas.Employee.CustomValidation;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.ExpenditureDTOs
{
	public class EmployeeExpenditureDTO
    {
        public Guid Id { get; set; }

        
        [Required(ErrorMessage = "Harcama türünü boş bırakmayınız.")]
        public ExpenditureType ExpenditureType { get; set; }


       
        [ExpenditureLimitCustomValidation]
        public decimal? Amount { get; set; } 

        
        [Required(ErrorMessage = "Para Birimi alanını boş bırakmayınız.")]
        public CurrencyUnit CurrencyUnit { get; set; }

      
        
        public DateTime RequestDate { get; set; } = DateTime.Now;

       
        [Required(ErrorMessage = "Onay Durumu alanını boş bırakmayınız.")]
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;

   
      
        public DateTime DateOfReply { get; set; } 


        public Guid? EmployeeId { get; set; }
        public EmployeeEntity? Employee { get; set; }

     
        [Required(ErrorMessage = "Dosya alanını boş bırakmayınız.")]
        public IFormFile? Photo { get; set; }
        public string? ImagePath { get; set; }
        
    }
}
