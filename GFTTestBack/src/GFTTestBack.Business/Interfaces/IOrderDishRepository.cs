using GFTTestBack.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Interfaces
{
    public interface IOrderDishRepository
    {
        Task Add(OrderDish orderDish);

        Task<List<OrderDish>> GetOrderDishesByOrderID(Guid orderId);
    }
}
