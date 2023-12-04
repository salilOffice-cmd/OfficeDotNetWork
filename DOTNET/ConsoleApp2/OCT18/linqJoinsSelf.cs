using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.OCT18
{

    internal class linqJoinsSelf
    {
        public static void Main(string[] args)
        {
            List<Employee> listEmp = new List<Employee>()
            {
                new Employee{emp_id = 1,emp_name = "Salil", department_id = 3, salary = 60000 },
                new Employee{emp_id = 2,emp_name = "Vijay Sir", department_id = 2, salary = 20000 },
                new Employee{emp_id = 3,emp_name = "Prabhu Sir", department_id = 3,salary = 30000 },
                new Employee{emp_id = 4,emp_name = "Ashish Sir", department_id = 1,salary = 50000 },
                new Employee{emp_id = 5,emp_name = "Dinesh Sir", department_id = 2,salary = 10000 },
                new Employee{emp_id = 6,emp_name = "Sagar", department_id = 1, salary = 20000 }
                //new Employee{emp_id = 6,emp_name = "Sagar", department_id = null, salary = 20000 }
            };

            List<EmployeeDepartment> listEmpDep = new List<EmployeeDepartment>()
            { 
                new EmployeeDepartment{department_id = 1, department_name = "IT"},
                new EmployeeDepartment{department_id = 2, department_name = "HR"},
                new EmployeeDepartment{department_id = 3, department_name = "Payroll"}
            };


            // Joins

            #region BasicJoins
            // Query Syntax
            var query1 = from emp in listEmp
                         join empDep in listEmpDep
                         on emp.department_id equals empDep.department_id
                         select new EmpDepModel
                         {
                             emp_id = emp.emp_id,
                             emp_name = emp.emp_name,
                             department_name = empDep.department_name,
                         };

            foreach (var emp in query1)
            {
                Console.WriteLine($"{emp.emp_id} | {emp.emp_name} | {emp.department_name}");
            }


            // Method Syntax
            var method1 = listEmp.Join
                (
                    listEmpDep,
                    e => e.department_id,
                    d => d.department_id,
                    (e, d) => new EmpDepModel
                    {
                        emp_id = e.emp_id,
                        emp_name = e.emp_name,
                        department_name = d.department_name
                    }
                );
                //).Where(ed => ed.emp_id > 2);

            foreach (var emp in method1)
            {
                Console.WriteLine($"{emp.emp_id} | {emp.emp_name} | {emp.department_name}");
            }
            #endregion

            #region LeftJoins
            var leftJoinMethodSyntax = listEmp.GroupJoin
                (
                    listEmpDep,
                    e => e.department_id,
                    d => d.department_id,
                    (e, departmentGroup) => new EmpDepModel
                    {
                        emp_id=e.emp_id,
                        emp_name = e.emp_name,
                        department_name = departmentGroup
                                            .Select(d => d.department_name)
                                            .FirstOrDefault() ?? "No department"
                    }
                );

            //foreach (var emp in leftJoinMethodSyntax)
            //{
            //    Console.WriteLine($"{emp.emp_id} | {emp.emp_name} | {emp.department_name}");
            //}

            var leftJoinQuerySyntax = from emp in listEmp
                                      join dep in listEmpDep
                                      on emp.department_id equals dep.department_id into departmentGroup
                                      from d in departmentGroup.DefaultIfEmpty()
                                      select new EmpDepModel
                                      {
                                          emp_id = emp.emp_id,
                                          emp_name = emp.emp_name,
                                          department_name = d?.department_name ?? "No department"
                                      };

            //foreach (var emp in leftJoinQuerySyntax)
            //{
            //    Console.WriteLine($"{emp.emp_id} | {emp.emp_name} | {emp.department_name}");
            //}

            #endregion

            #region GroupByLinq

            var grpMethodSyntax1 = listEmp
                                .GroupBy(e => e.department_id);

            foreach (var group in grpMethodSyntax1)
            {
                Console.WriteLine("GROUP " + group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine($"{emp.emp_id} : {emp.emp_name} : {emp.salary}");
                }
            }

            var grpMethodSyntax2 = listEmp
                                .GroupBy(e => e.department_id)
                                .Select(group => group.Select(emp => new
                                {
                                    ID = emp.emp_id,
                                    NAME = emp.emp_name,
                                    SALARY = emp.salary
                                }));

            //foreach (var emp in grpMethodSyntax2)
            //{
            //    foreach(var e in emp)
            //    {
            //        Console.WriteLine(e.ID);
            //    }
            //}



            var grpQuerySyntax1 = from e in listEmp
                                  group e by e.department_id into groupResult
                                  select new
                                  {
                                      DEP_ID = groupResult.Key,
                                      MaxSalary = groupResult.Max(e => e.salary)
                                  };

            foreach (var group in grpQuerySyntax1)
            {
                Console.WriteLine( group.DEP_ID + " " +  group.MaxSalary);
            }

            #endregion
        }

        class Employee
        {
            public int emp_id { get; set; }
            public string emp_name { get; set; }
            public int salary { get; set; }
            public int? department_id { get; set; }

        }

        class EmployeeDepartment
        {
            public int department_id { get; set; }
            public string department_name { get; set; }
        }

        class EmpDepModel
        {
            public int emp_id { get; set; }
            public string emp_name { get; set; }
            public string department_name { get; set; }
        }
    }
}
