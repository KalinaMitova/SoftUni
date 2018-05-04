using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndCodeWizards.Models.BagModels;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.CharacterModels
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name,Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double BaseHealth => 50;

        public override double BaseArmor => 25;

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckIsAlive(this);
            this.CheckIsAlive(character);

            if(character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
