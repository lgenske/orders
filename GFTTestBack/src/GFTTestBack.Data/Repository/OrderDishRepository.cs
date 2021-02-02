using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using GFTTestBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFTTestBack.Data.Repository
{
    public class OrderDishRepository : IOrderDishRepository
    {
        private GFTTestContext _context;

        public OrderDishRepository(GFTTestContext context)
        {
            _context = context;
        }

        public virtual async Task Add(OrderDish orderDish)
        {
            _context.Add(orderDish);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<OrderDish>> GetOrderDishesByOrderID(Guid orderId)
        {
            return await _context.OrderedDishes                
                .Include(od => od.dish)
                .OrderBy(od => od.dish.DishType)
                .Where(od => od.OrderId == orderId).ToListAsync();
        }
    }
}
