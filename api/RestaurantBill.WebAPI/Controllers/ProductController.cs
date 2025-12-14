using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Application.DTOs;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Domain.Entities;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            var productEntity = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                IsAvailable = productDto.IsAvailable,
                CategoryId = productDto.CategoryId,
            };
            await _repository.AddAsync(productEntity);
            return Ok(productEntity);
        }
    }
}