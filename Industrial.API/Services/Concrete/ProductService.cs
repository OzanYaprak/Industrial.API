using AutoMapper;
using Industrial.API.Data;
using Industrial.API.DTO;
using Industrial.API.Entity;
using Industrial.API.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Industrial.API.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IndustrialDBContext _dBContext;
        private readonly IMapper _mapper;

        public ProductService(IndustrialDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }




        public Task<CreateProductDTO> CreateProduct(CreateProductDTO product)
        {
            var map = _mapper.Map<CreateProductDTO, Product>(product);

            map.CreatedDate = DateTime.Now;

            var addedObject = _dBContext.Products.AddAsync(map);

            var response = _mapper.Map<Product, CreateProductDTO>(addedObject.Result.Entity);

            _dBContext.SaveChanges();

            return response;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = _dBContext.Products.Find(id);
            if (result == null)
            {
                return false;
            }
            _dBContext.Products.Remove(result);
            _dBContext.SaveChanges();
            return true;
        }

        public Task<ServiceResponse<List<Product>>> GetAllProdutcs()
        {
            var products = _dBContext.Products.Include(x => x.Category).ToList();

            ServiceResponse<List<Product>> _products = new ServiceResponse<List<Product>>();

            if (products != null)
            {
                _products.Data = products;
                _products.Success = true;
                _products.Message = "Products Listed";

                return _products;
            }

            return _products;
        }

        public Task<Product> GetProductById(int id)
        {
            var result = _dBContext.Products.FirstOrDefault(x => x.ProductID == id);

            return result;
        }

        public Task<Product> GetProductByName(string name)
        {
            var result = _dBContext.Products.FirstOrDefault(x => x.ProductName == name);

            return result;
        }

        public Task<EditProductDTO> UpdateProduct(EditProductDTO product)
        {
            var result = _dBContext.Products.Find(product.ProductID);

            if (result != null)
            {
                var map = _mapper.Map<EditProductDTO, Product>(product);

                result.ProductName = map.ProductName;
                result.ProductDescription = map.ProductDescription;
                result.ProductPrice = map.ProductPrice;
                result.CategoryID = map.CategoryID;
                result.UpdateDate = DateTime.Now;

                var response = _mapper.Map<Product, EditProductDTO>(map);

                _dBContext.SaveChanges();

                return response;
            }
            return null;
        }
    }
}
