using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IRestaurantServices
    {
        Task<string> AddNewRestaurant(RestaurantDTO restaurant);
        Task<string> UpdateRestaurant(RestaurantDTO Updaterestaurant);
        Task<string> DeleteRestaurant(int restaurantId);
        Task<RestaurantDTO> GetRestaurantById(int restaurantId);
        Task<List<RestaurantDTO>> GetAllRestaurants();
        Task<List<RestaurantDTO>> GetRestaurantByLocation(string location);
        Task<List<RestaurantDTO>> SearchRestaurants(string name, string location);
    }
}
