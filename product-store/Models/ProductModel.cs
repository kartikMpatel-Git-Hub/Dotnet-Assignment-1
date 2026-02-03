namespace product_store.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public int Qty { get; set; }
        public String Category { get; set; }
        public String Brand { get; set; }

    }
}
