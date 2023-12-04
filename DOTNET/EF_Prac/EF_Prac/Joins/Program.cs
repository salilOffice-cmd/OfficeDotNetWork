using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac.Joins
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //AddEmployee("Salil", 40000, 1);
            //AddEmployee("Vijay sir", 90000, 1);
            //AddEmployee("Deepti Mam", 70000, 2);
            //AddEmployee("Rohit", 20000, 3);
            //AddEmployee("Minal Mam", 40000, 2);

            //AddDepartment("IT");
            //AddDepartment("HR");
            //AddDepartment("Payroll");



            // This code is related to async await with EF
            // see JoinEmployeeAndDepartmentAsync() first
            Console.WriteLine("main method started");

            Task<List<EmpDeptJoinModel>> task1 = JoinEmployeeAndDepartmentAsync();

            Console.WriteLine("main method continues its work1");
            Console.WriteLine("main method continues its work2");
            Console.WriteLine("main method continues its work3");

            List<EmpDeptJoinModel> gotList = await task1;
            foreach (var emp in gotList)
            {
                Console.WriteLine($"{emp.Id} : {emp.emp_name} : {emp.department}");
            }

            Console.WriteLine("main method continues its work4");


        }

        public static void AddEmployee(string _name, int _salary, int _deptId)
        {
            Employee employee = new Employee { Emp_Name = _name,Salary = _salary, Department_Id = _deptId};

            using(MyDBContext2 context = new MyDBContext2())
            { 
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
        public static void AddDepartment(string _deptName)
        {
            Department department = new Department { Dept_Name = _deptName};

            using (MyDBContext2 context = new MyDBContext2())
            {
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }

        public static void JoinEmployeeAndDepartment()
        {
            using(MyDBContext2 context = new MyDBContext2())
            {
                var joinedTable = context.Employees.Join(
                    context.Departments,
                    emp => emp.Department_Id,
                    dept => dept.Dept_Id,
                    (emp,dept) => new
                    {
                        Id = emp.Id,
                        emp_name = emp.Emp_Name,
                        department = dept.Dept_Name
                    }
                ).ToList();

                foreach (var emp in joinedTable)
                {
                    Console.WriteLine($"{emp.Id} : {emp.emp_name} : {emp.department}");
                }
            }
        }

        public static async Task<List<EmpDeptJoinModel>> JoinEmployeeAndDepartmentAsync()
        {
            using (MyDBContext2 context = new MyDBContext2())
            {
                var employeesTable = context.Employees;
                var departmentTable = context.Departments;
                var departmentTable1 = context.Departments;
                var departmentTable2 = context.Departments;
                var departmentTable3 = context.Departments;
                var departmentTable4 = context.Departments;
                var joinedTable = await context.Employees.Join(
                    context.Departments,
                    emp => emp.Department_Id,
                    dept => dept.Dept_Id,
                    (emp, dept) => new EmpDeptJoinModel
                    {
                        Id = emp.Id,
                        emp_name = emp.Emp_Name,
                        department = dept.Dept_Name
                    }
                ).ToListAsync();

                return joinedTable;
            }
        }   
    }

    class EmpDeptJoinModel
    {
        public int Id { get; set; }
        public string emp_name { get; set; }
        public string department { get; set; }
    }
}
