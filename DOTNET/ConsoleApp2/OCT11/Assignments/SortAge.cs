using System;
using System.Collections.Generic;

namespace ConsoleApp2.OCT10.Assignments
{
    class SortAge
    {

        // Collection
        public SortedList<string, int> persons = new SortedList<string, int>();

        // Two arrays
        public string[] names =
        {
            "Prabhu Sir",
            "Salil",
            "Achal",
            "Rohit",
            "Apeksha",
            "Kashish",
            "Om",
            "Sagar",

        };

        

        public int[] ages = { 12, 6, 34, 67, 3, 18, 59, 23 };

        public void FillSortedList()
        {

            for (int i = 0; i < names.Length; i++)
            {
                persons.Add(names[i], ages[i]);
            }

            foreach (var item in persons)
            {
                //persons[item.Key] = 2;
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        public void sortByAge()
        {
            List<string> namesList = new List<string>();
            List<int> ageList = new List<int>();
            foreach (var item in persons)
            {
                ageList.Add(item.Value);
                namesList.Add(item.Key);

            }

            // Sorted the ages in a different list
            ageList.Sort();

            // Adding the sorted elements back to sortedList
            for(int i = 0; i < namesList.Count; i++)
            {
                persons[namesList[i]] = ageList[i];
            }

            Console.WriteLine("After sorting the collection:");
            foreach (var item in persons)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            SortAge sa = new SortAge();
            sa.FillSortedList();
            sa.sortByAge();

        }
    }
}
