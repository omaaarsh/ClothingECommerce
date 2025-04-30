using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ClothingECommerce.Services;
using ClothingECommerce.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ClothingECommerce.Controllers // Defines the namespace for controller classes, organizing the AccountController in the application.
{
    /// <summary>
    /// Handles HTTP requests related to user account operations, such as login, logout, registration, and authentication status checks.
    /// </summary>
    /// <remarks>
    /// This controller interacts with the ICustomerService to perform business logic for account operations.
    /// It uses cookie-based authentication to manage user sessions and is configured with CORS to allow requests from the frontend.
    /// The controller is registered in Program.cs for dependency injection and uses logging for request tracking and error reporting.
    /// API versioning is implemented with the 'api/v1' prefix to support future updates without breaking existing clients.
    /// </remarks>
    [ApiController]
    [Route("api/v1/accounts")]
    [EnableCors("allow-frontend")] // Updated: Match Program.cs CORS policy
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService; // Declares a readonly field to store the ICustomerService instance, used for business logic.
        private readonly ILogger<AccountController> _logger; // Declares a readonly field to store the ILogger instance, used for logging.

        /// <summary>
        /// Initializes a new instance of the AccountController with dependency injection.
        /// </summary>
        /// <param name="customerService">The ICustomerService instance for handling customer-related business logic.</param>
        /// <param name="logger">The ILogger instance for logging request and error information.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the ICustomerService and ILogger instances.
        /// These are stored for use in controller methods to process requests and log events.
        /// </remarks>
        public AccountController(ICustomerService customerService, ILogger<AccountController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        /// <summary>
        /// Authenticates a user based on their login credentials and signs them in using cookie authentication.
        /// </summary>
        /// <param name="model">The LoginModel containing the email, password, and optional RememberMe flag.</param>
        /// <returns>
        /// A Task containing an IActionResult with a JSON response indicating login success or failure.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">Thrown if the email or password is invalid.</exception>
        /// <exception cref="Exception">Thrown for unexpected errors during sign-in.</exception>
        /// <remarks>
        /// This method validates the input model, calls ICustomerService.AuthenticateAsync to verify credentials,
        /// and signs in the user using cookie authentication. It logs request outcomes and errors for debugging.
        /// The endpoint is accessible anonymously to allow unauthenticated users to log in.
        /// </remarks>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid login model: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { message = "Invalid input.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            try
            {
                var principal = await _customerService.AuthenticateAsync(model);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                _logger.LogInformation("User logged in: {Email}", model.Email);
                return Ok(new { message = "Login successful." });
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError("Login failed for email: {Email}, {Message}", model.Email, ex.Message);
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to sign in user: {Email}", model.Email);
                return StatusCode(500, new { message = "Failed to sign in." });
            }
        }

        /// <summary>
        /// Signs out the current user and clears their authentication cookie.
        /// </summary>
        /// <returns>
        /// A Task containing an IActionResult with a JSON response indicating logout success.
        /// </returns>
        /// <remarks>
        /// This method calls HttpContext.SignOutAsync to remove the authentication cookie and logs the event.
        /// It is accessible to authenticated users and returns a success message upon completion.
        /// Uses POST to align with REST conventions for state-changing operations.
        /// </remarks>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out.");
            return Ok(new { message = "Logged out successfully." });
        }

        /// <summary>
        /// Checks the authentication status of the current user and returns their details if authenticated.
        /// </summary>
        /// <returns>
        /// A Task containing an IActionResult with a JSON response indicating authentication status and user details.
        /// </returns>
        /// <remarks>
        /// This method checks if the user is authenticated via User.Identity.IsAuthenticated and retrieves claims
        /// (e.g., name, email, ID) if authenticated. It logs request details and user information for debugging.
        /// The endpoint is accessible anonymously to allow clients to check authentication status.
        /// </remarks>
        [HttpGet("status")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckAuth()
        {
            _logger.LogInformation("CheckAuth called. Origin: {Origin}, Cookies: {Cookies}", 
                Request.Headers["Origin"], 
                Request.Cookies.Select(c => $"{c.Key}: {c.Value}"));
            _logger.LogInformation("User Identity: IsAuthenticated={IsAuthenticated}, Name={Name}", 
                User.Identity.IsAuthenticated, User.Identity.Name);

            await Task.CompletedTask;

            if (User.Identity.IsAuthenticated)
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                _logger.LogInformation("CheckAuth: Authenticated user - Name: {Name}, Email: {Email}, ID: {ID}", 
                    User.Identity.Name, email, id);
                return Ok(new
                {
                    isAuthenticated = true,
                    name = User.Identity.Name ?? "User",
                    email = email,
                    id = id
                });
            }

            _logger.LogInformation("CheckAuth: User is not authenticated.");
            return Ok(new { isAuthenticated = false, name = "", email = "", id = "" });
        }

        /// <summary>
        /// Returns debugging information about the current request's cookies and authentication status.
        /// </summary>
        /// <returns>
        /// An IActionResult with a JSON response containing cookie details and authentication status.
        /// </returns>
        /// <remarks>
        /// This method retrieves all cookies from the request and checks User.Identity.IsAuthenticated.
        /// It is used for debugging authentication issues and is accessible anonymously.
        /// The response includes a list of cookies and the authentication status for diagnostic purposes.
        /// </remarks>
        [HttpGet("debug-cookies")]
        [AllowAnonymous]
        public IActionResult DebugCookie()
        {
            var cookies = Request.Cookies.Select(c => new { c.Key, c.Value });
            _logger.LogDebug("DebugCookie called. Cookies: {Cookies}", cookies);
            return Ok(new { Cookies = cookies, IsAuthenticated = User.Identity.IsAuthenticated });
        }

        /// <summary>
        /// Registers a new customer and signs them in using cookie authentication.
        /// </summary>
        /// <param name="model">The SignUp model containing customer registration details (e.g., name, email, password).</param>
        /// <returns>
        /// A Task containing an IActionResult with a JSON response indicating signup success or failure.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the email is already registered.</exception>
        /// <exception cref="Exception">Thrown for unexpected errors during registration or sign-in.</exception>
        /// <remarks>
        /// This method validates the input model, calls ICustomerService.SignUpAsync to register the customer,
        /// and signs in the user using cookie authentication. It logs request outcomes and errors for debugging.
        /// The endpoint is accessible anonymously to allow new users to register.
        /// </remarks>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUp model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid SignUp model: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { message = "Invalid input.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            try
            {
                var principal = await _customerService.SignUpAsync(model);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                _logger.LogInformation("User registered and signed in successfully: {Email}", model.Email);
                return Ok(new { message = "Registration successful" });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("SignUp failed for email: {Email}, {Message}", model.Email, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during SignUp for email: {Email}", model.Email);
                return StatusCode(500, new { message = "An error occurred during registration. Please try again later." });
            }
        }
    }
}