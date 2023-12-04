using EFCore_Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac.RelationShips
{
    internal class myProgram
    {
        public static void Main(string[] args)
        {
            using(EF_RelationsDBContext context =  new EF_RelationsDBContext())
            {
                OfficeFloor officeFloor = new OfficeFloor
                {
                    Floor_Name = "1st Floor"
                };
                context.Floors.Add(officeFloor);
                context.SaveChanges();

                Employee emp = new Employee {
                    Name = "Salil",
                    Tech = "MS",
                    AvailCanteenService = true,
                    OfficeFloorId = officeFloor.FloorId
                };
                context.Employees.Add(emp);
                context.SaveChanges();

                SystemDetail sysDetail = new SystemDetail
                { 
                    SystemIP = "1.0.0.34",
                    SystemOS = "Mac",
                    EmployeeId = emp.EmployeeId
                };
                //context.Employees.Add(sysDetail);
                context.SaveChanges();

            }
        }
    }
}
