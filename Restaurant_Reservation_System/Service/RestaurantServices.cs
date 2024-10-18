using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Mappings;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantServices(RestaurantDbContext context)
        {
            _dbContext = context;
        }
        public async Task<string> AddNewRestaurant(RestaurantDTO restaurantDTO)
        {
            try
            {
                if (restaurantDTO != null)
                {

                    var restaurant = restaurantDTO.ToEntity();
                    _dbContext.Restaurants.Add(restaurant);
                    await _dbContext.SaveChangesAsync();
                    return "Data is added";
                }
                else
                {
                    return "It is empty";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteRestaurant(int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                await _dbContext.SaveChangesAsync();
                return "Restaurant removed";
            }
            else
            {
                return "Restaurant not found";
            }
        }

        public async Task<List<RestaurantDTO>> GetAllRestaurants()
        {
            var restaurants = await _dbContext.Restaurants.ToListAsync();
            return restaurants.ToDTOList();
        }

        //public async Task<List<RestaurantDTO>> GetRestaurantByCategory(string category)
        //{
        //    var restaurants = await _dbContext.Restaurants
        //    .Where(r => r.RestaurantName == category)
        //    .ToListAsync();

        //    return restaurants.ToDTOList();
        //}
        public async Task<RestaurantDTO> GetRestaurantById(int restaurantId)
        {
            try
            {
                Restaurant restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(r => r.RestaurantID == restaurantId);
                if (restaurant != null)
                {
                    return restaurant.ToDTO();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RestaurantDTO>> GetRestaurantByLocation(string location)
        {
            var restaurants = await _dbContext.Restaurants
            .Where(r => r.Location == location)
            .ToListAsync();

            return restaurants.ToDTOList();
        }

        public async Task<List<RestaurantDTO>> SearchRestaurants(string name, string location)
        {
            try
            {
                var query = _dbContext.Restaurants.AsQueryable();


                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(r => r.RestaurantName.Contains(name));
                }
                if (!string.IsNullOrEmpty(location))
                {
                    query = query.Where(r => r.Location.Contains(location));
                }


                var restaurants = await query.ToListAsync();
                return restaurants.ToDTOList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while searching restaurants: " + ex.Message);
            }
        }

        public async Task<string> UpdateRestaurant(RestaurantDTO Updaterestaurant)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.RestaurantID == Updaterestaurant.RestaurantID);
            if (restaurant != null)
            {
                restaurant.RestaurantName = Updaterestaurant.RestaurantName;
                restaurant.Description = Updaterestaurant.Description;
                restaurant.Location = Updaterestaurant.Location;
                restaurant.ContactNumber = Updaterestaurant.ContactNumber;


                _dbContext.Restaurants.Update(restaurant);
                await _dbContext.SaveChangesAsync();
                return "Restaurant updated successfully";
            }
            else
            {
                return "Restaurant not found";
            }
        }
    }
}
