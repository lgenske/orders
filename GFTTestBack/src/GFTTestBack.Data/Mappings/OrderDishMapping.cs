using GFTTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFTTestBack.Data.Mappings
{
    class OrderDishMapping : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
            builder.HasKey(od => od.Id);

            builder.HasOne(od => od.order)
                .WithMany(o => o.OrderedDishes)
                .HasForeignKey(od => od.OrderId);

            builder.HasOne(od => od.dish)
                .WithMany(d => d.OrderedDishes)
                .HasForeignKey(od => od.DishId);

            builder.ToTable("OrderedDishes");
        }
    }
}
