using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams
{
    class Person
    {
        private const int minimumPersonAge = 30;
        private const int minimumNameLength = 3;
        private const double minimumSalary = 460d;

        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if(value.Length <= minimumNameLength)
                {
                    throw new ArgumentException("FirstName must be at least 3 symbols");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length <= minimumNameLength)
                {
                    throw new ArgumentException("LastName must be at least 3 symbols");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {                
                if(value <= 0)
                {
                    throw new ArgumentException("Age must not be zero or negative");
                }

                this.age = value;
            }
        }

        public double Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if(value <= minimumSalary)
                {
                    throw new ArgumentException("Salary can't be less than 460.0");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(double bonus)
        {
            if(this.age < minimumPersonAge)
            {
                bonus /= 2;
            }

            this.salary += this.salary * (bonus / 100);
        }

        public override string ToString()
        {
            string personInfo = 
                $"{this.firstName} {this.lastName} get {this.salary:F2} leva";
            return personInfo;
        }
    }
}
