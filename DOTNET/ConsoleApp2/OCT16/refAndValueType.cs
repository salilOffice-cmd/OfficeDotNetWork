using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.OCT16
{
    internal class refAndValueType
    {
        public static void Main(string[] args)
        {
            // Value types
            //int,float,double,char,bool,byte,short,long

            //Examples
            int i1 = 0;
            int i2 = i1; // memory is allocated to i2 separately
            i2++;
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            char c1 = 'a';
            char c2 = c1;
            c2 = 'b';
            //Console.WriteLine(c1);
            //Console.WriteLine(c2);


            // Reference Types
            // Classes,Interfaces,Delegates,Arrays,Strings,Dynamic,Objects

            // 1. Using Collections
            // All collections are reference types
            // This demonstrates that any changes made to list2 also affects list1
            List<int> list1 = new List<int>() { 1, 2};
            List<int> list2 = list1;

            list2.Add(12);
            list2.Add(11);

            Console.WriteLine(list1.Count);

            // 2. Using objects
            // This demonstrates that any changes made to list2 also affects list1
            Class11 obj1 = new Class11(1, "Salil");
            Class11 class2 = obj1;
            class2.name = "Rohit";
            Console.WriteLine(obj1.name);



        }
    }

    internal class Class11
    {
        public int id {  get; set; }
        public string name { get; set; }

        public Class11(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
