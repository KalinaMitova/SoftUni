namespace BashSoftTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BashSoftProgram.DataStructures;
    using BashSoftProgram.DataStructures.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            string[] elementsToAdd = new string[] { "Rosen", "Georgi", "Balkan" };

            foreach (var element in elementsToAdd)
            {
                this.names.Add(element);
            }

            string[] expectedElements = new string[] { "Balkan", "Georgi", "Rosen" };
            CollectionAssert.AreEquivalent(this.names.ToArray(), expectedElements);
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            string[] someElements = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q" };

            foreach (var element in someElements)
            {
                this.names.Add(element);
            }
            
            Assert.AreEqual(this.names.Size, 17);
            Assert.AreNotEqual(this.names.Capacity, 16);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> elements = new List<string>() { "Ivan", "Pesho" };

            this.names.AddAll(elements);

            Assert.AreEqual(this.names.Size, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllNullThrowsException()
        {
            this.names.AddAll(null);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            string[] elementsToAdd = new string[] { "Rosen", "Georgi", "Balkan" };
            this.names.AddAll(elementsToAdd);

            string[] expectedElements = new string[] { "Balkan", "Georgi", "Rosen" };
            CollectionAssert.AreEquivalent(this.names.ToArray(), expectedElements);
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("SomeElement");
            this.names.Remove("SomeElement");
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.AddAll(new string[] { "Ivan", "Nasko" });
            this.names.Remove("Ivan");
            string[] expectedElements = new string[] { "Nasko" };
            CollectionAssert.AreEquivalent(this.names.ToArray(), expectedElements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            this.names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            this.names.AddAll(new string[] { "Ivan", "Nasko" });
            string joinedString = this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            this.names.AddAll(new string[] { "Ivan", "Nasko" });
            string joinedString = this.names.JoinWith(", ");
            Assert.AreEqual(joinedString, "Ivan, Nasko");
        }
    }
}
