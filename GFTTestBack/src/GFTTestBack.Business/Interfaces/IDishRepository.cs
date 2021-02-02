using GFTTestBack.Business.Models;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Interfaces
{
    public interface IDishRepository 
    {
        Task Add(Dish dish);
        Task<Dish> GetByDishType(string dayTime, int dishType);
    }
}
