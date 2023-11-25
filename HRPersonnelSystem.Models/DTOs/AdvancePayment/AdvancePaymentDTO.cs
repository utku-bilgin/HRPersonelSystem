using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRPersonnelSystem.Models.DTOs.AdvancePayment
{
    public class AdvancePaymentDTO
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public AdvancePaymentType AdvancePaymentType { get; set; }
        public decimal Amount { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public DateTime RequestDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime DateOfReply { get; set; }
        //public Image Image { get; set; }
        public string? ImagePath { get; set; }
        public string Explain { get; set; }
    }
}
