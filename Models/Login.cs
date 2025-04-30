using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
{
    public class LoginModel // Defines the LoginModel class, representing the data structure for login requests.
    {
        [Required(ErrorMessage = "Email is required")] // Specifies that the Email property is mandatory, with a custom error message if not provided.
        [EmailAddress(ErrorMessage = "Invalid email format")] // Validates that the Email property conforms to a valid email address format.
        /// <summary>
        /// Gets or sets the user's email address for login.
        /// </summary>
        /// <remarks>
        /// The email is required and must be in a valid email format (e.g., user@example.com).
        /// It is used to identify the customer in the database during authentication.
        /// </remarks>
        public string Email { get; set; } // Defines the Email property as a string, storing the user's email address.

        [Required(ErrorMessage = "Password is required")] // Specifies that the Password property is mandatory, with a custom error message if not provided.
        [DataType(DataType.Password)] // Indicates that the Password property is a password, which may influence how it is rendered in forms (e.g., masked input).
        /// <summary>
        /// Gets or sets the user's password for login.
        /// </summary>
        /// <remarks>
        /// The password is required and treated as a password type for UI rendering.
        /// It is compared against the stored password in the database during authentication (plain text in this case, insecure in production).
        /// </remarks>
        public string Password { get; set; } // Defines the Password property as a string, storing the user's password.

        /// <summary>
        /// Gets or sets a flag indicating whether the user wants to stay logged in across sessions.
        /// </summary>
        /// <remarks>
        /// If true, the authentication cookie is set to persist for 30 days; otherwise, it is session-based.
        /// This property is used to configure the cookie's persistence in the AccountController.
        /// </remarks>
        public bool RememberMe { get; set; } // Defines the RememberMe property as a boolean, indicating whether the user wants a persistent login session.
    }
}