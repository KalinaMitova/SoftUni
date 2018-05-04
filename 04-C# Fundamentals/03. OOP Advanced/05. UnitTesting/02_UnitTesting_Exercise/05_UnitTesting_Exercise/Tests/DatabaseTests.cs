using _01_Database;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 8, -9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { })]
        public void ConstructorIsValidTest(int[] values)
        {
            Database db = new Database(values);

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(Database), typeof(int[]));

            int[] actualValues = (int[])fieldInfo.GetValue(db);
            int[] expectedValues = values.Concat(new int[actualValues.Length - values.Length]).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(expectedValues));
        }

        [Test]
        public void ConstructorDataSizeTest()
        {
            Database db = new Database();

            int[] databaseData = (int[])this.GetFieldInfo(typeof(Database), typeof(int[])).GetValue(db);

            int actualSize = databaseData.Length;
            int expectedSize = 16;

            Assert.That(actualSize, Is.EqualTo(expectedSize));
        }

        [Test]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(23)]
        public void ConstructorIsNotValidTest(int size)
        {
            int[] values = new int[size];

            Assert.That(() => new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue, new int[] { })]
        [TestCase(int.MaxValue, new int[] { 2, 5, 6 })]
        [TestCase(0, new int[] { 2, 3, 1, 2, 3, 5, 7, 8, 33 })]
        [TestCase(-1, new int[] { 3 })]
        [TestCase(22, new int[] { 4, 5, 6, 7 })]
        public void AddMethodCanAddElementTest(int elementToAdd, int[] initializeValues)
        {
            Database db = new Database(initializeValues);

            db.Add(elementToAdd);

            FieldInfo indexField = this.GetFieldInfo(typeof(Database), typeof(int));
            int index = (int)indexField.GetValue(db);
            Assert.That(index, Is.EqualTo(initializeValues.Length + 1));

            FieldInfo valuesField = this.GetFieldInfo(typeof(Database), typeof(int[]));

            int[] actualValues = (int[])valuesField.GetValue(db);
            int[] expectedValues = initializeValues.Concat(new int[] { elementToAdd }).Concat(new int[actualValues.Length - initializeValues.Length - 1]).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(expectedValues));
        }

        [Test]
        public void AddMethodCantAddElementTest()
        {
            Database db = new Database();

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(Database), typeof(int));

            int maxDataSize = 16;
            int someElementToAdd = 0;

            fieldInfo.SetValue(db, maxDataSize);

            Assert.That(() => db.Add(someElementToAdd), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveMethodCanRemoveElements(int[] values)
        {
            Database db = new Database(values);

            db.Remove();

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(Database), typeof(int[]));
            int[] actualElements = (int[])fieldInfo.GetValue(db);

            int bufferLength = actualElements.Length - (values.Length - 1);

            int[] expectedElements = values.SkipLast(1).Concat(new int[bufferLength]).ToArray();

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void RemoveMethodCantRemoveElementTest()
        {
            Database db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 22, 21, 1, 25, 76 })]
        [TestCase(new int[] { 29, 6, 0, 33, 62, 52, 34, 11, 1, 42, 42, 53, 66, 8, 9, 67 })]
        public void FetchMethodReturnsValidElements(int[] inputValues)
        {
            Database db = new Database(inputValues);

            Assert.That(() => db.Fetch(), Is.EquivalentTo(inputValues));
        }

        [Test]
        [TestCase(new int[] { 2, 8, 96, 36, 21, 14 }, 2)]
        public void FetchMethodReturnsValidElementsAfterAddAndRemoveMethods(int[] numbersToAdd, int removeCount)
        {
            Database db = new Database();

            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                db.Add(numbersToAdd[i]);
            }

            for (int j = 0; j < removeCount; j++)
            {
                db.Remove();
            }

            int[] actualElements = db.Fetch();
            int[] expectedElements = numbersToAdd.SkipLast(removeCount).ToArray();

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        private FieldInfo GetFieldInfo(Type classType, Type fieldType)
        {
            FieldInfo fieldInfo = classType
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .FirstOrDefault(f => f.FieldType == fieldType);

            return fieldInfo;
        }
    }
}
