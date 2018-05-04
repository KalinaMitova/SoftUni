namespace Tests
{
    using _04_BubbleSort;

    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        [TestCase(new int[] { 5, 9, 3, 2, 1, 5, 7, 8, 9, 4 })]
        [TestCase(new int[] { 5 })]
        [TestCase(new int[] {  })]
        public void BubbleSortIntegerTest(int[] numbers)
        {
            Bubble<int> bubble = new Bubble<int>();
            
            int[] sortedNumbers = bubble.Sort(numbers);

            Array.Sort(numbers);

            Assert.That(sortedNumbers, Is.EquivalentTo(numbers));
        }

        [Test]
        public void BubbleSortStringTest()
        {

            Bubble<string> bubble = new Bubble<string>();

            string[] names = new string[] { "Gosho", "Aleksandar", "Dimitar", "Ivan", "Yasen", "Dragomir" };

            string[] sortedNames = bubble.Sort(names);

            string[] expectedNames = new string[] { "Aleksandar", "Dimitar", "Dragomir", "Gosho", "Ivan", "Yasen" };

            Assert.That(sortedNames, Is.EquivalentTo(expectedNames));
        }
    }
}
