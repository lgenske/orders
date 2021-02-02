using GFTTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFTTestBack.Data.Mappings
{
    public class DishMapping : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(d => d.DishType)
                .IsRequired();

            builder.Property(d => d.DayTime)
                .IsRequired();

            builder.Property(d => d.OrderMany)
                .IsRequired()
                .HasDefaultValue(false);

            builder.ToTable("Dishes");
        }
    }
}
