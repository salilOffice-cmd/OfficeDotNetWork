using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// runtime binding/ dynamic binding / late binding
namespace ConsoleApp2.OCT6
{
    interface SmartData
    {
        void giveName();
        void giveDepartment();
    }

    public class Employee1 : SmartData
    {
        public void giveName()
        {
            Console.WriteLine("Employee1 name is Salil");
        }

        public void giveDepartment()
        {
            Console.WriteLine("Employee1 department is MS");
        }
    }

    public class Employee2 : SmartData
    {
        public void giveName()
        {
            Console.WriteLine("Employee2 name is Om");
        }

        public void giveDepartment()
        {
            Console.WriteLine("Employee2 department is NewTech");
        }
    }
    
    internal class Program1
    {
        public static void Main(string[] args)
        {
            SmartData sd1 = new Employee1();
            sd1.giveName();
            sd1.giveDepartment();


            SmartData sd2 = new Employee2();
            sd2.giveName();
            sd2.giveDepartment();
        }
    }
}
