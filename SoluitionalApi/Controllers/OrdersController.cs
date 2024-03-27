using ApiLibrary.Models;
using ApiLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SoluitionalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder()
        {
            return Ok(_orderService.CreateOrder());
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(Guid orderId)
        {
            try
            {
                var order = _orderService.GetOrderById(orderId);
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{orderId}")]
        public IActionResult UpdateOrderStatus(Guid orderId, [FromBody] OrderStatusUpdateModel model)
        {
            var updated = _orderService.TryUpdateOrderStatus(orderId, model.Status);

            if (!updated)
            {
                return NotFound("Not found.");
            }

            return Ok();
        }

        [HttpGet("{orderId}/products")]
        public ActionResult<IEnumerable<Product>> GetOrderProducts(Guid orderId)
        {
            var products = _orderService.GetOrderProducts(orderId);
            if (products.Count == 0)
            {
                var orderExists = _orderService.GetOrderById(orderId) != null;
                if (!orderExists)
                {
                    return NotFound("Not found.");
                }
            }

            return Ok(products);
        }

        [HttpPost("{orderId}/products")]
        public IActionResult AddProductsToOrder(Guid orderId, [FromBody] List<int> productIds)
        {
            if (productIds == null || productIds.Count == 0)
            {
                return BadRequest("Product IDs cannot be empty.");
            }

            var success = _orderService.AddProductsToOrder(orderId, productIds);

            if (!success)
            {
                return NotFound($"Not found.");
            }

            return Ok();
        }

    }
}
