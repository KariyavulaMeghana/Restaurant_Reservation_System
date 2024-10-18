using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface ITableService
    {
        Task<TableDtoDisplay> AddTableAsync(TableDto table);
        Task<TableDtoDisplay> UpdateTableAsync(int id, TableDto table);
        Task<bool> DeleteTableAsync(int id);
        Task<IEnumerable<TableDtoDisplay>> GetAllTablesAsync();
        Task<TableDtoDisplay> GetTableByIdAsync(int id);
        Task<IEnumerable<TableDtoDisplay>> GetTablesByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<TableDtoDisplay>> CheckTableAvailabilityAsync();
    }
}
