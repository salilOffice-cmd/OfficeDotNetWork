using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT17
{
    internal class taskPrac2
    {
        public static async Task fetchData1()
        {
            Console.WriteLine("fetchData() called");
            await Task.Run(() => {
                Console.WriteLine("Fetching1 Data from database...");
                Task.Delay(6000).Wait();
                Console.WriteLine("Fetching1 Complete");
            });
        }
        public static async Task fetchData2()
        {
            Console.WriteLine("fetchData2() called");
            await Task.Run( () =>
            {
                Console.WriteLine("Fetching2 Data from database...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Fetching2 Complete");
            });
        }

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started...");
            //Task task1 = fetchData1();
            //Task task2 = fetchData2();
            //fetchData1().Wait();
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("Task1 Started");
                Task.Delay(6000).Wait();
                Console.WriteLine("Task1 Ended");

            });


            Task task2 = Task.Run(async () =>
            {
                Console.WriteLine("Task2 Started");
                await Task.Delay(3000);
                Console.WriteLine("Task2 Ended");

            });

            Console.WriteLine("Main method continues its work...");
            await task1;
            await task2;
            //await task3;
            //await task1A;
            Console.WriteLine("Main method ended!!");

            //Task task1A = Task.Run(() =>
            //{
            //    Console.WriteLine("Task1A Started");
            //    Task.Delay(3000).Wait();
            //    Task.Run(() =>
            //    {
            //        Console.WriteLine("Task1B Started");
            //        Task.Delay(2000).Wait();
            //        Console.WriteLine("Task1B Ended");

            //    });
            //    Console.WriteLine("Task1A Ended");

            //});
        }
    }
}
