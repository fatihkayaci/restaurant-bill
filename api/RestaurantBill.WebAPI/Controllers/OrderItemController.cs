using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Application.DTOs;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Domain.Entities;
using RestaurantBill.Domain.Enums;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IGenericRepository<OrderItem> _orderItemRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderItemController(
            IGenericRepository<OrderItem> orderItemRepo, 
            IGenericRepository<Product> productRepo, 
            IGenericRepository<Order> orderRepo)
        {
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _orderItemRepo.GetAllAsync();
            return Ok(items);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderItemDto orderItemDto)
        {
            var product = await _productRepo.GetByIdAsync(orderItemDto.ProductId);

            if (product == null)
            {
                return NotFound("Böyle bir ürün yok!");
            }

            var order = await _orderRepo.GetByIdAsync(orderItemDto.OrderId);
            if (order == null)
            {
                return NotFound("Böyle bir sipariş yok!");
            }

            var orderItemEntity = new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.ProductId,
                Quantity = orderItemDto.Quantity,
                UnitPrice = product.Price, 
                ProductName = product.Name,
                Status = OrderItemStatus.Queued,
            };
            await _orderItemRepo.AddAsync(orderItemEntity);

            order.TotalAmount = order.TotalAmount + (orderItemEntity.UnitPrice * orderItemEntity.Quantity);
            await _orderRepo.UpdateAsync(order);
            
            return Ok(orderItemEntity);
        }
    }
}