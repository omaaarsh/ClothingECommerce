using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models
{
        public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be non-negative")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // e.g., "Pending", "Shipped", "Delivered"

        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

}