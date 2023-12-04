using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    delegate bool delegatePallindrome(int num);

    internal class DelegatePrac
    {
        public static bool Pallindrome(int num)
        {
            string numToString = Convert.ToString(num);
            bool isPallindrome = false;

            for (int i = 0; i < numToString.Length / 2; i++)
            {
                if (numToString[i] == numToString[numToString.Length - 1 - i])
                {
                    isPallindrome = true;
                }

                else
                {
                    //Console.WriteLine("Not a pallindrome number");
                    isPallindrome = false;
                    return isPallindrome;
                }
            }

            return isPallindrome;
        }


        public static void Main(string[] args)
        {
            delegatePallindrome dp = new delegatePallindrome(DelegatePrac.Pallindrome);
            bool result =  dp.Invoke(103210101);
            if(result == false)
            {
                Console.WriteLine("Number is not a pallindrome");
            }
            else
            {
                Console.WriteLine("Number is a pallindrome");
            }
        }
    }
}
