using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IMenuService
    {
        Task<MenuDTO> AddMenuAsync(MenuDTO menuDto);
        Task<MenuDTO> UpdateMenuAsync(int id, MenuDTO menuDto);
        Task<bool> DeleteMenuAsync(int id);
        Task<IEnumerable<MenuDTO>> GetAllMenusAsync();
        Task<MenuDTO> GetMenuByIdAsync(int id);
        Task<IEnumerable<MenuDTO>> GetMenusByRestaurantIdAsync(int restaurantId);

    }
}
