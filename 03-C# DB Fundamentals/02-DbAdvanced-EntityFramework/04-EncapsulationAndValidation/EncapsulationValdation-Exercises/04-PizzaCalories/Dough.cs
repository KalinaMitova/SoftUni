namespace _04_PizzaCalories
{
    using System;

    class Dough
    {
        private const int caloriesPerGram = 2;
        private const double whiteModifier = 1.5d;
        private const double wholegrainModifier = 1d;
        private const double crispyModifier = 0.9d;
        private const double chewyModifier = 1.1d;
        private const double homemadeModifier = 1d;

        private string flourType;
        private string bakingTechnique;
        private int weight;
        
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
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
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourModifier = 0d;
            double bakingModifier = 0d;

            switch (this.FlourType.ToLower())
            {
                case "white": flourModifier = whiteModifier; break;
                case "wholegrain": flourModifier = wholegrainModifier; break;
            }

            switch (this.bakingTechnique.ToLower())
            {
                case "crispy": bakingModifier = crispyModifier; break;
                case "chewy": bakingModifier = chewyModifier; break;
                case "homemade": bakingModifier = homemadeModifier; break;
            }

            double calories = (caloriesPerGram * weight) * flourModifier * bakingModifier;

            return calories;
        }
    }
}
