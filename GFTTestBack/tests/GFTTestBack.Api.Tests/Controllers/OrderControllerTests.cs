using FakeItEasy;
using GFTTestBack.Api.Controllers;
using GFTTestBack.Api.Dtos;
using GFTTestBack.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GFTTestBack.Api.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public async void Add_Order_ShouldReturnOk()
        {
            //Arrange
            var fakeOrderService = A.Fake<IOrderService>();

            CreateOrderResponseDto expectedDto = new CreateOrderResponseDto();
            expectedDto.RawOrderResponse = "steak, potato(x2), cake";

            A.CallTo(() => fakeOrderService.Add(A<string>.Ignored))
                .Returns(Task.FromResult(expectedDto.RawOrderResponse));

            var orderController = new OrderController(fakeOrderService);

            CreateOrderDto createOrderDto = new CreateOrderDto();
            createOrderDto.RawOrder = "night, 1, 2, 2, 4";

            //Act            
            var result = await orderController.Add(createOrderDto);
            var okObjectResult = result.Result as OkObjectResult;
            var createOrderResponseDto = okObjectResult.Value as CreateOrderResponseDto;

            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(createOrderResponseDto.RawOrderResponse, expectedDto.RawOrderResponse);
        }

        [Fact]
        public async void GetOrderDishes_ShouldReturnExpectedList()
        {
            //Arrange
            var fakeOrderService = A.Fake<IOrderService>();

            OrderListDto expectedDto = new OrderListDto();
            List<string> dtoList = new List<string>();
            dtoList.Add("eggs, toast, coffee(x3)");
            dtoList.Add("steak, potato, wine, cake");
            expectedDto.RawOrderResponseList = dtoList;

            A.CallTo(() => fakeOrderService.GetRawOrderResponseList())
                .Returns(Task.FromResult(expectedDto.RawOrderResponseList));

            var orderController = new OrderController(fakeOrderService);

            //Act
            var result = await orderController.GetOrderDishes();            
            var responseDto = result as OrderListDto;

            //Assert
            Assert.Equal(responseDto.RawOrderResponseList, expectedDto.RawOrderResponseList);
        }
    }
}
