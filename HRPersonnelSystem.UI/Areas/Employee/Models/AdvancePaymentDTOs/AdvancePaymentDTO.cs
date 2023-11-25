
using HRPersonnelSystem.UI.Areas.Employee.CustomValidation;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.Images;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRPersonnelSystem.UI.Areas.Employee.Models.AdvancePaymentDTOs
{
    
    public class AdvancePaymentDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Avans ödeme türü zorunludur.")]
        public AdvancePaymentType AdvancePaymentType { get; set; }

        [Required(ErrorMessage = "Para birimi seçimi zorunludur.")]
        public CurrencyUnit CurrencyUnit { get; set; }

        [Required(ErrorMessage = "Avans miktarı zorunludur.")]
        [AdvancePaymentCurrencyUnitValid]
        public decimal? Amount { get; set; }

        public Guid? EmployeeId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;

        public DateTime DateOfReply { get; set; }
        public string? ImagePath { get; set; }

        [StringLength(100, MinimumLength = 10, ErrorMessage = "Açıklama en az 10 karakter ve en fazla 100 karakter olmalıdır.")]
		[Required(ErrorMessage = "Açıklama girmek zorunludur.")]
		public string? Explain { get; set; }
    }
}
