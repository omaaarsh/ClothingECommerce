using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
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
    public class SignUp
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        /// <summary>
        /// Gets or sets the user's full name for registration.
        /// </summary>
        /// <remarks>
        /// The name is required and must not exceed 100 characters, matching the Customer model's Name property constraints.
        /// It is used to create a new Customer record in the database during registration.
        /// </remarks>
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        /// <summary>
        /// Gets or sets the user's email address for registration.
        /// </summary>
        /// <remarks>
        /// The email is required, must be in a valid format (e.g., user@example.com), and must not exceed 255 characters.
        /// It is used to identify the customer in the database and must be unique, as enforced by the Customer model's unique index.
        /// </remarks>
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        [ComplexPassword(ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        /// <summary>
        /// Gets or sets the user's password for registration.
        /// </summary>
        /// <remarks>
        /// The password is required, must be 6-100 characters long, and must meet complexity requirements (uppercase, lowercase, digit, special character).
        /// It is used to create a new Customer record, but should be hashed before storage in the database for security.
        /// </remarks>
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be exactly 11 characters")]
        [PhoneNumberFormat(ErrorMessage = "Phone number must be exactly 11 digits")]
        /// <summary>
        /// Gets or sets the user's phone number for registration.
        /// </summary>
        /// <remarks>
        /// The phone number is required and must be exactly 11 digits, matching the Customer model's PhoneNo constraints.
        /// It is used for contact purposes and stored in the Customer record.
        /// </remarks>
        public string PhoneNo { get; set; }
    }
}