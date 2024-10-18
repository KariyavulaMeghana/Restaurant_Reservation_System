using System.ComponentModel.DataAnnotations;

namespace Restaurant_Reservation_System.DTO
{
    public class UpdateDTO
    {
        [Required(ErrorMessage = "Enter User Name")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string? Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string? LastName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string? Address { get; set; }

    }
}
