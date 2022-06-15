//using Microsoft.Extensions.Caching.Distributed;
//using Newtonsoft.Json;
//using ProductsAPI.Data;
//using ProductsAPI.Repositories.Abstract;

//namespace ProductsAPI.Repositories.Concrete
//{
//    public class BasketRepository : IBasketRepository
//    {
//        private readonly IDistributedCache _redisCache;
//        public BasketRepository(IDistributedCache cache)
//        {
//            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
//        }

//        public async Task<ShoppingCart> GetBasket(string userName)
//        {
//            var basket = await _redisCache.GetStringAsync(userName);
//            if (String.IsNullOrEmpty(basket))
//                return null;
//            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
//        }

//        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
//        {
//            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

//            return await GetBasket(basket.UserName);
//        }
//        public async Task DeleteBasket(string userName)
//        {
//            await _redisCache.RemoveAsync(userName);
//        }

//        Task<bool> IBasketRepository.DeleteBasket(string userName)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

