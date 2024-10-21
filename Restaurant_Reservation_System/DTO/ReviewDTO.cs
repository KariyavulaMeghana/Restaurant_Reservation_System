using System.ComponentModel.DataAnnotations;

namespace Restaurant_Reservation_System.DTO
{
    public class ReviewDTO
    {   
        [Key]
        [Required]
        public int ReviewID { get; set; } 
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
