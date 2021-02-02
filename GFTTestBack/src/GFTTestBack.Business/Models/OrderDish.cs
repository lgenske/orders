using System;

namespace GFTTestBack.Business.Models
{
    public class OrderDish
    {
        public OrderDish()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order order { get; set; }
        public Guid DishId { get; set; }
        public Dish dish { get; set; }
    }
}
