using Dota2_Shop.Models;

namespace Dota2_Shop.Date.Services
{
    public interface IOrdersServer
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
