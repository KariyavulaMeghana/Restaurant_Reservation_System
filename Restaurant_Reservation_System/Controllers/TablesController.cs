using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Controllers
{
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        // GET: api/tables
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }

        // GET: api/tables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound("Table not found.");
            }
            return Ok(table);
        }

        // POST: api/tables
        [HttpPost]
        public async Task<IActionResult> AddTable([FromBody] TableDto table)
        {
            if (table == null)
            {
                return BadRequest("Table data is null.");
            }
            try
            {
                var addedTable = await _tableService.AddTableAsync(table);
                return CreatedAtAction(nameof(GetTableById), new { id = addedTable.TableId },
                    $"Table added successfully. Table ID: {addedTable.TableId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the table. {ex.Message}");
            }
        }

        // PUT: api/tables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, [FromBody] TableDto table)
        {
            if (table == null)
            {
                return BadRequest("Table data is null.");
            }
            try
            {
                var updatedTable = await _tableService.UpdateTableAsync(id, table);
                if (updatedTable == null)
                {
                    return NotFound("Table not found.");
                }
                return Ok($"Table edited successfully. Table ID: {updatedTable.TableId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the table. {ex.Message}");
            }
        }

        // DELETE: api/tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            try
            {
                var deleted = await _tableService.DeleteTableAsync(id);
                if (!deleted)
                {
                    return NotFound("Table not found.");
                }
                return Ok($"Table deleted successfully. Table ID: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the table. {ex.Message}");
            }
        }
        // GET: api/tables/restaurant/5
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetTablesByRestaurantId(int restaurantId)
        {
            var tables = await _tableService.GetTablesByRestaurantIdAsync(restaurantId);
            return Ok(tables);
        }
        // GET: api/tables/availability
        [HttpGet("availability")]
        public async Task<IActionResult> CheckTableAvailability()
        {
            var availableTables = await _tableService.CheckTableAvailabilityAsync();
			if (availableTables == null || !availableTables.Any())
			{
				throw new CustomException("No tables are available at the moment.");
			}
			return Ok(availableTables);
        }

    }
}
