using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var users = await _userServices.GetUsers();
            return Ok(users);
        }

        // POST: api/User/Login
        //[HttpPost("Login")]
        //public async Task<ActionResult<string>> Login([FromBody] LoginModel loginModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid login attempt.");
        //    }

        //    var result = await _userServices.Login(loginModel.Username, loginModel.Password);

        //    if (result == "Login successful")
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _userServices.Login(model.Username, model.Password);

            if (result.Message == "Login successful")
            {
                return Ok(result); // Return the LoginResponse object
            }

            return Unauthorized(new { Message = result.Message });
        }


        // POST: api/User/Register
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            var result = await _userServices.RegisterNewUser(user);

            if (result == "User added successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateUser(int id, [FromBody] User user)
        {
            var result = await _userServices.UpdateUser(id, user);

            if (result == "User updated successfully")
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            var result = await _userServices.DeleteUser(id);

            if (result == "User removed successfully")
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userServices.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

    }
}