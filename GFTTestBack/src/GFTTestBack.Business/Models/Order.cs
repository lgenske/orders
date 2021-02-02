using System;
using System.Collections.Generic;

namespace GFTTestBack.Business.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            OrderTime = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime OrderTime { get; set; }
        public string DayTime { get; set; }

        public ICollection<OrderDish> OrderedDishes { get; set; }
    }
}
