using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class MappingRestaurant
    {
        public static RestaurantDTO ToDTO(this Restaurant restaurant)
        {
            return new RestaurantDTO
            {
                RestaurantID = restaurant.RestaurantID,
                RestaurantName = restaurant.RestaurantName,
                Description = restaurant.Description,
                Location = restaurant.Location,
                ContactNumber = restaurant.ContactNumber,
            };
        }

        public static Restaurant ToEntity(this RestaurantDTO restaurantDTO)
        {
            return new Restaurant
            {
                RestaurantID = restaurantDTO.RestaurantID,
                RestaurantName = restaurantDTO.RestaurantName,
                Description = restaurantDTO.Description,
                Location = restaurantDTO.Location,
                ContactNumber = restaurantDTO.ContactNumber,
            };
        }
        public static List<RestaurantDTO> ToDTOList(this List<Restaurant> restaurants)
        {
            return restaurants.Select(r => r.ToDTO()).ToList();
        }
    }
}
