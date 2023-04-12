using FoodVilla.API.Models;
using FoodVilla.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodVilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCategories()
        {
           List<Category> categoryInfo = (List<Category>)await _categoryRepository.GetCategories();
           return Ok(categoryInfo);
        }
    }
}
