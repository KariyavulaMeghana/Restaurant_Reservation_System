using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Mappings;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class UserServices : IUserServices
    {
        private readonly RestaurantDbContext _context;
        public UserServices(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<string> DeleteUser(int id)
        {
            var userFound = await _context.Users.FindAsync(id);
            if (userFound != null)
            {
                _context.Users.Remove(userFound);
                await _context.SaveChangesAsync();
                return "User removed successfully";
            }
            return "User Id Not found";
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            List<UserDTO> userDTOs = users.Select(user => user.ToDTO()).ToList();
            return userDTOs;
        }
       
        public async Task<LoginResponse> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new LoginResponse
                {
                    Message = "Username or password cannot be empty",
                    Role = null
                };
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return new LoginResponse
                {
                    Message = "User not found",
                    Role = null
                };
            }

            if (user.Password == password)
            {
                return new LoginResponse
                {
                    Message = "Login successful",
                    Role = user.Role // Return the user's role
                };
            }
            else
            {
                return new LoginResponse
                {
                    Message = "Invalid username or password",
                    Role = null
                };
            }
        }


        public async Task<string> RegisterNewUser(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return "User added successfully";
            }
            return "User Not added, Something went wrong";
        }


        public async Task<string> UpdateUser(int id, User user)
        {
            var userFound = await _context.Users.FindAsync(id);
            if (userFound != null)
            {

                userFound.Username = user.Username;
                userFound.Password = user.Password;
                userFound.FirstName = user.FirstName;
                userFound.LastName = user.LastName;
                userFound.Email = user.Email;
                userFound.Address = user.Address;
                userFound.PhoneNumber = user.PhoneNumber;
                userFound.Role = user.Role;

                await _context.SaveChangesAsync();
                return "User updated successfully";
            }
            return "User not found";
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null; 
            }

            return user; 
        }
    }
}