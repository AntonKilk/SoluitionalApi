using ApiLibrary.Models;
using ApiLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SoluitionalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_productService.GetAllProducts());
        }

    }
}
