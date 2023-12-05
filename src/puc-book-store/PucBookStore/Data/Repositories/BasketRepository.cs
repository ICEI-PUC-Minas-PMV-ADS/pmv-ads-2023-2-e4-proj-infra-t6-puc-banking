using Microsoft.Extensions.Caching.Distributed;
using PucBookStore.Models;
using System.Text.Json;

namespace PucBookStore.Data.Repositories {
    public class BasketRepository {

        private readonly IDistributedCache _cache;
        public BasketRepository(IDistributedCache cache) {
            _cache = cache;
        }
        public async Task<bool> AddBasket(Basket basket) {
 
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(2));

            var dataToCache = JsonSerializer.Serialize(basket);
            await _cache.SetStringAsync(basket.Username, dataToCache, options);
            return true;
        }
        public async Task<bool> UpdateBasketAsync(Basket basket) {
            return await AddBasket(basket);
        }
        public async Task<Basket> GetBasket(string username) {

            var data = await _cache.GetStringAsync(username);

            if (string.IsNullOrEmpty(data)) {
                return null;
            }

            return JsonSerializer.Deserialize<Basket>(data);
        }
    }
}
