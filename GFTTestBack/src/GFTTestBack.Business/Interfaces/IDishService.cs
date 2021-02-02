using GFTTestBack.Business.Models;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Interfaces
{
    public interface IDishService
    {
        Task<bool> Add(Dish dish);
        void DishSeed();
    }
}
