using Industrial.API.DTO;
using Industrial.API.Entity;

namespace Industrial.API.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category);

        Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category);

        Task<bool> DeleteCategory(int id);

        Task<Category> GetCategoryById(int id);

        Task<Category> GetCategoryByName(string name);

        Task<ServiceResponse<List<Category>>> GetAllCategories();
    }
}
