using Industrial.API.DTO;
using Industrial.API.Entity;

namespace Industrial.API.Services.Abstract
{
    public interface IProductService
    {
        Task<CreateProductDTO> CreateProduct(CreateProductDTO product);

        Task<EditProductDTO> UpdateProduct(EditProductDTO product);

        Task<bool> DeleteProduct(int id);

        Task<Product> GetProductById(int id);

        Task<Product> GetProductByName(string name);

        Task<ServiceResponse<List<Product>>> GetAllProdutcs();
    }
}
