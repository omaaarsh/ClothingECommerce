using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
{
public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [Required]
        public int CartID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        public Cart Cart { get; set; }

        public Product Product { get; set; }
    }
}