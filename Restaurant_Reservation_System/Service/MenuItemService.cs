
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly RestaurantDbContext _context;

        public MenuItemService(RestaurantDbContext context)
        {
            _context = context;

        }

        public async Task<MenuItemDTO> AddMenuItemAsync(MenuItemDTO menuItemDto)
        {
            var menuItem = new MenuItem
            {
                ItemName = menuItemDto.ItemName,
                Description = menuItemDto.Description,
                Price = menuItemDto.Price,
                Category = menuItemDto.Category,
                MenuId = menuItemDto.MenuId
            };

            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                ItemName = menuItem.ItemName,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Category = menuItem.Category,
                MenuId = menuItem.MenuId
            };

        }
        public async Task<MenuItemDTO> UpdateMenuItemAsync(int id, MenuItemDTO menuItemDto)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
                return null;

            menuItem.ItemName = menuItemDto.ItemName;
            menuItem.Description = menuItemDto.Description;
            menuItem.Price = menuItemDto.Price;
            menuItem.Category = menuItemDto.Category;
            menuItem.MenuId = menuItemDto.MenuId;

            await _context.SaveChangesAsync();

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                ItemName = menuItem.ItemName,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Category = menuItem.Category,
                MenuId = menuItem.MenuId
            };

        }
        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
                return false;

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems
                .Select(mi => new MenuItemDTO
                {
                    MenuItemId = mi.MenuItemId,
                    ItemName = mi.ItemName,
                    Description = mi.Description,
                    Price = mi.Price,
                    Category = mi.Category,
                    MenuId = mi.MenuId
                }).ToListAsync();

        }
        public async Task<MenuItemDTO> GetMenuItemByIdAsync(int id)
        {
            var menuItem = _context.MenuItems.Where(c => c.MenuId == id).FirstOrDefault();
            if (menuItem == null)
                return null;

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                ItemName = menuItem.ItemName,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Category = menuItem.Category,
                MenuId = menuItem.MenuId
            };
        }
        public async Task<IEnumerable<MenuItemDTO>> GetMenuItemsByMenuIdAsync(int menuId)
        {
            return await _context.MenuItems
                .Where(mi => mi.MenuId == menuId)
                .Select(mi => new MenuItemDTO
                {
                    MenuItemId = mi.MenuItemId,
                    ItemName = mi.ItemName,
                    Description = mi.Description,
                    Price = mi.Price,
                    Category = mi.Category,
                    MenuId = mi.MenuId
                }).ToListAsync();

        }
    }
}
