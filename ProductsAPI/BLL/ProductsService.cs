using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsAPI.Data;

namespace ProductsAPI.BLL
{
    public class ProductsService
    {
        private readonly IMongoCollection<Product> products;

        public ProductsService(IOptions<ProductsDatabaseSettings> options )
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            products = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Product>(options.Value.ProductsCollectionName);
        }

        public async Task<List<Product>> GetAsync() =>
        await products.Find(prd => true).ToListAsync();

        public async Task<Product> GetAsync(int id) =>
            await products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product product) =>
            await products.InsertOneAsync(product);

        public async Task UpdateAsync(int id, Product updatedProduct) =>
            await products.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        public async Task RemoveAsync(int id) =>
            await products.DeleteOneAsync(x => x.Id == id);
    }
}
