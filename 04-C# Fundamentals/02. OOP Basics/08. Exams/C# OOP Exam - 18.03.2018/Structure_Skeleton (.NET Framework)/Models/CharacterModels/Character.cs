using DungeonsAndCodeWizards.Models.BagModels;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Models.CharacterModels
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public abstract double BaseHealth { get; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.isAlive = false;
                }
                else if (value >= this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public abstract double BaseArmor { get; }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value <= 0)
                {
                    this.armor = 0;
                }
                else if (value >= this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        protected virtual double RestHealMultiplier => 0.2d;

        public void TakeDamage(double hitPoints)
        {
            CheckIsAlive(this);

            double restHitPoints = hitPoints - this.Armor;

            this.Armor -= hitPoints;
            if (restHitPoints > 0)
            {
                this.Health -= restHitPoints;
            }
        }

        public void Rest()
        {
            CheckIsAlive(this);

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            CheckIsAlive(this);

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIsAlive(this);
            CheckIsAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIsAlive(this);
            CheckIsAlive(character);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIsAlive(this);

            this.Bag.AddItem(item);
        }
        
        protected void CheckIsAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
