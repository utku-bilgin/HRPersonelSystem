using HRPersonnelSystem.UI.Areas.Employee.Models.AdvancePaymentDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Employee.CustomValidation
{
    public class AdvancePaymentCurrencyUnitValid : ValidationAttribute
    {

        public decimal Amount { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var advance = (AdvancePaymentDTO)validationContext.ObjectInstance;

            if (advance.Amount != null)
            {
                Amount = (decimal)value;
            }




            if (advance.AdvancePaymentType == AdvancePaymentType.Kurumsal)
            {
                if (Amount <= 0)
                {
                    return new ValidationResult("Avans talebiniz sıfır veya negatif bir değer olamaz.");
                }

                switch (advance.CurrencyUnit)
                {
                    case CurrencyUnit.TL:
                        if (Amount > 90000)
                        {
                            return new ValidationResult("Avans talebiniz 90000 TL üzerinde olamaz.");
                        }
                        break;
                    case CurrencyUnit.USD:
                    case CurrencyUnit.EUR:
                    case CurrencyUnit.CAD:
                    case CurrencyUnit.GBP:
                        if (Amount > 3000)
                        {
                            return new ValidationResult($"Avans talebiniz 3000 {advance.CurrencyUnit} üzerinde olamaz.");
                        }
                        break;
                    

                }
            }
            else 
            {
                if (advance.CurrencyUnit != CurrencyUnit.TL || Amount > 15000)
                {
                    return new ValidationResult("Bireysel Avans talebiniz sadece TL üzerinden olabilir. Ve 15000 üzerinde olamaz.");
                }
                    
            }


            return ValidationResult.Success;

        }
    }
}
