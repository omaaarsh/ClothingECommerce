using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace ClothingECommerce.Models
{
    // Represents a customer in the e-commerce system, linked to carts and orders
    public class Customer: IdentityUser<int> 
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNo { get; set; }

    }
}
