using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.CharacterModels;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int lastSurviverRounds = 0;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string factionInput = args[0];
            string characterType = args[1];
            string name = args[2];

            CharacterFactory characterFactory = new CharacterFactory();

            Character character = characterFactory.CreateCharacter(factionInput, characterType, name);

            this.characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            ItemFactory itemFactory = new ItemFactory();

            Item item = itemFactory.CreateItem(itemName);

            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = GetCharacter(characterName);

            if (this.items.Count() == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.items.Pop();

            character.Bag.AddItem(item);
            
            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);

            Item item = character.Bag.GetItem(itemName);
            
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);

            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);

            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            
            var orderedCharacters = this.characters.OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            foreach (var c in orderedCharacters)
            {
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {(c.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = GetCharacter(attackerName);

            Character receiver = GetCharacter(receiverName);
            
            if(!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            ((IAttackable)attacker).Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = GetCharacter(healerName);

            Character healingReceiver = GetCharacter(healingReceiverName);

            if(!(healer is IHealable))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            ((IHealable)healer).Heal(healingReceiver);

            return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var alivedCharacters = this.characters.Where(c => c.IsAlive == true).ToList();

            foreach (var c in alivedCharacters)
            {
                var healthBeforeRest = c.Health;
                c.Rest();
                sb.AppendLine($"{c.Name} rests ({healthBeforeRest} => {c.Health})");
            }

            if (alivedCharacters.Count <= 1)
            {
                this.lastSurviverRounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if(this.lastSurviverRounds > 1)
            {
                return true;
            }
            return false;
        }
        
        private Character GetCharacter(string characterName)
        {
            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
