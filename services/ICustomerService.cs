using System.Security.Claims;
using System.Threading.Tasks;
using ClothingECommerce.Models;

namespace ClothingECommerce.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Retrieves a customer by their email address.
        /// </summary>
        /// <param name="email">The email address of the customer to retrieve.</param>
        /// <returns>
        /// A Task containing the Customer object if found, or null if no customer matches the email.
        /// </returns>
        /// <remarks>
        /// This method uses the ICustomerRepository to find a customer by email, primarily for authentication purposes.
        /// The email is assumed to be unique in the database.
        /// </remarks>
        Task<Customer> GetByEmailAsync(string email);
        
        /// <summary>
        /// Authenticates a customer based on their login credentials.
        /// </summary>
        /// <param name="model">The LoginModel containing the email and password.</param>
        /// <returns>
        /// A Task containing a ClaimsPrincipal for the authenticated customer.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">Thrown if the email or password is invalid.</exception>
        /// <remarks>
        /// This method verifies the customer's password using BCrypt and creates a ClaimsPrincipal for authentication.
        /// </remarks>
        Task<ClaimsPrincipal> AuthenticateAsync(LoginModel model);

        /// <summary>
        /// Registers a new customer and authenticates them.
        /// </summary>
        /// <param name="model">The SignUp model containing customer registration details.</param>
        /// <returns>
        /// A Task containing a ClaimsPrincipal for the newly registered customer.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the email is already registered.</exception>
        /// <remarks>
        /// This method validates email uniqueness, hashes the password, saves the customer via ICustomerRepository,
        /// and creates a ClaimsPrincipal for authentication.
        /// </remarks>
        Task<ClaimsPrincipal> SignUpAsync(SignUp model);
    }
}