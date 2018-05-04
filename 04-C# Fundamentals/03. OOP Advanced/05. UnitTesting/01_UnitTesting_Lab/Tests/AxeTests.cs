using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            int axeAttackPoints = 10;
            int axeDurabilityPoints = 10;
            Axe axe = new Axe(axeAttackPoints, axeDurabilityPoints);

            int dummyHealth = 10;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            axe.Attack(dummy);

            int expectedHealth = 9;
            string errorMessage = "Axe Durability doesn't change after attack.";
            
            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedHealth), errorMessage);
        }

        [Test]
        public void BrokenAxeAttacksDummy()
        {
            int axeAttackPoints = 10;
            int axeDurabilityPoints = 1;
            Axe axe = new Axe(axeAttackPoints, axeDurabilityPoints);

            int dummyHealth = 10;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            axe.Attack(dummy);

            string expectedMessage = "Axe is broken.";
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With
                .Message.EqualTo(expectedMessage));
        }
    }
}
