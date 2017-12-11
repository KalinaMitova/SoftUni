namespace ProductsShopSystem
{
    using System.Collections.Generic;

    using ProductsShopSystem.Data.Models;

    public class User
    {
        public User()
        {
            this.BoughtProducts = new HashSet<Product>();
            this.SoldProducts = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public HashSet<Product> BoughtProducts { get; set; }

        public HashSet<Product> SoldProducts { get; set; }
    }
}
