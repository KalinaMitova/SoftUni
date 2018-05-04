using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class ListyIteratorTests
    {
        [Test]
        public void ConstructorThrowsExceptionIfArgumentsAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListyIterator<string>(null));
        }

        [Test]
        public void ConstructorSuccessfulyCreateInstanceOfAnObject()
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            List<string> iteratorData = (List<string>)this.GetFieldInfo(typeof(ListyIterator<string>), typeof(List<string>)).GetValue(iterator);

            Assert.That(iteratorData, Is.EquivalentTo(data));

            int iteratorIndex = (int)this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int)).GetValue(iterator);

            int expectedIndex = 0;

            Assert.That(iteratorIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void MoveMethodReturnsTrueAndIncreaseIndex()
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            bool isMove = iterator.Move();

            Assert.That(isMove, Is.EqualTo(true));

            int iteratorIndex = (int)this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int)).GetValue(iterator);

            int expectedIndex = 1;

            Assert.That(iteratorIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void MoveMethodReturnsFalseAndIndexNotIncrease()
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            iterator.Move();
            iterator.Move();

            bool isMove = iterator.Move();

            Assert.That(isMove, Is.EqualTo(false));

            int iteratorIndex = (int)this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int)).GetValue(iterator);

            int expectedIndex = 2;

            Assert.That(iteratorIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(16)]
        [TestCase(int.MaxValue)]
        public void PrintMethodThrowsExceptionIfIndexIsInvalid(int invalidIndex)
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int));
            fieldInfo.SetValue(iterator, invalidIndex);

            Assert.Throws<InvalidOperationException>(() => iterator.Print());
        }

        [Test]
        public void HasIndexReturnsTrue()
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int));
            fieldInfo.SetValue(iterator, 1);

            bool hasIndex = iterator.HasNext();

            Assert.That(hasIndex, Is.EqualTo(true));
        }

        [Test]
        public void HasIndexReturnsFalse()
        {
            List<string> data = new List<string>() { "Gosho", "Ivan", "Petkan" };

            ListyIterator<string> iterator = new ListyIterator<string>(data);

            FieldInfo fieldInfo = this.GetFieldInfo(typeof(ListyIterator<string>), typeof(int));
            fieldInfo.SetValue(iterator, 2);

            bool hasIndex = iterator.HasNext();

            Assert.That(hasIndex, Is.EqualTo(false));
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
