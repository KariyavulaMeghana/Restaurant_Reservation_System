using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Reservation_System.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Status { get; set; }
    }
}