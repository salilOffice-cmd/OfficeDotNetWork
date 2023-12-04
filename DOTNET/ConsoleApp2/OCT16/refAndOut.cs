using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT16
{

    // Method overloading with ref and out
    class Class1
    {
        // Below code gives error
        //public void fun1(ref int i ) { }
        //public void fun1(out int i) { }


        // Allowed
        public void fun2(ref int i ) { }
        public void fun2(int i ) { }
    }


    // reference return values 
    class Class2
    {
        public int age;
        public int x { get; set; }

        public ref int getAge()
        {
            // Properties aren't variables. They're methods!
            // Hence, can't be passed to ref and out parameters.
            // return ref x; // - gives error
            return ref age;
        }
    }

    internal class refAndOut
    {
        public static void changeNum(ref int num)
        {
            num++;
        }

        public static void outSingle(out int num) {
            num = 10;
        }
        public static void outMultiple(out int num1, out int num2) {
            num1 = 10;
            num2 = 30;
        }

        public static void Main(string[] args)
        {
            // 1. ref
            // ref is used to pass a variable by reference to a method.
            // The variable passed with ref must be initialized before it is passed to the method.
            // Any changes made to the parameter within the method affect the original
            // variable passed to the method.

            int i1 = 10;
            Console.WriteLine("Before: " + i1);
            changeNum(ref i1);
            Console.WriteLine("After: " + i1);  // changes the original variable i1



            // 2. out
            // out is used to indicate that the method is expected to assign a value to the variable.
            // The variable passed with 'out' does not need to be initialized before it is passed to the method.
            // The method must assign a value to the variable within the method.
            // The method should not read the value of the variable before assigning a value.
            // After the method returns, the variable holds the assigned value.
            // Also, we can return multiple values using out

            int x, y;
            outMultiple(out x, out y);
            Console.WriteLine($" x is {x} and y is {y}");


            // When a method uses an out parameter,
            // it must assign a value to the parameter within the method.
            // This ensures that the variable has a value after the method call.
            // However, ref parameters do not require this;
            // the variable should already have a value before being passed.




            // 3. Reference Return values
            Class2 class2 = new Class2();
            class2.age = 10;
            Console.WriteLine("Age before: " + class2.age);
            ref int gotAge = ref class2.getAge();
            gotAge = 30; // Modifies the age property in-place
            Console.WriteLine("Age after " + class2.age);



        }
    }
}
