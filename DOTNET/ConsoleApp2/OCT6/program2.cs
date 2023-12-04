using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Extensions method
namespace ConsoleApp2.OCT6
{
    class classA
    {
        public void methA1()
        {
            Console.WriteLine("methA1");
        }

        public void methA2()
        {
            Console.WriteLine("methA2");
        }
        public void methA3()
        {
            Console.WriteLine("methA3");
        }
    }

    static class classB {

        static string name = "anchal";
        public static void methB1(this classA a)
        {
            Console.WriteLine(name);
        }

        public static void methB2(this classA a)
        {
            Console.WriteLine("methB2");
        }
    }

    public class program2 { 

        public static void Main(string[] args)
        {
            classA A = new classA();
            A.methA1();
            A.methA2();
            A.methA3();
            A.methB1();
            A.methB2();
        }
    }




}
