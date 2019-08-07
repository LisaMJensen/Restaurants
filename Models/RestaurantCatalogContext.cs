using Microsoft.EntityFrameworkCore;

namespace RestaurantCatalog.Models
{
    public class RestaurantCatalogContext : DbContext
    {
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestaurantCatalogContext(DbContextOptions options) : base(options) { }
    }
}