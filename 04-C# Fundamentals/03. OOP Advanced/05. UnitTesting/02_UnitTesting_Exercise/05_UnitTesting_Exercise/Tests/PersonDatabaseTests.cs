namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;
    using _02_PersonDatabase;

    [TestFixture]
    public class PersonDatabaseTests
    {
        [Test]
        public void ConstructorDataSizeTest()
        {
            PersonDatabase db = new PersonDatabase();

            Person[] people = (Person[])this.GetFieldInfo(typeof(PersonDatabase), typeof(Person[])).GetValue(db);

            int actualSize = people.Length;
            int expectedSize = 16;

            Assert.That(actualSize, Is.EqualTo(expectedSize));
        }

        [Test]
        public void ConstructorValidTest()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person[] actualElements = (Person[])this.GetFieldInfo(typeof(PersonDatabase), typeof(Person[])).GetValue(db);

            int bufferLength = actualElements.Length - people.Length;

            Person[] expectedElements = people.Concat(new Person[bufferLength]).ToArray();

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void SuccessfulAddPersonToDatabase()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person personToAdd = new Person(3, "Petromil");

            db.Add(personToAdd);

            Person[] actualElements = (Person[])this.GetFieldInfo(typeof(PersonDatabase), typeof(Person[])).GetValue(db);

            int bufferLength = actualElements.Length - (people.Length + 1);

            Person[] expectedElements = people
                .Concat(new Person[] { personToAdd })
                .Concat(new Person[bufferLength])
                .ToArray();

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void UnsuccessfulAddPersonDatabaseIsFull()
        {
            int maxDataSize = 16;

            Person[] people = new Person[maxDataSize];

            PersonDatabase db = new PersonDatabase(people);

            Person personToAdd = new Person(2, "Petromil");

            Assert.That(() => db.Add(personToAdd), Throws.InvalidOperationException);
        }

        [Test]
        public void UnsuccessfulAddPersonToDatabaseUserIsAlreadyExists()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person personToAdd = new Person(2, "Petromil");
            
            Assert.That(() => db.Add(personToAdd), Throws.InvalidOperationException);
        }
        
        [Test]
        public void SuccessfulRemovePersonFromDatabase()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            db.Remove();

            Person[] actualElements = (Person[])this.GetFieldInfo(typeof(PersonDatabase), typeof(Person[])).GetValue(db);

            int bufferLength = actualElements.Length - (people.Length - 1);

            Person[] expectedElements = people
                .SkipLast(1)
                .Concat(new Person[bufferLength])
                .ToArray();

            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void UnsuccessfulRemovePersonFromDatabase()
        {
            PersonDatabase db = new PersonDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void SuccessfulFetchPersonsFromDatabase()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person firstPersonToAdd = new Person(3, "Petromil");
            Person secondPersonToAdd = new Person(4, "Goshoslav");

            db.Add(firstPersonToAdd);
            db.Add(secondPersonToAdd);

            db.Remove();

            Person[] expectedElements = people
                .Concat(new Person[] { firstPersonToAdd })
                .ToArray();

            Assert.That(() => db.Fetch(), Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void SuccessfulFindByUsername()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person person = db.FindByUsername("Gosho");

            Assert.That(person, Is.EqualTo(people[0]));
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfUsernameIsCaseInsensitive()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);
            
            Assert.That(() => db.FindByUsername("gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfParameterIsNull()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfPersonIsNotFound()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Assert.That(() => db.FindByUsername("Stanislav"), Throws.InvalidOperationException);
        }

        [Test]
        public void SuccessfulFindById()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Person person = db.FindById(1);

            Assert.That(person, Is.EqualTo(people[0]));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void FindByIdThrowsExceptionIfIdIsNegative(int negativeId)
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(negativeId));
        }

        [Test]
        public void FindByIdThrowsExceptionIfPersonIsNotFound()
        {
            Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };

            PersonDatabase db = new PersonDatabase(people);

            Assert.That(() => db.FindById(15), Throws.InvalidOperationException);
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
