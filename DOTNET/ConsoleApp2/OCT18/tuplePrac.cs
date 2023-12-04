using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT18
{
    internal class tuplePrac
    {
        public static void Main(string[] args)
        {
            //1. Named Tuples
            (int Id, string Name) emp1 = (1, "Sahil");

            // Access named tuples
            Console.WriteLine(emp1.Id + " " + emp1.Name);



            //2. Unnamed Tuples
            var emp2 = (2, "Henry");

            //Access Unnamed tuples
            Console.WriteLine(emp2.Item1 + " " + emp2.Item2);



            //3. Tuple in methods (see method first)

            // Tuple Deconstruction (with named tuple)
            (int gotSum, int gotProduct) calculate = Calculate(3, 4);
            Console.WriteLine("Sum is " + calculate.gotSum);
            Console.WriteLine("Sum is " + calculate.gotProduct);

            // Tuple Deconstruction (with unnamed tuple)
            (int gotSum, int gotProduct) = Calculate(3, 4);
            Console.WriteLine("Sum is " + gotSum);
            Console.WriteLine("Sum is " + gotProduct);
        }

        public static (int sum, int product) Calculate(int a, int b)
        {
            int addition = a + b;
            int multiplication = a * b;
            return (addition, multiplication);
        }
    }
}
