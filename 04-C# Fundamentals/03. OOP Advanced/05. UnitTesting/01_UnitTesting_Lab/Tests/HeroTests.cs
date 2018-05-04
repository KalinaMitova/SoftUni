using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Tests
{
    public class HeroTests
    {
        //Test if hero gains XP when target dies
        [Test]
        public void HeroGainsExperienceIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            fakeWeapon.Setup(w => w.AttackPoints).Returns(10);
            fakeWeapon.Setup(w => w.DurabilityPoints).Returns(10);
            Hero hero = new Hero("Pesho", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}
