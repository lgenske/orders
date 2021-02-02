using GFTTestBack.Api.Dtos;
using GFTTestBack.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTestBack.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<OrderListDto> GetOrderDishes()
        {
            OrderListDto orderListDto = new OrderListDto();
            orderListDto.RawOrderResponseList = await _orderService.GetRawOrderResponseList();
  
            return orderListDto;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderResponseDto>> Add(CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            CreateOrderResponseDto createOrderResponseDto = new CreateOrderResponseDto();
            createOrderResponseDto.RawOrderResponse = await _orderService.Add(createOrderDto.RawOrder);

            if (createOrderResponseDto.RawOrderResponse == null) return BadRequest();     

            return Ok(createOrderResponseDto);        
        }
    }
}
