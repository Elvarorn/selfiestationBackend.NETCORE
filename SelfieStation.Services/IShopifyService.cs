using System.Collections.Generic;
using System.Threading.Tasks;
using ShopifySharp;

namespace SelfieStation.Services
{
    public interface IShopifyService
    {
        Task<IEnumerable<Order>> getAllOrders();
    }
}