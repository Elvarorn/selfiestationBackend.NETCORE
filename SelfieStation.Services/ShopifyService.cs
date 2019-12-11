using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopifySharp;

namespace SelfieStation.Services
{
    public class ShopifyService : IShopifyService
    {

        private OrderService _orderService;
        private ShopService _shopService;
        private string accessToken;

        public ShopifyService()
        {
            init();
        }
        private async void init()
        {
            var code = "e9c4657361f4d513f061c5fd1317fc20";
            var shopifyUrl = "selfiestationtest.myshopify.com";
            var apiKey = "02289e78a311d176581ef945f0e7c2f4";
            var secretKey = "8c909ef6b001d63a4d3a6e5b18c849c3";

            try
            {
                accessToken = await GetShopifyAccessToken(code, shopifyUrl, apiKey, secretKey);
                _shopService = new ShopService(shopifyUrl, accessToken);
                _orderService = new OrderService(shopifyUrl, accessToken);
            }
            catch (Exception ex) { System.Console.WriteLine(ex.Message); }


            //var service = new ShopifySharp.OrderService("mydomain.myshopify.com", "PRIVATE APP PASSWORD HERE");

            //var order = await service.GetAsync(orderId);
            //var order = await service.UpdateAsync(orderId, new Order()
            //    {
            //Notes = "test notes."
            //});
        }

        private async Task<string> GetShopifyAccessToken(string code, string shopifyUrl, string apiKey, string secretKey)
        {
            string accessToken = await AuthorizationService.Authorize(code, shopifyUrl, apiKey, secretKey);
            return accessToken;
        }

        public async Task<IEnumerable<Order>> getAllOrders()
        {
            if (!String.IsNullOrEmpty(accessToken))
            {
                IEnumerable<Order> orders = await _orderService.ListAsync();
                return orders;
            }
            return null;
        }
    }
}