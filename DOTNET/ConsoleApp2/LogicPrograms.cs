using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp2
{


    public class LogicPrograms
    {
        public static void Main(string[] args)
        {   
            // Odd even
            {

                //int[] arr1 = { 1, 2, 4, 56, 85, 5, 7, 9, 34, 66 };
                //int[] evenArr = new int[10];
                //int[] oddArr = new int[10];
                //var evenArrIndex = 0;
                //var oddArrIndex = 0;

                //for (int i = 0; i < arr1.Length; i++)
                //{

                //    if (arr1[i] % 2 == 0)
                //    {
                //        evenArr[evenArrIndex] = arr1[i];
                //        evenArrIndex++;
                //    }

                //    else
                //    {
                //        oddArr[oddArrIndex] = arr1[i];
                //        oddArrIndex++;
                //    }
                //}

                //Console.WriteLine("Even");
                //foreach(int i in evenArr)
                //{
                //    if(i != 0)
                //    {
                //        Console.WriteLine(i);   
                //    }
                //}

                //Console.WriteLine("Odd");
                //foreach (int i in oddArr)
                //{
                //    if (i != 0)
                //    {
                //        Console.WriteLine(i);
                //    }
                //}
            }

            // reverse the string
            {
                //char[] charArr = { 'a', 'b', 'c', };
                //char[] charArr2 = new char[charArr.Length];

                //int charArrIndex = 0;
                //for (int i = charArr.Length - 1; i >= 0; i--)
                //{
                //    charArr2[charArrIndex] = charArr[i];
                //    charArrIndex++;
                //}

                //foreach (var i in charArr2)
                //{
                //    Console.WriteLine(i);
                //}
            }


            // remove the immediate duplicate string
            {
                //string str = "My name name is Salil Salil name name";

                //string[] strArray = str.Split();


                //for (int i = 0; i < strArray.Length; i++)
                //{
                //    if(i == strArray.Length - 1)
                //    {
                //        break;
                //    }

                //    else if (strArray[i] == strArray[i + 1])
                //    {
                //        strArray[i] = "";
                //    }

                //}
                
                //foreach(var i in strArray)
                //{
                //    if(i != "")
                //    {
                //        Console.WriteLine(i);

                //    }
                //}
            }

            // find duplicates and merge multiple arrays (using functions)
            {
                int[] arr1 = { 5, 4, 3, 2, 1, 6 };
                int[] arr2 = { 5, 7, 8, 9, 10, 6 };
                int[] arr3 = { 11, 9, 3, 19, 10, 15 };

                // Merging array
                var mergedArray = new int[arr1.Length + arr2.Length + arr3.Length];

                arr1.CopyTo(mergedArray, 0);
                arr2.CopyTo(mergedArray, arr1.Length);
                arr3.CopyTo(mergedArray, arr1.Length + arr2.Length);

                // Sorting Array
                Array.Sort(mergedArray);


                // Removing Duplicates
                for (int i = 0; i < mergedArray.Length; i++)
                {
                    for (int j = i + 1; j < mergedArray.Length; j++)
                    {
                        if (mergedArray[i] == mergedArray[j])
                        {
                            mergedArray[j] = 0;

                        }
                    }
                }


                foreach (var i in mergedArray)
                {
                    Console.WriteLine(i);
                }

            }

            // find duplicates and merge multiple arrays (without using functions)
            {
                //int[] arr1 = { 5, 4, 3, 2, 1, 6 };
                //int[] arr2 = { 5, 7, 8, 9, 10, 6 };
                //int[] arr3 = { 11, 9, 3, 19, 10, 15 };

                //// Merging array
                //var mergedArray = new int[arr1.Length + arr2.Length + arr3.Length];
                


                //// Removing Duplicates
                ////var uniqueArray = new int[mergedArray.Length];
                //for (int i = 0; i < mergedArray.Length; i++)
                //{
                //    for (int j = i + 1; j < mergedArray.Length; j++)
                //    {
                //        if (mergedArray[i] == mergedArray[j])
                //        {
                //            //Console.WriteLine(mergedArray[j]);
                //            mergedArray[j] = 0;

                //        }
                //    }
                //}


                //foreach (var i in mergedArray)
                //{
                //    if(i != 0)
                //    {
                //        Console.WriteLine(i);
                //    }
                //}
            }


            // pallindrome number
            {
                //int num = 12013101;
                //string numToString = Convert.ToString(num);
                //bool isPallindrome = false;

                //for (int i = 0; i < numToString.Length / 2; i++)
                //{
                //    if (numToString[i] == numToString[numToString.Length - 1 - i ])
                //    {
                //        isPallindrome = true;
                //    }

                //    else
                //    {
                //        Console.WriteLine("Not a pallindrome number");
                //        isPallindrome = false;
                //        break;
                //    }
                //}

                //if(isPallindrome == true)
                //{
                //    Console.WriteLine("It is a pallindrome number");    
                //}

            }


            // remove numeric values from string
            {
                string s = "M34y n579a1me i055s Sa232lil643";
                byte[] asciiBytes = Encoding.ASCII.GetBytes(s);

                string temp = "";
                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    if (asciiBytes[i] <= 47 || asciiBytes[i] >= 58)
                    {
                        //temp += asciiBytes[i].ToString();
                        char character = (char)asciiBytes[i];
                        string text = character.ToString();
                        temp += text;
                    }
                }

                Console.WriteLine(temp);
            }


        }
    }
}
