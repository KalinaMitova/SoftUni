namespace _03_ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person()
        {
            this.products = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> Products
        {
            get
            {
                return this.products.AsReadOnly();
            }
        }

        public void PurchaseItem(Product product)
        {
            if(this.money < product.Price)
            {
                throw new ArgumentException($"{this.name} can't afford {product.Name}");
            }

            this.products.Add(product);
            this.money -= product.Price;
        }
    }
}
