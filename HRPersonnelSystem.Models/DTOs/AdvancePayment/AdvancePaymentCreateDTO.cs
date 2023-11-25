using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.AdvancePayment
{
	public class AdvancePaymentCreateDTO
	{
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Avans ödeme türü zorunludur.")]
        public AdvancePaymentType AdvancePaymentType { get; set; }

        [Required(ErrorMessage = "Avans miktarı zorunludur.")]
        [Range(1,100000)]
        public decimal Amount { get; set; }

        public Guid? EmployeeId { get; set; }

        [Required(ErrorMessage = "Para birimi seçimi zorunludur.")]
        public CurrencyUnit CurrencyUnit { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;
        public DateTime DateOfReply { get; set; }
        public string? ImagePath { get; set; }
        //public Image Image { get; set; }
        [Display(Name = "Dosya")]
        [Required(ErrorMessage = "Dosya alanını boş bırakmayınız.")]
        public IFormFile? Photo { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Açıklama en az 3 karakter ve en fazla 100 karakter olmalıdır.")]
        public string Explain { get; set; }
    }
}
