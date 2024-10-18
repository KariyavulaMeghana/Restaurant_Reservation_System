using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Reservation_System.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [NotMapped]
        public decimal? TotalAmount
        {
            get; set;
        }
        public virtual User User { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; internal set; }
        public virtual Restaurant Restaurant { get; set; }
        [Required]
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; internal set; }
    }
}
