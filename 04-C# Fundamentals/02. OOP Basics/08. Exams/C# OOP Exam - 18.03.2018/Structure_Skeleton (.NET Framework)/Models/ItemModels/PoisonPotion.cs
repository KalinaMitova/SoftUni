using DungeonsAndCodeWizards.Models.CharacterModels;
using System;

namespace DungeonsAndCodeWizards.Models.ItemModels
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() : base(5) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            
            character.Health -= 20;
        }
    }
}
