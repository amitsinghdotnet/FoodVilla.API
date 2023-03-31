using FoodVilla.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodVilla.API.Data
{
    public class FoodVillaDBContext: DbContext
    {
        public FoodVillaDBContext(DbContextOptions<FoodVillaDBContext> context) : base(context) { }

        public DbSet<Product> Products { get; set; }
    }
}
