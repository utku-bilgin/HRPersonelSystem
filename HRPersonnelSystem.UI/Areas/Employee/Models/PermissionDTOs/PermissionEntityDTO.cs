using HRPersonnelSystem.UI.Areas.Employee.CustomValidation;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.PermissionDTOs
{
    public class PermissionEntityDTO
    {
        public Guid Id { get; set; }

        public PermissionType PermissionType { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi kısmı doldurulmak zorundadır!")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "01/01/2023", "01/01/2025", ErrorMessage = "Geçerli bir tarih giriniz.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Gün sayısı kısmı doldurulmak zorundadır!")]
        [Range(1, 70, ErrorMessage = "Gün sayısı 1-70 arasında olmalıdır!")]
        public int? CountOfDay { get; set; }

        public DateTime? EndDate
        {
            get
            {
                if (StartDate.HasValue && CountOfDay.HasValue) 
                {
                    return StartDate.Value.AddDays(CountOfDay.Value);
                } 
                else 
                {
                    return null;
                } 
            }
        }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;

        public DateTime? DateOfReply { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? EmployeeId { get; set; }

        public EmployeeEntity? EmployeeEntity { get; set; }

        public Gender Gender { get; set; }
    }
}
