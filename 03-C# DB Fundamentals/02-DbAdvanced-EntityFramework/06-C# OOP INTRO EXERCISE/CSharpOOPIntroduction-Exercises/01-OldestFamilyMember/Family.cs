using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OldestFamilyMember
{
    class Family
    {
        private List<Person> persons;

        public Family()
        {
            this.persons = new List<Person>();
        }

        public List<Person> Peoples
        {
            get
            {
                return this.persons;
            }
            private set
            {
                this.persons = value;
            }
        }

        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = persons.OrderByDescending(p => p.Age).First();
            return oldestMember;
        }
    }
}
