using System.ComponentModel.DataAnnotations; // Imports the namespace for data annotations, used for model validation attributes like Required, StringLength, etc.
using System.ComponentModel.DataAnnotations.Schema; // Imports the namespace for database-related annotations, such as Key, DatabaseGenerated, and Table, used for Entity Framework Core mapping.
using System.Text.RegularExpressions; // Imports the namespace for regular expressions, used for custom validation logic in password and phone number checks.

namespace ClothingECommerce.Models // Defines the namespace for the models, organizing the Customer class and related validation attributes in the application.
{
    // Custom validation attribute for password complexity
    /// <summary>
    /// Validates that a password meets complexity requirements, including length and character type constraints.
    /// </summary>
    public class ComplexPasswordAttribute : ValidationAttribute // Defines a custom validation attribute by inheriting from ValidationAttribute to enforce complex password rules.
    {
        /// <summary>
        /// Validates the password against complexity requirements.
        /// </summary>
        /// <param name="value">The password to validate, expected to be a string.</param>
        /// <param name="validationContext">The context providing metadata about the validation process.</param>
        /// <returns>
        /// Returns ValidationResult.Success if the password is valid, or a ValidationResult with an error message if invalid.
        /// </returns>
        /// <remarks>
        /// The password must be 6-100 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.
        /// This attribute is applied to the Password property of the Customer class to ensure secure passwords in the e-commerce application.
        /// </remarks>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) // Overrides the IsValid method to implement custom password validation logic.
        {
            var password = value as string; // Casts the input value to a string, representing the password to validate.
            if (string.IsNullOrEmpty(password)) // Checks if the password is null or empty, which is invalid.
            {
                return new ValidationResult("Password is required."); // Returns a validation error if the password is null or empty.
            }

            // Password must have:
            // - At least one uppercase letter (A-Z)
            // - At least one lowercase letter (a-z)
            // - At least one digit (0-9)
            // - At least one special character (e.g., !@#$%^&*)
            // - Length between 6 and 100 characters
            var regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{6,100}$"); // Creates a regular expression to enforce password complexity rules.
            if (!regex.IsMatch(password)) // Checks if the password matches the regex pattern.
            {
                return new ValidationResult("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character."); // Returns a validation error if the password does not match the pattern.
            }

            return ValidationResult.Success; // Returns success if the password passes all validation checks.
        }
    }

    // Custom validation attribute for phone number format
    /// <summary>
    /// Validates that a phone number is exactly 11 digits.
    /// </summary>
    public class PhoneNumberFormatAttribute : ValidationAttribute // Defines a custom validation attribute by inheriting from ValidationAttribute to enforce phone number format rules.
    {
        /// <summary>
        /// Validates the phone number against the required format.
        /// </summary>
        /// <param name="value">The phone number to validate, expected to be a string.</param>
        /// <param name="validationContext">The context providing metadata about the validation process.</param>
        /// <returns>
        /// Returns ValidationResult.Success if the phone number is valid, or a ValidationResult with an error message if invalid.
        /// </returns>
        /// <remarks>
        /// The phone number must be exactly 11 digits (no other characters allowed).
        /// This attribute is applied to the PhoneNo property of the Customer class to ensure valid phone numbers in the e-commerce application.
        /// </remarks>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) // Overrides the IsValid method to implement custom phone number validation logic.
        {
            var phoneNo = value as string; // Casts the input value to a string, representing the phone number to validate.
            if (string.IsNullOrEmpty(phoneNo)) // Checks if the phone number is null or empty, which is invalid.
            {
                return new ValidationResult("Phone number is required."); // Returns a validation error if the phone number is null or empty.
            }

            // Must be exactly 11 digits
            if (!Regex.IsMatch(phoneNo, @"^\d{11}$")) // Checks if the phone number matches the regex pattern for exactly 11 digits.
            {
                return new ValidationResult("Phone number must be exactly 11 digits."); // Returns a validation error if the phone number does not match the pattern.
            }

            return ValidationResult.Success; // Returns success if the phone number passes all validation checks.
        }
    }

    /// <summary>
    /// Represents a customer in the e-commerce application, including their personal details and validation rules.
    /// </summary>
    /// <remarks>
    /// This class is used as a model for storing customer data in the database via Entity Framework Core.
    /// It includes properties for ID, Name, Email, Password, and PhoneNo, each with validation attributes to ensure data integrity.
    /// The model is mapped to a database table and used in customer-related operations, such as registration and profile management.
    /// </remarks>
    public class Customer // Defines the Customer class, representing a customer entity in the e-commerce application.
    {
        [Key] // Marks the ID property as the primary key for the Customer entity in the database.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specifies that the ID value is generated by the database as an auto-incrementing identity column.
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        /// <remarks>
        /// This property is the primary key in the Customers table and is automatically incremented by the database (IDENTITY(1,1)).
        /// It uniquely identifies each customer in the e-commerce application.
        /// </remarks>
        public int ID { get; set; } // Defines the ID property as an integer, serving as the unique identifier for a customer.

        [Required(ErrorMessage = "Name is required")] // Specifies that the Name property is mandatory, with a custom error message if not provided.
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")] // Limits the Name property to a maximum of 100 characters, with a custom error message if exceeded.
        /// <summary>
        /// Gets or sets the customer's name.
        /// </summary>
        /// <remarks>
        /// This property stores the customer's full name and is required with a maximum length of 100 characters.
        /// It is used for display and identification in the e-commerce application.
        /// </remarks>
        public string Name { get; set; } // Defines the Name property as a string, storing the customer's name.

        [Required(ErrorMessage = "Email is required")] // Specifies that the Email property is mandatory, with a custom error message if not provided.
        [EmailAddress(ErrorMessage = "Invalid email format")] // Validates that the Email property conforms to a valid email address format.
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")] // Limits the Email property to a maximum of 255 characters, with a custom error message if exceeded.
        /// <summary>
        /// Gets or sets the customer's email address.
        /// </summary>
        /// <remarks>
        /// This property stores the customer's email, which must be unique, valid, and no longer than 255 characters.
        /// It is used for authentication and communication in the e-commerce application.
        /// </remarks>
        public string Email { get; set; } // Defines the Email property as a string, storing the customer's email address.

        [Required(ErrorMessage = "Password is required")] // Specifies that the Password property is mandatory, with a custom error message if not provided.
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")] // Enforces a password length between 6 and 100 characters, with a custom error message if violated.
        [ComplexPassword(ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character")] // Applies the custom ComplexPassword validation attribute to enforce password complexity.
        /// <summary>
        /// Gets or sets the customer's password.
        /// </summary>
        /// <remarks>
        /// This property stores the customer's password, which must meet complexity requirements.
        /// In production, passwords should be hashed before storage for security.
        /// </remarks>
        public string Password { get; set; } // Defines the Password property as a string, storing the customer's password (should be hashed in production).

        [Required(ErrorMessage = "Phone number is required")] // Specifies that the PhoneNo property is mandatory, with a custom error message if not provided.
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be exactly 11 characters")] // Enforces that the PhoneNo property is exactly 11 characters, with a custom error message if violated.
        [PhoneNumberFormat(ErrorMessage = "Phone number must be exactly 11 digits")] // Applies the custom PhoneNumberFormat validation attribute to ensure the phone number is 11 digits.
        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        /// <remarks>
        /// This property stores the customer's phone number, which must be exactly 11 digits.
        /// It is used for contact purposes in the e-commerce application.
        /// </remarks>
        public string PhoneNo { get; set; } // Defines the PhoneNo property as a string, storing the customer's phone number.
    }
}
