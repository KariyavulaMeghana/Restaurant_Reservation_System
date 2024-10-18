using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Data
{
    public class RestaurantDbContext : DbContext
    {
       public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options) { }
       public DbSet<User> Users { get; set; }
       public DbSet<Reservation> Reservations { get; set; }
       public DbSet<Restaurant> Restaurants { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<Review> Reviews { get; set; }
       public DbSet<Menu> Menu { get; set; }
       public DbSet<MenuItem> MenuItems { get; set; }
       public DbSet<Table> Tables { get; set; }
    }
}
