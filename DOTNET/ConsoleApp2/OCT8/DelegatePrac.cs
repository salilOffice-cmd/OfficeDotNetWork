using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// using callbacks
namespace ConsoleApp2.OCT8
{
    public delegate void Callback(string message);
    

    internal class DelegatePrac
    {
        public static void FetchData(string _message, Callback callback)
        {
            callback(_message);
        }

        public static void Fun2(string s)
        {
            Console.WriteLine(s);
        }


        public static void Main(string[] args)
        {
            //string s = "salil";
            //FetchData("Fetching Completed", (s) => {
            //    Console.WriteLine(s);
            //});

            //Callback cl = new Callback(Fun2);
            //cl.Invoke("df");
            //FetchData("Fetching Completed", cl);


            // Methods to write a anonymous function

            Callback cb = delegate (string s)
            {
                Console.WriteLine($"The passed string is {s}");
            };
            cb.Invoke("hahahaha");
            
            Func<int, int> fnc1 = (s) =>
            {
                return s + 10;
            };
            fnc1.Invoke(3);

            var a = (Func<int, int, string>)((num1, num2) =>
            {
                return "ab";
            });




        }
    }
}
