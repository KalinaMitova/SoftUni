using DungeonsAndCodeWizards.Models.CharacterModels;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
