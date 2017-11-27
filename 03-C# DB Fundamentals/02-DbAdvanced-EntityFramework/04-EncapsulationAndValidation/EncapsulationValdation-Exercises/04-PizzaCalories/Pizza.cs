namespace _04_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name)
            :this()
        {
            this.Name = name;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public IReadOnlyList<Topping> Toppings
        {
            get
            {
                return this.toppings.AsReadOnly();
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }
                
        public void AddToppig(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            double totalCalories = this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
            return totalCalories;
        }
    }
}
