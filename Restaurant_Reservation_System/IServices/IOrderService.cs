
using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IOrderService
    {
        Task<OrderDtoDisplay> PlaceOrderAsync(OrderDto order);
        Task<OrderDtoDisplay> UpdateOrderAsync(int id, OrderDto order);
        Task<bool> CancelOrderAsync(int id);
        Task<IEnumerable<OrderDtoDisplay>> GetAllOrdersAsync();
        Task<OrderDtoDisplay> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDtoDisplay>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<OrderDtoDisplay>> GetOrdersByRestaurantIdAsync(int restaurantId);

    }
}
