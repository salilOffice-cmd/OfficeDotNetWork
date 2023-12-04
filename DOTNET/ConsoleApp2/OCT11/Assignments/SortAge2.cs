using System;
using System.Collections.Generic;

namespace ConsoleApp2.OCT10.Assignments
{
    class SortAge2
    {
        public void FillSortedList(SortedList<string, int> sortedList, string[] namesArray, int[] ageArray)
        {

            for (int i = 0; i < namesArray.Length; i++)
            {
                sortedList.Add(namesArray[i], ageArray[i]);
            }

            foreach (var item in sortedList)
            {
                //sortedList[item.Key] = 2;
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        public void sortByAge(SortedList<string, int> sortedList)
        {
            List<string> namesList = new List<string>();
            List<int> ageList = new List<int>();
            foreach (var item in sortedList)
            {
                ageList.Add(item.Value);
                namesList.Add(item.Key);

            }

            // Sorted the ages in a different list
            ageList.Sort();

            // Adding the sorted elements back to sortedList
            for (int i = 0; i < namesList.Count; i++)
            {
                sortedList[namesList[i]] = ageList[i];
            }

            Console.WriteLine("After sorting the collection:");
            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }
    }
    internal class Program2
    {
        public static void Main(string[] args)
        {
            // Collection
            SortedList<string, int> persons = new SortedList<string, int>();

            // Two arrays
            string[] names =
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
            int[] ages = { 12, 6, 34, 67, 3, 18, 59, 23 };


            SortAge2 sa = new SortAge2();
            sa.FillSortedList(persons, names, ages);
            Console.WriteLine("\n");
            sa.sortByAge(persons);


        }
    }
}
