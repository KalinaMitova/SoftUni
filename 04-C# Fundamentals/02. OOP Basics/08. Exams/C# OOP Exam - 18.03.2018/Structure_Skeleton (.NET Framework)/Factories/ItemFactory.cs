using DungeonsAndCodeWizards.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            if(type == nameof(ArmorRepairKit))
            {
                return new ArmorRepairKit();
            }
            else if(type == nameof(HealthPotion))
            {
                return new HealthPotion();
            }
            else if(type == nameof(PoisonPotion))
            {
                return new PoisonPotion();
            }

            throw new ArgumentException($"Invalid item \"{type}\"!");
        }
    }
}
