using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class ProfileMapping
    {
        public static ProfileDTO ToProfileDTO(this User user)
        {
            return new ProfileDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            };
        }
        public static User ToProfileEntity(this ProfileDTO profile)
        {
            return new User
            {
                UserId = profile.UserId,
                Username = profile.Username,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address,
                Email = profile.Email,
                Password = profile.Password,
                PhoneNumber = profile.PhoneNumber,
                Role = profile.Role,
            };
        }
    }
}
