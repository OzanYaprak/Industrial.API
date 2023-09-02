using AutoMapper;
using Industrial.API.Data;
using Industrial.API.DTO;
using Industrial.API.Entity;
using Industrial.API.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Industrial.API.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IndustrialDBContext _dBContext;
        private readonly IMapper _mapper;

        public CategoryService(IndustrialDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }




        public async Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category)
        {
            var map = _mapper.Map<CreateCategoryDTO, Category>(category);

            map.CreatedDate = DateTime.Now;

            var addedObject = _dBContext.Categories.AddAsync(map);

            var response = _mapper.Map<Category, CreateCategoryDTO>(addedObject.Result.Entity);

            _dBContext.SaveChanges();

            return response;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = _dBContext.Categories.Find(id);
            if (result == null)
            {
                return false;
            }
            _dBContext.Categories.Remove(result);
            _dBContext.SaveChanges();
            return true;

        }

        public async Task<ServiceResponse<List<Category>>> GetAllCategories()
        {
            var categories = _dBContext.Categories.Include(x => x.Products).ToList();

            ServiceResponse<List<Category>> _category = new ServiceResponse<List<Category>>();

            if (categories != null)
            {
                _category.Data = categories;
                _category.Success = true;
                _category.Message = "Categories Listed";

                return _category;
            }

            return _category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = _dBContext.Categories.FirstOrDefault(x => x.CategoryID == id);

            return result;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var result = _dBContext.Categories.FirstOrDefault(x => x.CategoryName == name);

            return result;
        }

        public async Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category)
        {
            var result = _dBContext.Categories.Find(category.CategoryID);

            if (result != null)
            {
                var map = _mapper.Map<EditCategoryDTO, Category>(category);
                result.CategoryName = map.CategoryName;
                result.CategoryDescription = map.CategoryDescription;
                result.UpdateDate = DateTime.Now;

                var response = _mapper.Map<Category, EditCategoryDTO>(map);

                _dBContext.SaveChanges();

                return response;
            }
            return null;
        }
    }
}