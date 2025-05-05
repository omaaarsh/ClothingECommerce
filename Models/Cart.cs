using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
{
   public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}