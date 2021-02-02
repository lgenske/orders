using GFTTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace GFTTestBack.Data.Context
{
    public class GFTTestContext : DbContext
    {
        public GFTTestContext(DbContextOptions<GFTTestContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<OrderDish> OrderedDishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GFTTestContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
