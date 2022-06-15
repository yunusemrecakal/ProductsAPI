namespace ProductsAPI.Data
{
    public class Basket
    {
        public Basket()
        {
            Products = new HashSet<ProductInBasket>();
        }
        public string Id { get; set; }
        public IEnumerable<ProductInBasket> Products { get; set; }
    }
}
