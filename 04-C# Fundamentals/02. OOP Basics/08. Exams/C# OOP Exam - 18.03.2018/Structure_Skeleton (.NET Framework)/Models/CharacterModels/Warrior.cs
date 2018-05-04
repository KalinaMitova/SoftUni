using DungeonsAndCodeWizards.Models.BagModels;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;
using System;

namespace DungeonsAndCodeWizards.Models.CharacterModels
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, 100, 50, 40, new Satchel(), faction) { }

        public override double BaseHealth => 100;

        public override double BaseArmor => 50;

        public void Attack(Character character)
        {
            this.CheckIsAlive(this);
            this.CheckIsAlive(character);

            if(character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if(this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
