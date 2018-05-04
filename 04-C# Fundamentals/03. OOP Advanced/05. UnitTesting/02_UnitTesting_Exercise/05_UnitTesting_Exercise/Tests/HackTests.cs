namespace Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class HackTests
    {
        //Static classes can't be mocked
        [Test]
        public void MathAbsMethodReturnsValidNumber()
        {
            Assert.That(Math.Abs(-4), Is.EqualTo(4));
        }

        [Test]
        public void MathFloorReturnsValidNumber()
        {
            Assert.That(Math.Floor(2.999), Is.EqualTo(2));
        }
    }
}
