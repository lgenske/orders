using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using System;
using System.Threading.Tasks;

namespace GFTTestBack.Business.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;

		public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<bool> Add(Dish dish)
        {
            await _dishRepository.Add(dish);
            return true;
        }

        public async void DishSeed()
        {
			Dish egg = new Dish
			{
				Name = "Eggs",
				DishType = 1,
				DayTime = "morning",
				OrderMany = false
			};
			await Add(egg);

			Dish toast = new Dish
			{
				Name = "Toast",
				DishType = 2,
				DayTime = "morning",
				OrderMany = false
			};
			await Add(toast);

			Dish coffee = new Dish
			{
				Name = "Coffee",
				DishType = 3,
				DayTime = "morning",
				OrderMany = true
			};
			await Add(coffee);

			Dish errorm = new Dish
			{
				Name = "Error",
				DishType = 99,
				DayTime = "morning",
				OrderMany = false
			};
			await Add(errorm);

			Dish steak = new Dish
			{
				Name = "Steak",
				DishType = 1,
				DayTime = "night",
				OrderMany = false
			};
			await Add(steak);

			Dish potato = new Dish
			{
				Name = "Potato",
				DishType = 2,
				DayTime = "night",
				OrderMany = true
			};
			await Add(potato);

			Dish wine = new Dish
			{
				Name = "Wine",
				DishType = 3,
				DayTime = "night",
				OrderMany = false
			};
			await Add(wine);

			Dish cake = new Dish
			{
				Name = "Cake",
				DishType = 4,
				DayTime = "night",
				OrderMany = false
			};
			await Add(cake);

			Dish errorn = new Dish
			{
				Name = "Error",
				DishType = 99,
				DayTime = "night",
				OrderMany = false
			};
			await Add(errorn);		
		}
    }
}
