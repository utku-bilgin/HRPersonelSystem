using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.CustomValidationCompanyDirector
{
    public class BirthDateBeforeHireDateAttributeC : ValidationAttribute
    {
        public string DateOfHire { get; }

        public BirthDateBeforeHireDateAttributeC(string dateOfHire)
        {
            DateOfHire = dateOfHire;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = (DateTime)value;
            var hireDateProperty = validationContext.ObjectType.GetProperty(DateOfHire);

            if (hireDateProperty != null)
            {
                var hireDate = (DateTime)hireDateProperty.GetValue(validationContext.ObjectInstance);

                if (birthDate.Year > hireDate.Year ||
                    (birthDate.Year == hireDate.Year && birthDate.Month > hireDate.Month) ||
                    (birthDate.Year == hireDate.Year && birthDate.Month == hireDate.Month && birthDate.Day > hireDate.Day))
                {
                    return new ValidationResult(ErrorMessage ?? "Doğum tarihi, işe başlama tarihinden önce olmalıdır.");
                }

                var age = hireDate.Year - birthDate.Year;
                if (birthDate > hireDate.AddYears(-age))
                {
                    age--;
                }

                if (age < 18)
                {
                    return new ValidationResult(ErrorMessage ?? "İşe başlama tarihi ile doğum tarihi arasında en az 18 yaş olmalıdır.");
                }
            }

            return ValidationResult.Success;
        }
    }
}