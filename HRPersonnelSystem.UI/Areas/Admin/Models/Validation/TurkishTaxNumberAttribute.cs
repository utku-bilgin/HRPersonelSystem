using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Admin.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class TurkishTaxNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string taxNumber = value.ToString();

            if (taxNumber.Length != 10)
                return false;

            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit = int.Parse(taxNumber[i].ToString());

                if (i % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
            }

            return sum % 10 == 0;
        }
    }
}
