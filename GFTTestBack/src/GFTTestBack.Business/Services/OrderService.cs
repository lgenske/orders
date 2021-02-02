using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IOrderDishRepository _orderDishRepository;

        public OrderService(IOrderRepository orderRepository, 
                            IDishRepository dishRepository, 
                            IOrderDishRepository orderDishRepository)
        {
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _orderDishRepository = orderDishRepository;
        }

        public async Task<string> Add(string rawOrder)
        {
            if (string.IsNullOrEmpty(rawOrder)) return null; 

            string dayTime = GetDayTime(rawOrder);
            if (string.IsNullOrEmpty(dayTime)) return null;

            rawOrder = GetCleanOrder(rawOrder);
            if (string.IsNullOrEmpty(rawOrder)) return null;

            List<int> orderList = rawOrder.Split().Select(Int32.Parse).ToList();
            orderList.Sort();

            Order order = new Order { DayTime = dayTime };
            await _orderRepository.Add(order);

            int lastDishType = 0;
            foreach (int dishType in orderList)
            {
                bool haveError = false;

                Dish dish = await _dishRepository.GetByDishType(dayTime, dishType);
                if (dish == null)
                {
                    dish = await _dishRepository.GetByDishType(dayTime, 99);
                    haveError = true;
                } else 
                if ((lastDishType == dishType) && !dish.OrderMany) {
                    dish = await _dishRepository.GetByDishType(dayTime, 99);
                    haveError = true;
                }

                lastDishType = dishType;                

                OrderDish orderDish = new OrderDish();
                orderDish.order = order;
                orderDish.dish = dish;

                await _orderDishRepository.Add(orderDish);

                if (haveError) { break; };
            }            
            
            return await GetRawOrderLine(order);
        }

        public async Task<List<string>> GetRawOrderResponseList()
        {
            List<string> rawOrders = new List<string>();
            List<Order> orders = await _orderRepository.GetOrders();

            foreach (Order order in orders)
            {
                rawOrders.Add(await GetRawOrderLine(order));
            }

            return rawOrders;
        }

        private string GetDayTime(string rawOrder)
        {
            rawOrder = rawOrder.ToLower();

            if (rawOrder.Contains("morning"))
                return "morning";
            else if (rawOrder.Contains("night"))
                return "night";
            else return "";
        }

        private string GetCleanOrder(string rawOrder)
        {
            var remove = "qwertyuiopasdfghjklçzxcvbnm ";
            for (int i = 0; i < remove.Length; i++)
            {
                rawOrder = rawOrder.Replace(remove[i].ToString(), "");
            }

            return (rawOrder.Replace(",", " ").Trim());
        }

        private async Task<string> GetRawOrderLine(Order order, string rawOrderLine = "", string lastDishName = "", int lastDishCount = 1)
        {
            List<OrderDish> orderedDishes = await _orderDishRepository.GetOrderDishesByOrderID(order.Id);
            foreach (OrderDish orderDish in orderedDishes)
            {
                if (lastDishName == orderDish.dish.Name)
                {
                    lastDishCount++;
                }
                else
                {
                    if (lastDishCount > 1)
                    {
                        rawOrderLine += "(x" + lastDishCount + ")";
                        lastDishCount = 1;
                        rawOrderLine += rawOrderLine == "" ? orderDish.dish.Name : ", " + orderDish.dish.Name;
                    }
                    else
                    {
                        rawOrderLine += rawOrderLine == "" ? orderDish.dish.Name : ", " + orderDish.dish.Name;
                    }
                }                    

                lastDishName = orderDish.dish.Name;
                if ((orderedDishes.IndexOf(orderDish) == orderedDishes.Count - 1) && (lastDishCount > 1))
                {
                    rawOrderLine += "(x" + lastDishCount + ")";
                    lastDishCount = 1;
                }
            }
            return rawOrderLine;
        }
    }
}
