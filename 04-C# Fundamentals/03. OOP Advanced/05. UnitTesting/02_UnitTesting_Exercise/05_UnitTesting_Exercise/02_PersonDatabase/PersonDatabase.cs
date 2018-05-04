using System;
using System.Linq;

namespace _02_PersonDatabase
{
    public class PersonDatabase
    {
        private const int maxDataSize = 16;

        private Person[] data;
        private int currentIndex;

        public PersonDatabase()
        {
            this.data = new Person[maxDataSize];
            this.currentIndex = 0;
        }

        public PersonDatabase(params Person[] people)
            : this()
        {
            foreach (var person in people)
            {
                this.Add(person);
            }

            this.currentIndex = people.Length;
        }

        public void Add(Person person)
        {
            if (this.currentIndex == maxDataSize)
            {
                throw new InvalidOperationException("Array is full!");
            }

            if (this.data.Any(p => p == null ? false : p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException("Person already exists into Database!");
            }

            this.data[currentIndex] = person;
            currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            currentIndex--;
            this.data[currentIndex] = default(Person);
        }

        public Person[] Fetch()
        {
            Person[] people = new Person[currentIndex];

            Array.Copy(this.data, people, currentIndex);

            return people;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException($"Username can't be null!");
            }

            Person user = this.data.FirstOrDefault(p => p?.Username == username);

            if (user == null)
            {
                throw new InvalidOperationException($"User with username: {username} not found!");
            }

            return user;
        }

        public Person FindById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be positive number!");
            }

            Person user = this.data.FirstOrDefault(p => p?.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException($"User with id: {id} not found!");
            }

            return user;
        }
    }
}
