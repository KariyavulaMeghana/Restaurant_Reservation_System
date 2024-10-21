using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem([FromBody] MenuItemDTO menuItemDto)
        {
            if (menuItemDto == null)
            {
                return BadRequest("Menu item data is null.");
            }

            var result = await _menuItemService.AddMenuItemAsync(menuItemDto);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = result.MenuItemId }, result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItemDTO menuItemDto)
        {
            if (menuItemDto == null)
            {
                throw new CustomException("Menu item data is null.");
            }

            var result = await _menuItemService.UpdateMenuItemAsync(id, menuItemDto);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var result = await _menuItemService.DeleteMenuItemAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/menuitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetAllMenuItems()
        {
            var result = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItemById(int id)
        {
            var result = await _menuItemService.GetMenuItemByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/menuitems/menu/{menuId}
        [HttpGet("menu/{menuId}")]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetMenuItemsByMenuId(int menuId)
        {
            var result = await _menuItemService.GetMenuItemsByMenuIdAsync(menuId);
            return Ok(result);

        }
    }
}
