using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsAPI.Data;

namespace ProductsAPI.BLL
{
    public class ProductsInBasketService
    {
        private readonly IMongoCollection<ProductInBasket> productsInBasket;
        public ProductsInBasketService(IOptions<ProductsInBasketDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            productsInBasket = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<ProductInBasket>(options.Value.ProductsInBasketCollectionName);
        }

        public async Task<List<ProductInBasket>> GetAsync() =>
        await productsInBasket.Find(prd => true).ToListAsync();

        public async Task<ProductInBasket> GetAsync(string id) =>
            await productsInBasket.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductInBasket product) =>
            await productsInBasket.InsertOneAsync(product);

        public async Task UpdateAsync(string id, ProductInBasket updatedProduct) =>
            await productsInBasket.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        public async Task RemoveAsync(string id) =>
            await productsInBasket.DeleteOneAsync(x => x.Id == id);
    }
}
