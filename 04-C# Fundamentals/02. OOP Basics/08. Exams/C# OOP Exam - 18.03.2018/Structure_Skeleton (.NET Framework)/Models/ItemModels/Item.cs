using DungeonsAndCodeWizards.Models.CharacterModels;
using System;

namespace DungeonsAndCodeWizards.Models.ItemModels
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
