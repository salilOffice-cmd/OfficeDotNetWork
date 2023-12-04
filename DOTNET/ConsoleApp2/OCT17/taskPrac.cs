using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.OCT17
{
    internal class taskPrac
    {
        public static async Task fetchData()
        {
            Console.WriteLine("fetchData() called");
            //await Task.Run( async() => { 
            //    Console.WriteLine("Fetching Data from database...");
            //    await Task.Delay(3000);
            //    Console.WriteLine("Fetching Complete");
            //});
            await Task.Run(() => {
                Console.WriteLine("Fetching Data from database...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Fetching Complete");
            });
        }

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started...");
            Task task2 = fetchData();
            Task<int> task1 = Task.Run(async() =>
            {
                Console.WriteLine("Task Started");
                await Task.Delay(3000);
                Console.WriteLine("Task Ended");
                return 1;
            });
            Console.WriteLine("Main method continues its work...");
            int gotValue = await task1;
            Console.WriteLine(gotValue);
            task2.Wait();
            Console.WriteLine("Main method ended!!");
        }
    }
}
