namespace ProductsShopSystem.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        public int SellerId { get; set; }

        public User Seller { get; set; }

        public HashSet<CategoryProduct> Categories { get; set; }
    }
}
