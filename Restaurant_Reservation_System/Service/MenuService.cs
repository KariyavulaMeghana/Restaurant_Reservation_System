using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class MenuService : IMenuService
    {
        private readonly RestaurantDbContext _context;

        public MenuService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<MenuDTO> AddMenuAsync(MenuDTO menuDto)
        {
            var menu = new Menu
            {
                RestaurantId = menuDto.RestaurantId
            };

            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            return new MenuDTO
            {
                MenuId = menu.MenuId,
                RestaurantId = menu.RestaurantId
            };
        }
        public async Task<MenuDTO> UpdateMenuAsync(int id, MenuDTO menuDto)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
                return null;

            menu.RestaurantId = menuDto.RestaurantId;
            await _context.SaveChangesAsync();

            return new MenuDTO
            {
                MenuId = menu.MenuId,
                RestaurantId = menu.RestaurantId
            };
        }
        public async Task<bool> DeleteMenuAsync(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
                return false;

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<IEnumerable<MenuDTO>> GetAllMenusAsync()
        {
            return await _context.Menu
                .Select(m => new MenuDTO
                {
                    MenuId = m.MenuId,
                    RestaurantId = m.RestaurantId
                }).ToListAsync();
        }

        public async Task<MenuDTO> GetMenuByIdAsync(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
                return null;

            return new MenuDTO
            {
                MenuId = menu.MenuId,
                RestaurantId = menu.RestaurantId
            };

        }
        public async Task<IEnumerable<MenuDTO>> GetMenusByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Menu
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenuDTO
                {
                    MenuId = m.MenuId,
                    RestaurantId = m.RestaurantId
                }).ToListAsync();

        }
    }
}
