using FoodVilla.API.Data;
using FoodVilla.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodVilla.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodVillaDBContext _foodVillaDBContext;
        public CategoryRepository(FoodVillaDBContext foodVillaDB)
        {
            _foodVillaDBContext = foodVillaDB;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = await _foodVillaDBContext.Categories.ToListAsync();
            return categories;
        }
    }
}
