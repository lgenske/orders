using GFTTestBack.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Interfaces
{
    public interface IOrderRepository
    {
        Task Add(Order order);

        Task<List<Order>> GetOrders();
    }
}
