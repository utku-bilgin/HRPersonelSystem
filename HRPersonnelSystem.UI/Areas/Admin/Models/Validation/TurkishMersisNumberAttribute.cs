using System.ComponentModel.DataAnnotations;

namespace HRPersonnelSystem.UI.Areas.Admin.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class TurkishMersisNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string mersisNumber = value.ToString();

            if (mersisNumber.Length != 10)
                return false;

            int[] weights = { 1, 1, 1, 1, 1, 1, 2, 2, 2, 1 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit = int.Parse(mersisNumber[i].ToString());
                sum += digit * weights[i];
            }

            int remainder = sum % 10;

            return remainder == 0;
        }
    }
}
