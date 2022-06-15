using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsAPI.Data
{
    public class ProductInBasket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
