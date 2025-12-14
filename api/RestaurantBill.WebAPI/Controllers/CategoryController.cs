using Microsoft.AspNetCore.Mvc;
using RestaurantBill.Application.DTOs;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Domain.Entities;

namespace RestaurantBill.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryController(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(categories);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var categoryEntity = new Category
            {
                Name = categoryDto.Name
            };
            await _repository.AddAsync(categoryEntity);
            return Ok(categoryDto);
        }
    }
}