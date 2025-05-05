using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClothingECommerce.Models
{
    /// <summary>
    /// Custom validation attribute to enforce password complexity requirements.
    /// </summary>
    /// <remarks>
    /// Ensures the password contains at least one uppercase letter, one lowercase letter,
    /// one digit, and one special character (e.g., !@#$%^&*).
    /// </remarks>
    public class ComplexPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            var password = value.ToString();
            var regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{6,}$");

            if (!regex.IsMatch(password))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}