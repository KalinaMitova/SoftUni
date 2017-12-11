namespace ProductsShopSystem.Data.Models
{
    public class CategoryProduct
    {
        public int CategotyId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
