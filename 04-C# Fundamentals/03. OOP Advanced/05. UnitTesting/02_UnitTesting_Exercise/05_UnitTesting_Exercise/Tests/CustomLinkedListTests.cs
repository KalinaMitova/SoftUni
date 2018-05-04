namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    using _08_CustomLinkedList;

    [TestFixture]
    public class CustomLinkedListTests
    {
        [Test]
        [TestCase("Gosho")]
        [TestCase("Ivan")]
        [TestCase("Pesho")]
        public void ListNodeConstructorSetsValidElement(string parameter)
        {
            Type listNodeType = typeof(DynamicList<string>).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault();

            Type constructedType = listNodeType.MakeGenericType(typeof(string));

            var listNode = Activator.CreateInstance(constructedType, parameter);

            FieldInfo element = constructedType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(string));

            string actualValue = (string)element.GetValue(listNode);

            Assert.That(actualValue, Is.EqualTo(parameter));
        }

        [Test]
        public void IndexatorThrowsExceptionIfGetInvalidIndex()
        {
            DynamicList<string> list = new DynamicList<string>();

            list.Add("Element");
            
            Assert.Throws<ArgumentOutOfRangeException>(() => { string element = list[1]; });
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 2)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 0)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 1)]
        public void IndexatorGetsElementByValidIndex(object[] elements, int index)
        {
            string expectedElement = (string)elements[index];

            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            string actualElement = list[index];

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void IndexatorThrowsExceptionIfTryToSetValueOnInvalidIndex()
        {
            DynamicList<string> list = new DynamicList<string>();

            list.Add("Element");

            Assert.Throws<ArgumentOutOfRangeException>(() =>  list[1] = "Some string");
        }

        [Test]
        public void IndexatorSetsElementOnValidIndex()
        {
            string valueToSet = "New element";

            DynamicList<string> list = new DynamicList<string>();

            list.Add("Element");
            list.Add("Element");
            list.Add("Element");

            list[2] = valueToSet;

            string actualElementValue = list[2];

            Assert.That(actualElementValue, Is.EqualTo(valueToSet));
        }

        [Test]
        [TestCase("Gosho")]
        [TestCase("Ivan")]
        [TestCase("Stoqn")]
        public void AddMethodAddsElementInEmptyList(string element)
        {
            DynamicList<string> list = new DynamicList<string>();

            list.Add(element);

            Assert.That(list[0], Is.EqualTo(element));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" })]
        [TestCase(new object[] { "Asen", "Petar", "Traqn" })]
        public void AddMethodAddsElementInNonEmptyList(object[] elements)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            string actualElements = string.Join(" ", list);
            string expectedElements = string.Join(" ", elements);

            Assert.That(actualElements, Is.EqualTo(expectedElements));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, -2)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 3)]
        public void RemoveAtMethodThrowsExceptionIfIndexIsInvalid(object[] elements, int index)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }
            
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 1)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 2)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 0)]
        public void RemoveAtMethodReturnsActualElement(object[] elements, int index)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            string actualElement = list.RemoveAt(index);
            string expectedElement = (string)elements[index];

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 1)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 2)]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, 0)]
        public void RemoveAtMethodSuccessfulyRemoveElement(object[] elements, int index)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            list.RemoveAt(index);

            elements[index] = null;

            string actualElements = string.Join("", list).Trim(' ');
            string expectedElements = string.Join("", elements).Trim(' ');

            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Stanimir")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Papi Hans")]
        public void RemoveMethodReturnsNegativeNumberIfItemNotFound(object[] elements, string elementToRemove)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            int removeIndex = list.Remove(elementToRemove);

            Assert.That(removeIndex, Is.EqualTo(-1));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Pesho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Gosho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Ivan")]
        public void RemoveMethodSuccessfulyRemovesItem(object[] elements, string elementToRemove)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            int index = list.Remove(elementToRemove);

            elements[index] = null;

            string actualElements = string.Join("", list).Trim(' ');
            string expectedElements = string.Join("", elements).Trim(' ');

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Pesho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Gosho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Ivan")]
        public void RemoveMethodReturnsValidIndex(object[] elements, string elementToRemove)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            int actualIndex = list.Remove(elementToRemove);
            int expectedIndex = Array.IndexOf(elements, elementToRemove);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Pesho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Gosho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Ivan")]
        public void IndexOfMethodReturnsValidIndex(object[] elements, string element)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            int actualIndex = list.IndexOf(element);
            int expectedIndex = Array.IndexOf(elements, element);

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Stamat")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Spas")]
        public void IndexOfMethodReturnsNegativeIndexIfElementNotExists(object[] elements, string element)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            int actualIndex = list.IndexOf(element);
            int expectedIndex = -1;

            Assert.That(actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Ivan")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Gosho")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Pesho")]
        public void ContainsMethodReturnsTrueIfElementIsFound(object[] elements, string element)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            bool actualValue = list.Contains(element);
            bool expectedValue = true;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Goshoto")]
        [TestCase(new object[] { "Ivan", "Gosho", "Pesho" }, "Peshoto")]
        public void ContainsMethodReturnsFalseIfElementNotFound(object[] elements, string element)
        {
            DynamicList<string> list = new DynamicList<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                list.Add((string)elements[i]);
            }

            bool actualValue = list.Contains(element);
            bool expectedValue = false;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
