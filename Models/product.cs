using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingECommerce.Models
{
    // Represents a product available for purchase
    public class Product
    {
        // Primary key for the product
        [Key]
        public int ProductID { get; set; }

        // Product name, required, max 100 characters
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Product price, required, stored as decimal with 2 decimal places
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        // URL to product image, optional, max 255 characters
        [MaxLength(255)]
        public string Image { get; set; }

        // Foreign key to the category, required
        [Required]
        public int CategoryID { get; set; }

        // Number of items in stock, defaults to 0
        public int Quantity { get; set; }

        // Product description, optional
        public string Description { get; set; }

        // Navigation property: Links product to its category
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        // Navigation property: One product can be in many cart items
    }
}