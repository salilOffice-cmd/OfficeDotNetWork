using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqSelf;

namespace ConsoleApp2.OCT19
{
    internal class LinqPracBasic
    {
        public static void Main(string[] args)
        {
            #region OurCollections
            List<Employee> employees = new List<Employee>()
            {
                new Employee {Id=1,Name="Abc",Technology="MS", Emp_code="EMP-1"},
                new Employee {Id=2,Name="Xyz",Technology="MS",Emp_code="EMP-2" },
                new Employee {Id=3,Name="Test",Technology="MEAN",Emp_code="EMP-3" },
                new Employee {Id=4,Name="Hello",Technology="MEAN",Emp_code="EMP-4" }
            };

            List<EmpSalary1> employeeSalaries = new List<EmpSalary1>()
            {
                new EmpSalary1 {Id=1,Salary=20000,age=34},
                new EmpSalary1 {Id=2,Salary=10000,age=23},
                new EmpSalary1 {Id=3,Salary=45000,age=67},
                new EmpSalary1 {Id=4,Salary=25000,age=17}
            };

            #endregion


            #region PracticeMethods
            // IMP LINQ Methods
            // 1.Where
            // 2.Select
            // 3.OrderBy and OrderByDescending
            // 4.Count
            // 5.Sum, Average, Min, and Max : Perform calculations on numeric elements in a collection.
            // 6.Skip and Take : Skips a specified number of elements and returns a specified number of elements from a collection.
            // 7.ToArray, ToList, ToDictionary : Converts a sequence into an array, list, or dictionary.
            // 8. Join(../OCT18/linqJoinsSelf)
            // 9. GroupBy


            // Where, Select and Orderby
            var query1 = employees
                        .Where(emp => emp.Id > 1)
                        .Select(emp => new { ID = emp.Id, NAME = emp.Name })
                        .OrderBy(emp => emp.NAME);

            foreach( var emp in query1 )
            {
                //Console.WriteLine( emp.NAME );
            }

            // To get the count
            var query2 = query1.Count();
            //Console.WriteLine(query2);

            // Performing calculations
            var query3 = employeeSalaries.Sum(emp => emp.Salary);
            var query4 = employeeSalaries.Max(emp => emp.Salary);
            var query5 = employeeSalaries.Min(emp => emp.Salary);
            var query6 = employeeSalaries.Average(emp => emp.Salary);
            //Console.WriteLine(query6);


            // Skip and take(equivalent to TOP() in sql)
            var query7 = employeeSalaries
                         .OrderByDescending(emp => emp.Salary)
                         .Take(2);

            var query8 = employeeSalaries
                         .OrderByDescending(emp => emp.Salary)
                         .Skip(1);

            foreach (var emp in query8)
            {
                Console.WriteLine($"{emp.Id} : {emp.Salary}");
            }

            

            #endregion




        }
    }

    public class EmpSalary1
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public int age { get; set; }
    }
}
