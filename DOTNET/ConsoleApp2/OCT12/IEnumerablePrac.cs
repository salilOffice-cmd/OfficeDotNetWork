using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT12
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class EmployeeEnumerable : IEnumerable<Employee>
    {
        public List <Employee> EmpList = new List<Employee>();

        public void Add(Employee e)
        {
            EmpList.Add(e);
        }

        // We have to implement both of these GetEnumerator() methods
        // First is generic and second is non-generic

        // This method is essential for enabling foreach loops and other LINQ operations on your collection.
        public IEnumerator<Employee> GetEnumerator()
        {
            return EmpList.GetEnumerator();
        }

        // This method returns a non-generic IEnumerator,
        // which is often used when working with non-generic collections
        // or when you want to implement the interface explicitly.
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        // However in many cases, you won't directly use the second method, especially when working with strongly typed collections. 
    }


        internal class IEnumerablePrac
    {
        public static void Main(string[] args)
        {
            Employee emp1 = new Employee() { Id = 1, Name = "Salil"};
            Employee emp2 = new Employee() { Id = 2, Name = "Guddu" };
            Employee emp3 = new Employee() { Id = 3, Name = "Ramesh" };
            Employee emp4 = new Employee() { Id = 4, Name = "Bheem" };

        
            EmployeeEnumerable EmployeeEnumerable = new EmployeeEnumerable();
            EmployeeEnumerable.Add(emp1);
            EmployeeEnumerable.Add(emp2);
            EmployeeEnumerable.Add(emp3);
            EmployeeEnumerable.Add(emp4);


            var query = from emp in EmployeeEnumerable
                        where emp.Id > 2
                        select emp;


            foreach (var item in EmployeeEnumerable)
            {
                Console.WriteLine($"{item.Id} : {item.Name}");
            }

        }


    }
}
