using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(MenuDTO menuDto)
        {
            var result = await _menuService.AddMenuAsync(menuDto);
            return CreatedAtAction(nameof(GetMenuById), new { id = result.MenuId }, result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, MenuDTO menuDto)
        {
            var result = await _menuService.UpdateMenuAsync(id, menuDto);
            if (result == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var result = await _menuService.DeleteMenuAsync(id);
            if (!result)
                return NotFound();
            return NoContent();

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> GetAllMenus()
        {
            var result = await _menuService.GetAllMenusAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDTO>> GetMenuById(int id)
        {
            var result = await _menuService.GetMenuByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);

        }
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> GetMenusByRestaurantId(int restaurantId)
        {
            var result = await _menuService.GetMenusByRestaurantIdAsync(restaurantId);
            return Ok(result);

        }
    }
}
