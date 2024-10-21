using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _context;

        public OrderService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<OrdereDtoDisplay> PlaceOrderAsync(OrderDto order)
        {
            _context.Orders.Add(new Order
            {
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                ProductName = order.ProductName,
                Quantity = order.Quantity,
                RestaurantId = order.RestaurantId,
                UserId = order.UserId
            });
            await _context.SaveChangesAsync();

            return new OrdereDtoDisplay
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                ProductName = order.ProductName,
                Quantity = order.Quantity
            };
        }

        public async Task<OrdereDtoDisplay> UpdateOrderAsync(int id, OrderDto order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
                return null;

            existingOrder.CustomerName = order.CustomerName;
            existingOrder.CustomerAddress = order.CustomerAddress;
            existingOrder.ProductName = order.ProductName;
            existingOrder.Quantity = order.Quantity;
            existingOrder.RestaurantId = order.RestaurantId;
            existingOrder.UserId = order.UserId;

            await _context.SaveChangesAsync();

            return new OrdereDtoDisplay
            {
                OrderId = existingOrder.OrderId,
                CustomerName = existingOrder.CustomerName,
                CustomerAddress = existingOrder.CustomerAddress,
                ProductName = existingOrder.ProductName,
                Quantity = existingOrder.Quantity
            };
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrdereDtoDisplay>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Select(order => new OrdereDtoDisplay
                {
                    OrderId = order.OrderId,
                    CustomerName = order.CustomerName,
                    CustomerAddress = order.CustomerAddress,
                    ProductName = order.ProductName,
                    Quantity = order.Quantity
                }).ToListAsync();
        }

        public async Task<OrdereDtoDisplay> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return null;

            return new OrdereDtoDisplay
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                ProductName = order.ProductName,
                Quantity = order.Quantity
            };
        }

        public async Task<IEnumerable<OrdereDtoDisplay>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(order => order.UserId == userId)
                .Select(order => new OrdereDtoDisplay
                {
                    OrderId = order.OrderId,
                    CustomerName = order.CustomerName,
                    CustomerAddress = order.CustomerAddress,
                    ProductName = order.ProductName,
                    Quantity = order.Quantity
                }).ToListAsync();
        }

        public async Task<IEnumerable<OrdereDtoDisplay>> GetOrdersByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Orders
                .Where(order => order.RestaurantId == restaurantId)
                .Select(order => new OrdereDtoDisplay
                {
                    OrderId = order.OrderId,
                    CustomerName = order.CustomerName,
                    CustomerAddress = order.CustomerAddress,
                    ProductName = order.ProductName,
                    Quantity = order.Quantity
                }).ToListAsync();
        }

    }
}