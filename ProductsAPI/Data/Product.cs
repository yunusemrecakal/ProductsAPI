using MongoDB.Bson.Serialization.Attributes;

namespace ProductsAPI.Data
{
    public class Product
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
