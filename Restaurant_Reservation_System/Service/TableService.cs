using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class TableService : ITableService
    {
        private readonly RestaurantDbContext _context;

        public TableService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<TableDtoDisplay> AddTableAsync(TableDto table)
        {
            _context.Tables.Add(new Table
            {
                NoOfTables = table.NoOfTables,
                IsBooked = table.IsBooked,
                RestaurantId = table.RestaurantId
            });

            await _context.SaveChangesAsync();

            return new TableDtoDisplay
            {
                TableId = table.TableId,
                NoOfTables = table.NoOfTables,
                IsBooked = table.IsBooked
            };
        }
        public async Task<TableDtoDisplay> UpdateTableAsync(int id, TableDto table)
        {
            var existingTable = await _context.Tables.FindAsync(id);
            if (existingTable == null) return null;

            existingTable.NoOfTables = table.NoOfTables;
            existingTable.IsBooked = table.IsBooked;
            existingTable.RestaurantId = table.RestaurantId;

            await _context.SaveChangesAsync();

            return new TableDtoDisplay
            {
                TableId = existingTable.TableId,
                NoOfTables = existingTable.NoOfTables,
                IsBooked = existingTable.IsBooked
            };
        }
        public async Task<bool> DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TableDtoDisplay>> GetAllTablesAsync()
        {
            return await _context.Tables
                .Select(table => new TableDtoDisplay
                {
                    TableId = table.TableId,
                    NoOfTables = table.NoOfTables,
                    IsBooked = table.IsBooked
                }).ToListAsync();

        }
        public async Task<TableDtoDisplay> GetTableByIdAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return null;

            return new TableDtoDisplay
            {
                TableId = table.TableId,
                NoOfTables = table.NoOfTables,
                IsBooked = table.IsBooked
            };
        }

        public async Task<IEnumerable<TableDtoDisplay>> GetTablesByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Tables
                .Where(table => table.RestaurantId == restaurantId)
                .Select(table => new TableDtoDisplay
                {
                    TableId = table.TableId,
                    NoOfTables = table.NoOfTables,
                    IsBooked = table.IsBooked
                }).ToListAsync();

        }
        public async Task<IEnumerable<TableDtoDisplay>> CheckTableAvailabilityAsync()
        {
            return await _context.Tables
                .Where(table => !table.IsBooked)
                .Select(table => new TableDtoDisplay
                {
                    TableId = table.TableId,
                    NoOfTables = table.NoOfTables,
                    IsBooked = table.IsBooked
                }).ToListAsync();
        }
    }
}
