using ApiLibrary.Models;
using ApiLibrary.Services.Interfaces;

namespace ApiLibrary.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
        {
            new Product { Id = 123, Name = "Ketchup", Price = 0.45M },
            new Product { Id = 456, Name = "Beer", Price = 2.33M },
            new Product { Id = 879, Name = "Õllesnäkk", Price = 0.42M },
            new Product { Id = 999, Name = "75\" OLED TV", Price = 1333.37M }
        };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            try
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Product not found", ex);
            }
        }

    }

}
