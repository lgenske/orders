using FakeItEasy;
using GFTTestBack.Api.Dtos;
using GFTTestBack.Business.Interfaces;
using GFTTestBack.Business.Models;
using GFTTestBack.Business.Services;
using Xunit;

namespace GFTTestBack.Tests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public async void Add_ShouldReturnNullWhenOrderIsBlank()
        {
            //Arrange
            var fakeOrderRepository = A.Fake<IOrderRepository>();
            var fakeDishRepository = A.Fake<IDishRepository>();
            var fakeOrderDishRepository = A.Fake<IOrderDishRepository>();
            var orderServices = new OrderService(fakeOrderRepository, fakeDishRepository, fakeOrderDishRepository);

            Dish dish = new Dish
            {
                Name = "Eggs",
                DishType = 1,
                DayTime = "morning",
                OrderMany = false
            };

            A.CallTo(() => fakeOrderRepository.Add(A<Order>.Ignored))
                .DoesNothing();

            A.CallTo(() => fakeOrderDishRepository.Add(A<OrderDish>.Ignored))
                .DoesNothing();

            A.CallTo(() => fakeDishRepository.GetByDishType(A<string>.Ignored, A<int>.Ignored))
                .Returns(dish);

            var rawOrder = "";
            string expectedResult = null;

            CreateOrderResponseDto createOrderResponseDto = new CreateOrderResponseDto();

            //Act
            createOrderResponseDto.RawOrderResponse = await orderServices.Add(rawOrder);

            //Assert
            Assert.Equal(expectedResult, createOrderResponseDto.RawOrderResponse);
        }

        [Fact]
        public async void Add_ShouldReturnNullWhenNoDayTime()
        {
            //Arrange
            var fakeOrderRepository = A.Fake<IOrderRepository>();
            var fakeDishRepository = A.Fake<IDishRepository>();
            var fakeOrderDishRepository = A.Fake<IOrderDishRepository>();
            var orderServices = new OrderService(fakeOrderRepository, fakeDishRepository, fakeOrderDishRepository);

            Dish dish = new Dish
            {
                Name = "Eggs",
                DishType = 1,
                DayTime = "morning",
                OrderMany = false
            };

            A.CallTo(() => fakeOrderRepository.Add(A<Order>.Ignored))
                .DoesNothing();

            A.CallTo(() => fakeOrderDishRepository.Add(A<OrderDish>.Ignored))
                .DoesNothing();

            A.CallTo(() => fakeDishRepository.GetByDishType(A<string>.Ignored, A<int>.Ignored))
                .Returns(dish);

            var rawOrder = "1, 2, 3";
            string expectedResult = null;

            CreateOrderResponseDto createOrderResponseDto = new CreateOrderResponseDto();

            //Act
            createOrderResponseDto.RawOrderResponse = await orderServices.Add(rawOrder);

            //Assert
            Assert.Equal(expectedResult, createOrderResponseDto.RawOrderResponse);
        }
    }
}
