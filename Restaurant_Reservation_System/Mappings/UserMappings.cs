using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class UserMappings
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            };
        }
        public static User ToEntity(this UserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.UserId,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Address = userDTO.Address,
                PhoneNumber = userDTO.PhoneNumber,
                Role = userDTO.Role,
            };
        }
        public static List<UserDTO> ToDTOList(this List<User> users)
        {
            var userDTOs = new List<UserDTO>();
            return users.Select(user => ToDTO(user)).ToList();
        }
    }
}