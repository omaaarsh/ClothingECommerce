using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClothingECommerce.Models
{
    /// <summary>
    /// Custom validation attribute to ensure the phone number is exactly 11 digits.
    /// </summary>
    /// <remarks>
    /// Validates that the phone number contains only digits and is exactly 11 characters long,
    /// aligning with the Customer model's PhoneNo constraints.
    /// </remarks>
    public class PhoneNumberFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            var phoneNo = value.ToString();
            var regex = new Regex(@"^\d{11}$");

            if (!regex.IsMatch(phoneNo))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}