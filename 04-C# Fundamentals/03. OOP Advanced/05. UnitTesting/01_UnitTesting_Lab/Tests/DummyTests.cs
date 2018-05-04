using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            int axeAttackPoints = 10;
            int axeDurabilityPoints = 10;
            Axe axe = new Axe(axeAttackPoints, axeDurabilityPoints);

            int dummyHealth = 10;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            axe.Attack(dummy);

            int expected = 0;
            Assert.That(dummy.Health, Is.EqualTo(expected));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            int axeAttackPoints = 10;
            int axeDurabilityPoints = 10;
            Axe axe = new Axe(axeAttackPoints, axeDurabilityPoints);

            int dummyHealth = 0;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            string expectedMessage = "Dummy is dead.";
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException
                .With
                .Message
                .EqualTo(expectedMessage));
        }

        [Test]
        public void DeadDummyGiveExperienceIfDead()
        {
            int dummyHealth = 0;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            int expected = 10;
            Assert.That(dummy.GiveExperience(),
                Is.EqualTo(expected));
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            int dummyHealth = 10;
            int dummyExperience = 10;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);
            
            string expectedMessage = "Target is not dead.";
            Assert.That(() => dummy.GiveExperience(),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo(expectedMessage));
        }
    }
}
