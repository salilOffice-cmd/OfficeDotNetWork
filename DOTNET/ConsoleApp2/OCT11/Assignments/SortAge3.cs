using System;
using System.Collections.Generic;

namespace ConsoleApp2.OCT10.Assignments
{
    class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Employee(string _Name, int _Age) { 
            this.Name = _Name;
            this.Age = _Age;
        }

        public int CompareTo(Employee other)
        {
            if (this.Age == other.Age) return 0;
            else if (this.Age > other.Age) return 1;
            else return -1;
        }
    }

    class Program3
    {
        static void Main()
        {

            Employee emp1 = new Employee("Salil", 22);
            Employee emp2 = new Employee("Prabhu Sir", 30);
            Employee emp3 = new Employee("Rahul", 45);
            Employee emp4 = new Employee("Suresh", 5);

            List<Employee> list = new List<Employee>() { emp1, emp2, emp3, emp4};

            list.Sort();

            foreach (Employee e in list)
            {
                Console.WriteLine($"{e.Name} : {e.Age}");
            }

        }
    }


}
