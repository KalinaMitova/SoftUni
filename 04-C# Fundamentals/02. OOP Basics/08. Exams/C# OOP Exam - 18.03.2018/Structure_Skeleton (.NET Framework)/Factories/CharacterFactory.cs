using DungeonsAndCodeWizards.Models.CharacterModels;
using DungeonsAndCodeWizards.Models.Enums;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionInput, string type, string name)
        {
            bool isFaction = Enum.TryParse<Faction>(factionInput, out Faction faction);

            if (!isFaction)
            {
                throw new ArgumentException($"Invalid faction \"{factionInput}\"!");
            }

            if (type == nameof(Warrior))
            {
                return new Warrior(name, faction);
            }
            else if (type == nameof(Cleric))
            {
                return new Cleric(name, faction);
            }

            throw new ArgumentException($"Invalid character type \"{type}\"!");
        }
    }
}
