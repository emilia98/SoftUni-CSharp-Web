using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiDemo.ValidationAttributes
{
    public class EGNValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value?.ToString() ?? "";

            if (!Regex.IsMatch(valueAsString, "[0-9]{10}"))
            {
                return new ValidationResult("ЕГН-то трябва да съдържа 10 цифри!");
            }

            var weight = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int checkSum = 0;

            for (int i = 0; i < 9; i++)
            {
                checkSum += (valueAsString[i] - '0') * weight[i];
            }

            var lastDigit = checkSum % 11;

            if (lastDigit == 10)
            {
                lastDigit = 0;
            }

            if (valueAsString[9] - '0' != lastDigit)
            {
                return new ValidationResult("Невалидно ЕГН!");
            }

            return ValidationResult.Success;
        }
    }
}
