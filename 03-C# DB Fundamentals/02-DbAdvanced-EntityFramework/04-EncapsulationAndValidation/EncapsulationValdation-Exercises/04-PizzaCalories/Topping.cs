namespace _04_PizzaCalories
{
    using System;

    class Topping
    {
        private const int caloriesPerGram = 2;
        private const double meatModifier = 1.2d;
        private const double veggiesModifier = 0.8d;
        private const double cheeseModifier = 1.1d;
        private const double sauceModifier = 0.9d;

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && 
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingModifier = 0d;

            switch (this.toppingType.ToLower())
            {
                case "meat": toppingModifier = meatModifier; break;
                case "veggies": toppingModifier = veggiesModifier; break;
                case "cheese": toppingModifier = cheeseModifier; break;
                case "sauce": toppingModifier = sauceModifier; break;
            }

            double calories = (caloriesPerGram * weight) * toppingModifier;

            return calories;
        }
    }
}
