using DungeonsAndCodeWizards.Models.CharacterModels;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
