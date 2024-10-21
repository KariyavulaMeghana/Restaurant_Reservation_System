using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantServices _context;

        public RestaurantsController(IRestaurantServices context)
        {
            _context = context;
        }

        // GET: api/Restaurants

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetRestaurants()
        {
            var restaurants = await _context.GetAllRestaurants();
            return Ok(restaurants);
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurantbyId(int id)
        {
            var restaurant = await _context.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, RestaurantDTO restaurantDTO)
        {
            if (id != restaurantDTO.RestaurantID)
            {
                return BadRequest();
            }
            var result = await _context.UpdateRestaurant(restaurantDTO);
            if (result == "Restaurant not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }


        // POST: api/Restaurants

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantDTO restaurantDTO)
        {
            var result = await _context.AddNewRestaurant(restaurantDTO);
            return CreatedAtAction(nameof(GetRestaurantbyId), new { id = restaurantDTO.RestaurantID }, result);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.DeleteRestaurant(id);
            if (restaurant == "Restaurant not found")
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
        
        // GET: api/Restaurants/location/{location}
        [HttpGet("location/{location}")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsByLocation(string location)
        {
            var restaurants = await _context.GetRestaurantByLocation(location);
            return Ok(restaurants);
        }

        // GET: api/Restaurants/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> SearchRestaurants(string name, string location)
        {
            var restaurants = await _context.SearchRestaurants(name, location);
            return Ok(restaurants);
        }
    }
}
