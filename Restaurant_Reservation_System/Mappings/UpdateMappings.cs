using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class UpdateMappings
    {
        public static UpdateDTO ToDTOUpdate(this User user)
        {
            return new UpdateDTO
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
            };
        }
        public static User ToUpdateEntity(this UpdateDTO dto)
        {
            return new User
            {
                Username = dto.Username,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
            };
        }
        public static List<UpdateDTO> ToDTOUpdateList(this List<User> users)
        {
            var userDTOs = new List<UpdateDTO>();
            return users.Select(user => user.ToDTOUpdate()).ToList();
        }
    }
}
