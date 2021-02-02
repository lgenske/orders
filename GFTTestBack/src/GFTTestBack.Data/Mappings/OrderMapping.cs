using GFTTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GFTTestBack.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderTime)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(o => o.DayTime)
                .IsRequired();

            builder.ToTable("Orders");
        }
    }
}
