using DungeonsAndCodeWizards.Models.CharacterModels;

namespace DungeonsAndCodeWizards.Models.ItemModels
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() : base(10) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}
