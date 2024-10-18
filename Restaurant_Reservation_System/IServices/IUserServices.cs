using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.IServices
{
    public interface IUserServices
    {
        Task<string> RegisterNewUser(User user);
        Task<string> Login(string username, string password);
        Task<string> DeleteUser(int id);
        Task<string> UpdateUser(int id, User user);
        Task<List<UserDTO>> GetUsers();
    }
}
