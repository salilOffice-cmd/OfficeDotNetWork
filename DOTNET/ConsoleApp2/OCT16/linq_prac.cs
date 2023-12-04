using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT16
{

    internal class Linq_Prac
    {
        public static void Main(string[] args)
        {
            List<Employee> listEMP = new List<Employee>()
            { 
                new Employee{Id =  1, Name = "Salil", Department_ID = 1},
                new Employee{Id =  2, Name = "Achal", Department_ID = 3},
                new Employee{Id =  3, Name = "Ajay", Department_ID = 1},
                new Employee{Id =  4, Name = "Henry", Department_ID = 2},
                new Employee{Id =  5, Name = "Rohit", Department_ID = 3}
            };

            List<EmployeeDepartment> listEmpDepartment = new List<EmployeeDepartment>()
            {
                new EmployeeDepartment{Department_ID = 1, Department_Name = "IT"},
                new EmployeeDepartment{Department_ID = 2, Department_Name = "HR"},
                new EmployeeDepartment{Department_ID = 3, Department_Name = "Payroll"},
            };

            // JOINS
            // using linq query syntax
            var query1 = from emp in listEMP
                         join dept in listEmpDepartment
                         on emp.Department_ID equals dept.Department_ID
                         select new // anonymous object
                         {
                             Id = emp.Id,
                             Name = emp.Name,
                             Department_Name = dept.Department_Name
                         };

            foreach(var emp in query1)
            {
                Console.WriteLine($"{emp.Id}: {emp.Name} : {emp.Department_Name}");
            }


            // using linq method syntax
            var query2 = listEMP.Join(
                listEmpDepartment,
                emp => emp.Department_ID,
                dept => dept.Department_ID,
                (emp, dept) => new { emp.Id, emp.Name, dept.Department_Name }
            );

            foreach (var emp in query2)
            {
                Console.WriteLine($"{emp.Id}: {emp.Name} : {emp.Department_Name}");
            }
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_ID { get; set; }
    }

    public class EmployeeDepartment
    {
        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
    }
}
