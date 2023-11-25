using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.ExpenditureDTOs;
using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Employee.CustomValidation
{
    public class ExpenditureLimitCustomValidation : ValidationAttribute
    {
        public CurrencyUnit CurrencyUnit { get; set; }
        public decimal Amount { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var expenditure = (EmployeeExpenditureDTO)validationContext.ObjectInstance;
            if (expenditure.Amount == null)
            {
                return new ValidationResult("Harcama miktarını boş bırakmayınız.");
            }
            Amount = (decimal)value;//Amonut probuna değer atamak için özellik verdik.
            var currencyUnit = expenditure.CurrencyUnit; //otomatik para birimleri gelmesi için bu değişkene atadık.


            switch (expenditure.ExpenditureType)
            {
                case ExpenditureType.Seyahat:
                    if (Amount < 1 || Amount > 10000)
                    {
                        return new ValidationResult($"Seyahat harcaması talebiniz 0 ile 10000 {currencyUnit}  arasında olabilir.");
                    }
                    break;
                case ExpenditureType.Konaklama:
                    if (Amount < 1 || Amount > 15000)
                    {
                        return new ValidationResult($"Konaklama harcaması talebiniz 0 ile 15000 {currencyUnit} arasında olabilir.");
                    }
                    break;
                case ExpenditureType.Yemek:
                    if (Amount < 1 || Amount > 10000)
                    {
                        return new ValidationResult($"Yemek harcaması talebiniz 0 ile 10000 {currencyUnit} arasında olabilir.");
                    }
                    break;                
                case ExpenditureType.Etkinlik:
                    if (Amount < 1 || Amount > 5000)
                    {
                        return new ValidationResult($"Etkinlik harcaması talebiniz 0 ile 5000 {currencyUnit} arasında olabilir.");
                    }
                    break;
                case ExpenditureType.İletişim:
                    if (Amount < 1 || Amount > 5000)
                    {
                        return new ValidationResult($"İletişim harcaması talebiniz 0 ile 5000 {currencyUnit} arasında olabilir.");
                    }
                    break;
                case ExpenditureType.İş:
                    if (Amount < 1 || Amount > 5000)
                    {
                        return new ValidationResult($"İş harcaması talebiniz 0 ile 5000 {currencyUnit} arasında olabilir.");
                    }
                    break;
                case ExpenditureType.Diğer:
                    if (Amount < 1 || Amount > 10000)
                    {
                        return new ValidationResult($"Diğer harcaması talebiniz 0 ile 10000 {currencyUnit} arasında olabilir.");
                    }
                    break;
            }



            return ValidationResult.Success;
        }
    }
}

