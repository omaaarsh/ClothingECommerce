using System.ComponentModel.DataAnnotations;

namespace ClothingECommerce.Models{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be non-negative")]
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}