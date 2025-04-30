using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using ClothingECommerce.Models;
using ClothingECommerce.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ClothingECommerce.Services
{
    /// <summary>
    /// Provides business logic for customer-related operations, including authentication, registration, and data retrieval.
    /// </summary>
    /// <remarks>
    /// This service implements the ICustomerService interface and interacts with the ICustomerRepository to perform data operations.
    /// It handles tasks such as password hashing, email uniqueness validation, and claims-based authentication.
    /// The service is registered as a scoped service in Program.cs for dependency injection.
    /// </remarks>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the CustomerService with dependency injection.
        /// </summary>
        /// <param name="customerRepository">The ICustomerRepository instance for accessing customer data.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the ICustomerRepository, enabling data operations.
        /// </remarks>
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _customerRepository.GetByEmailAsync(email);
        }
        public async Task<ClaimsPrincipal> AuthenticateAsync(LoginModel model)
        {
            var customer = await _customerRepository.GetByEmailAsync(model.Email);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(model.Password, customer.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, customer.Name),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.NameIdentifier, customer.ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
        public async Task<ClaimsPrincipal> SignUpAsync(SignUp model)
        {
            var existingCustomer = await _customerRepository.GetByEmailAsync(model.Email);
            if (existingCustomer != null)
            {
                throw new InvalidOperationException("Email is already registered.");
            }

            var customer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password), // Hash the password
                PhoneNo = model.PhoneNo
            };

            await _customerRepository.AddAsync(customer);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, customer.Name),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.NameIdentifier, customer.ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}