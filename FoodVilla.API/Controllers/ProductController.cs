using FoodVilla.API.Data;
using FoodVilla.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodVilla.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly FoodVillaDBContext _foodVillaDBContext;
        public ProductController(FoodVillaDBContext foodVillaDB) { 
               _foodVillaDBContext = foodVillaDB;
        }

        [HttpGet]
        public  IActionResult GetAllProduct()
        {
            var productList = _foodVillaDBContext.Products;

            if (productList == null)
            {
                return NotFound();
            }

            return Ok(productList);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var productList = await _foodVillaDBContext.Products.FirstOrDefaultAsync(res => res.Id == id);

            if (productList == null)
            {
                return NotFound();
            }

            return Ok(productList);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product) 
        {
            // Scenario 01
            // Product productInfo = new Product();

            if(product == null)
            {
                return BadRequest("Invalid Product Details.");
            }
            

            //productInfo.Name = product.Name;

            // Scenario 02
            var productInfo = new Product()
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedDate = DateTime.Now,
                Quantity = product.Quantity,
                ProductPicture = product.ProductPicture
            };

            _foodVillaDBContext.Products.Add(productInfo);
            await _foodVillaDBContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, [FromRoute] Guid id)
        {
            var productUpdate = new Product()
            {
                Id = id,
                Price = product.Price,
                Quantity = product.Quantity
            };

            _foodVillaDBContext.Products.Update(productUpdate);
            await _foodVillaDBContext.SaveChangesAsync();

            return Ok();
        }




    }
}
