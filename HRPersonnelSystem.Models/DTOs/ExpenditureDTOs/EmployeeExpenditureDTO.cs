using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.ExpenditureDTOs
{
    public class EmployeeExpenditureDTO
    {
        public Guid Id { get; set; }

      
        public ExpenditureType ExpenditureType { get; set; }

        public decimal Amount { get; set; }

       
        public CurrencyUnit CurrencyUnit { get; set; }

      
        public DateTime? RequestDate { get; set; }

      
        public ApprovalStatus ApprovalStatus { get; set; }

       
        public DateTime? DateOfReply { get; set; }
        //public Image? Image { get; set; }
        //public Guid? ImageId { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

   
        public IFormFile? Photo { get; set; }
        public string? ImagePath { get; set; }
        //public Guid ImageId { get; set; }
    }
}
