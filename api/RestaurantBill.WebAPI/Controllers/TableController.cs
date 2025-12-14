using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Application.DTOs;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Domain.Entities;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IGenericRepository<Table> _repository;

        public TableController(IGenericRepository<Table> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await _repository.GetAllAsync();
            return Ok(tables);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateTableDto tableDto)
        {
            var tableEntity = new Table
            {
                TableName = tableDto.TableName,
            };
            await _repository.AddAsync(tableEntity);
            return Ok(tableEntity);
        }
    }
}