using FoodVilla.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodVilla.API.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(); // declaration
    }
}
