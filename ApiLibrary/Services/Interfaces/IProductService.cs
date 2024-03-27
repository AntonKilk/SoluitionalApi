using ApiLibrary.Models;

namespace ApiLibrary.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
    }
}
