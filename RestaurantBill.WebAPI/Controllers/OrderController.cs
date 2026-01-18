using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Core.Interfaces;
using RestaurantBill.Core.DTOs;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _orderService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderDto orderDto)
        {
            await _orderService.AddAsync(orderDto);
            return Ok("Order başarıyla eklendi");
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            // Senin yazdığın o özel metodu çağırıyoruz
            var response = await _orderService.GetOrderDetailsAsync(id);
            
            // Sonucu JSON olarak React'e dönüyoruz
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderService.DeleteOrderDetailAsync(id);
            return Ok("Order item başarıyla silindi");
        }
        [HttpPost("close-order/{id}")]
        public async Task<IActionResult> CloseOrder(int id)
        {
            await _orderService.CloseOrderAsync(id);
            return Ok("işlem başarıyla tamamlandı.");
        }
        
    }
}
