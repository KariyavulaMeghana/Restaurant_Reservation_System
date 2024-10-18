using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching orders.");
                return StatusCode(500, "An error occurred while fetching the orders.");
            }
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching the order.");
                return StatusCode(500, "An error occurred while fetching the order.");
            }
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto order)
        {
            if (order == null)
            {
                return BadRequest("Order data is null.");
            }
            try
            {
                var placedOrder = await _orderService.PlaceOrderAsync(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = placedOrder.OrderId },
                    $"Order placed successfully. Order ID: {placedOrder.OrderId}");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while placing the order.");
                return StatusCode(500, $"An error occurred while placing the order. {ex.Message}");
            }
        }


        // PUT: api/orders/5

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto order)
        {
            if (order == null)
            {
                return BadRequest("Order data is null.");
            }
            try
            {
                var updatedOrder = await _orderService.UpdateOrderAsync(id, order);
                if (updatedOrder == null)
                {
                    return NotFound("Order not found.");
                }
                return Ok($"Order updated successfully. Order ID: {updatedOrder.OrderId}");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while updating the order.");
                return StatusCode(500, "An error occurred while updating the order.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            try
            {
                var deleted = await _orderService.CancelOrderAsync(id);
                if (!deleted)
                {
                    return NotFound("Order not found.");
                }
                return Ok($"Order cancelled successfully. Order ID: {id}");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while cancelling the order.");
                return StatusCode(500, "An error occurred while cancelling the order.");
            }
        }

        // GET: api/orders/user/5
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserIdAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching orders for user.");
                return StatusCode(500, "An error occurred while fetching orders for the user.");
            }
        }

        // GET: api/orders/restaurant/5
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetOrdersByRestaurantId(int restaurantId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByRestaurantIdAsync(restaurantId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching orders for restaurant.");
                return StatusCode(500, "An error occurred while fetching orders for the restaurant.");
            }
        }

    }
}
