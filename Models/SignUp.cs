using System.ComponentModel.DataAnnotations; // Imports the namespace for data annotations, used for model validation attributes like Required, EmailAddress, and StringLength.

namespace ClothingECommerce.Models // Defines the namespace for model classes, organizing the SignUp class in the application.
{
    /// <summary>
    /// Represents the data model for user sign-up requests, including personal details and validation rules.
    /// </summary>
    /// <remarks>
    /// This class is used to validate user input during registration attempts in the e-commerce application.
    /// It is typically sent as JSON in the body of a POST request to the /Account/SignUp endpoint.
    /// The model includes validation attributes to ensure the name, email, password, and phone number meet specific requirements,
    /// aligning with the Customer model's database constraints and validation rules.
    /// </remarks>
    public class SignUp // Defines the SignUp class, representing the data structure for user registration requests.
    {
        [Required(ErrorMessage = "Name is required")] // Specifies that the Name property is mandatory, with a custom error message if not provided.
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")] // Limits the Name property to a maximum of 100 characters, with a custom error message if exceeded.
        /// <summary>
        /// Gets or sets the user's full name for registration.
        /// </summary>
        /// <remarks>
        /// The name is required and must not exceed 100 characters, matching the Customer model's Name property constraints.
        /// It is used to create a new Customer record in the database during registration.
        /// </remarks>
        public string Name { get; set; } // Defines the Name property as a string, storing the user's full name.

        [Required(ErrorMessage = "Email is required")] // Specifies that the Email property is mandatory, with a custom error message if not provided.
        [EmailAddress(ErrorMessage = "Invalid email format")] // Validates that the Email property conforms to a valid email address format.
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")] // Limits the Email property to a maximum of 255 characters, with a custom error message if exceeded.
        /// <summary>
        /// Gets or sets the user's email address for registration.
        /// </summary>
        /// <remarks>
        /// The email is required, must be in a valid format (e.g., user@example.com), and must not exceed 255 characters.
        /// It is used to identify the customer in the database and must be unique, as enforced by the Customer model's unique index.
        /// </remarks>
        public string Email { get; set; } // Defines the Email property as a string, storing the user's email address.

        [Required(ErrorMessage = "Password is required")] // Specifies that the Password property is mandatory, with a custom error message if not provided.
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")] // Enforces a password length between 6 and 100 characters, with a custom error message if violated.
        [ComplexPassword(ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character")] // Applies the custom ComplexPassword validation attribute to enforce password complexity.
        /// <summary>
        /// Gets or sets the user's password for registration.
        /// </summary>
        /// <remarks>
        /// The password is required, must be 6-100 characters long, and must meet complexity requirements (uppercase, lowercase, digit, special character).
        /// It is used to create a new Customer record, but should be hashed before storage in the database for security.
        /// </remarks>
        public string Password { get; set; } // Defines the Password property as a string, storing the user's password.

        [Required(ErrorMessage = "Phone number is required")] // Specifies that the PhoneNo property is mandatory, with a custom error message if not provided.
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be exactly 11 characters")] // Enforces that the PhoneNo property is exactly 11 characters, with a custom error message if violated.
        [PhoneNumberFormat(ErrorMessage = "Phone number must be exactly 11 digits")] // Applies the custom PhoneNumberFormat validation attribute to ensure the phone number is 11 digits.
        /// <summary>
        /// Gets or sets the user's phone number for registration.
        /// </summary>
        /// <remarks>
        /// The phone number is required and must be exactly 11 digits, matching the Customer model's PhoneNo constraints.
        /// It is used for contact purposes and stored in the Customer record.
        /// </remarks>
        public string PhoneNo { get; set; } // Defines the PhoneNo property as a string, storing the user's phone number.
    }
}