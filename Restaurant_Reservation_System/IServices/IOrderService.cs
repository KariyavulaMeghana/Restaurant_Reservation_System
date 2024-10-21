
using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IOrderService
    {
        Task<OrdereDtoDisplay> PlaceOrderAsync(OrderDto order);
        Task<OrdereDtoDisplay> UpdateOrderAsync(int id, OrderDto order);
        Task<bool> CancelOrderAsync(int id);
        Task<IEnumerable<OrdereDtoDisplay>> GetAllOrdersAsync();
        Task<OrdereDtoDisplay> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrdereDtoDisplay>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<OrdereDtoDisplay>> GetOrdersByRestaurantIdAsync(int restaurantId);

    }
}
