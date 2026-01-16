using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Core.Interfaces;
using RestaurantBill.Core.DTOs;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _tableService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateTableDto tableDto)
        {
            await _tableService.AddAsync(tableDto);
            return Ok("masa başarıyla eklendi");
        }
    }
}
