using ApiLibrary.Models;

namespace ApiLibrary.Services.Interfaces
{
    public interface IOrderService
    {
        bool AddProductsToOrder(Guid orderId, List<int> productIds);
        void AddTestOrder(Guid id);
        Order CreateOrder();
        Order GetOrderById(Guid id);
        List<Product> GetOrderProducts(Guid orderId);
        bool TryUpdateOrderStatus(Guid id, OrderStatus newStatus);
    }

}
