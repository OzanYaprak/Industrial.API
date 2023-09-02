using AutoMapper;
using Industrial.API.DTO;
using Industrial.API.Entity;

namespace Industrial.API.MappingProfile
{
    public class Mapper : Profile
    {
        public Mapper() 
        { 
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, EditCategoryDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, EditProductDTO>().ReverseMap();
        }
    }
}
