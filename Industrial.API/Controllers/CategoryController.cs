using Industrial.API.DTO;
using Industrial.API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Industrial.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCategoryByID(int id)
        {
            var result = _categoryService.GetCategoryById(id);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);

            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategory)
        {
           var addedCategory = _categoryService.CreateCategory(createCategory);

            //var categories = _categoryService.GetAllCategories();

            return Ok(addedCategory);
        }

        [HttpPut]
        public IActionResult UpdateCategory(EditCategoryDTO editCategory)
        {
            _categoryService.UpdateCategory(editCategory);

            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }
    }
}