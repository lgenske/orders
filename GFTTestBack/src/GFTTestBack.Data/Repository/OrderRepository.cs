using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using GFTTestBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFTTestBack.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private GFTTestContext _context;

        public OrderRepository(GFTTestContext context) 
        {
            _context = context;
        }

        public virtual async Task Add(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .OrderByDescending(c => c.OrderTime)
                .Include(c => c.OrderedDishes).ToListAsync();
        }
    }
}
