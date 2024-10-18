using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IMenuItemService
    {
        Task<MenuItemDTO> AddMenuItemAsync(MenuItemDTO menuItemDto);
        Task<MenuItemDTO> UpdateMenuItemAsync(int id, MenuItemDTO menuItemDto);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetMenuItemByIdAsync(int id);
        Task<IEnumerable<MenuItemDTO>> GetMenuItemsByMenuIdAsync(int menuId);

    }
}
