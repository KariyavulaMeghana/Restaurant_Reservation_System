using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Reservation_System.Models
{
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        [Required]
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of tables must be at least 1")]
        public int NoOfTables { get; set; }
        [Required]
        public bool IsBooked { get; set; }
    }
}