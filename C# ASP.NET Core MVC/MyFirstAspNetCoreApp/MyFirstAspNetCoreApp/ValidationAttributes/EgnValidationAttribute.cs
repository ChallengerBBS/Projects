namespace MyFirstAspNetCoreApp.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class EgnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value.ToString();

            if (!Regex.IsMatch(valueAsString, "[0-9]{10}"))
            {
                return new ValidationResult("ЕГН-то трябва да съдържа 10 чифри !");
            }
            var weight = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum+=(valueAsString[i] - '0') * weight[i];
            }
            var lastDigit = checksum % 11;
            if (lastDigit == 10)
            {
                lastDigit = 0;
            }
            if(valueAsString[9]-'0'!=lastDigit)
            {
                return new ValidationResult("Невалидно ЕГН !");

            }

            return ValidationResult.Success;
        }
    }
}
