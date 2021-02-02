using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Interfaces
{
    public interface IOrderService
    {
        Task<string> Add(string rawOrder);
        Task<List<string>> GetRawOrderResponseList();
    }
}
