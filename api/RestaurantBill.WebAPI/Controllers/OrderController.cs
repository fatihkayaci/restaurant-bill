using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Application.DTOs;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Domain.Entities;
using RestaurantBill.Domain.Enums;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericRepository<Order> _repository;

        public OrderController(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _repository.GetAllAsync();
            return Ok(orders);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto orderDto)
        {
            var orderEntity = new Order
            {
                TableId = orderDto.TableId,
                TotalAmount = 0,
                Status = OrderStatus.Active,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(orderEntity);
            return Ok(orderEntity);
        }
    }
}