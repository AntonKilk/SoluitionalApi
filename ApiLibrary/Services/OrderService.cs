using ApiLibrary.Models;
using ApiLibrary.Services.Interfaces;

namespace ApiLibrary.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;
        private readonly IProductService _productService;

        public OrderService(IProductService productService)
        {
            _orders = new List<Order>();
            _productService = productService;
        }

        //testc order
        public void AddTestOrder(Guid id)
        {
            var testOrder = new Order
            {
                Id = id,
                Status = OrderStatus.Paid,
                Products = new List<Product>
                    {
                        new Product { Id = 123, Name = "Ketchup", Price = 0.45M }
                    },
                Amount = new OrderAmount
                {
                    Discount = 32.00M,
                    Paid = 0.45M,
                    Returns = 12.00M,
                    Total = 0.45M
                }
            };

            _orders.Add(testOrder);
        }

        public Order CreateOrder()
        {
            var newOrder = new Order();
            _orders.Add(newOrder);
            return newOrder;
        }

        public Order GetOrderById(Guid id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            //if (order == null)
            //{
            //    throw new InvalidOperationException("Not found.");
            //}
            return order;
        }

        public bool TryUpdateOrderStatus(Guid id, OrderStatus newStatus)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.Status = newStatus;
                return true;
            }
            return false;
        }

        public List<Product> GetOrderProducts(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            return order?.Products ?? new List<Product>();
        }

        public bool AddProductsToOrder(Guid orderId, List<int> productIds)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                return false;
            }

            foreach (var productId in productIds)
            {
                var product = _productService.GetProductById(productId);
                if (product != null)
                {
                    order.Products.Add(product);
                }
            }

            return true;
        }

    }
}
