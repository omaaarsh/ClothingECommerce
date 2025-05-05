using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
{
    // Represents a product category (e.g., Man, Women, Kid)
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Navigation property: One category has many products
        public virtual ICollection<Product> Products { get; set; }
    }
}