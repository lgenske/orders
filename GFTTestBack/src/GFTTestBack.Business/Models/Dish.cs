using System;
using System.Collections.Generic;

namespace GFTTestBack.Business.Models
{
    public class Dish
    {
        public Dish()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public int DishType { get; set; }
        public string DayTime { get; set; }
        public bool OrderMany { get; set; }

        public ICollection<OrderDish> OrderedDishes { get; set; }
    }
}
