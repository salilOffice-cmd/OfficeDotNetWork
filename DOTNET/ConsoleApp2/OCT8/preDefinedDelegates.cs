using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT8
{
    internal class preDefinedDelegates
    {
        public static int returnAddition(int a, int b)
        {
            return a + b;
        }

        public static int returnSubtraction(int a, int b)
        {
            return a - b;
        }

        public static void Add1(int a, int b)
        {
            Console.WriteLine("Addition1 of two numbers is " +  (a + b));
        }
        public static void Add2(int a, int b)
        {
            Console.WriteLine("Addition2 of two numbers is " + (a + b));
        }

        public static bool CheckLength(string s)
        {
            if(s.Length > 3)
            {
                return true;
            }

            return false;
        }



        public static void Main(string[] args)
        {
            // 1. Func
            Func<int, int, int> func = returnAddition;
            //Console.WriteLine(func.Invoke(3, 5));

            // 2. Action
            Action<int, int> act = Add1;
            act.Invoke(10, 10);

            // 3. Predicate
            Predicate<string> pred = CheckLength;
            Console.WriteLine(pred.Invoke("henry"));


            // Multicasting

            // Func and Predicate (no use of multicasting)
            // As Func and Predicate returns something,
            // it will only return the output of the last delegate called.
            func += returnSubtraction;
            Console.WriteLine(func.Invoke(3, 5));

            // 2. Action
            act += Add2;
            act.Invoke(10, 10);
        }
    }
}
