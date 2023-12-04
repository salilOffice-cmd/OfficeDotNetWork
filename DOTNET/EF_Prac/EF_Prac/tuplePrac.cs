using EF_Prac.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac
{

    internal class tuplePrac
    {
        //public delegate int calculateDelegate(int x, int y);
        
        public static void AddEmployee1(int _id, string _name)
        {

        }
        public static void AddEmployee2((int _id, string _name) employee)
        {
            Employee employee1 = new Employee { Id = employee._id, Emp_Name = employee._name};

            using (MyDBContext2 context = new MyDBContext2())
            {
                var employeeTable = context.Employees;
                employeeTable.Add(employee1);
                //context.Employees.Add(employee1);
                context.SaveChanges();
            }
        }

        public static void kuchBhi(Func<int, int, int> callback, int x, int y)
        {
            callback(x, y);

        }


        public static void Main(string[] args)
        {
            // AddEmployee2((1, "salil"));

            Func<int, int, int> myFunc = (x, y) =>
            {
                return x + y;
            };

            kuchBhi(myFunc, 2, 3);

        }
    }
}
