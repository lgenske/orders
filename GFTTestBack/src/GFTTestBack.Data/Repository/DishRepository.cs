using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using GFTTestBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GFTTestBack.Data.Repository
{
    public class DishRepository : IDishRepository
    {
        private GFTTestContext _context;

        public DishRepository(GFTTestContext context)
        {
            _context = context;
        }

        public virtual async Task Add(Dish dish)
        {
            _context.Add(dish);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<Dish> GetByDishType(string dayTime, int dishType)
        {
            return await _context.Set<Dish>()
                .FirstOrDefaultAsync(d => d.DishType == dishType && d.DayTime == dayTime);
        }
    }
}
