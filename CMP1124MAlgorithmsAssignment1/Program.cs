using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CMP1124MAlgorithmsAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {

           
            
            Console.WriteLine("Would you like to work with log 1 (1), log 2 (2) or log 3 (3)");

            int ans = Convert.ToInt32(Console.ReadLine());

            string[] Net = new string[255]; 
            do
            {
                if (ans == 1)
                {
                     Net = File.ReadAllLines(@"C:\Users\HP\source\repos\billyedwards3017\CMP1124MAlgorithmsAssignment1\Net_1_256.txt");
                }
                else if (ans == 2)
                {
                     Net = File.ReadAllLines(@"C:\Users\Billy\source\repos\billyedwards3017\CMP1124MAlgorithmsAssignment1\Net_2_256.txt");
                   
                }
                else if (ans == 3)
                {
                     Net = File.ReadAllLines(@"C:\Users\Billy\source\repos\billyedwards3017\CMP1124MAlgorithmsAssignment1\Net_3_256.txt");
                }
                else
                {
                    Console.WriteLine("You have entered a value that is not 1, 2 or 3. Please enter one of these values");

                }
            } while (ans != 1 && ans != 2 && ans != 3);
            //This is the code which allows the user to choose which string they would like the code to interact with


            int[] NetInt = Array.ConvertAll(Net, int.Parse);
            //This line converts the string array of the inputted text file into a integer array of the same data for the sorting algorithm

            QuickSort(ref NetInt);
            //This line is calling the Quick Sort algorithm on the integer array.

            int[] DescNetInt = new int[256]; 
            CreateDescendingList(NetInt, ref DescNetInt);
            //This line creates a new array which shows the sorted array in descending order 

            DisplayValues(NetInt, DescNetInt);
            //This line calls a method which displays every 10th digit of both the ascending and descending arrays 

            List<int> foundPositions = new List<int>();

            Console.WriteLine("Enter a value you would like to find in the array");
            int SearchValue = Convert.ToInt32(Console.ReadLine());
            LinearSearch(NetInt, SearchValue, ref foundPositions);




        }

        public static void QuickSort(ref int[] data)
        {
            QuickSort(ref data, 0, data.Length - 1);
        }

        public static void QuickSort(ref int[] data, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = data[(left + right)/2];
            int temp;

            do
            {
                while ((data[i] < pivot) && (i < right)) i++;
                while ((pivot < data[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j)
            {
                QuickSort(ref data, left, j);
            }
            if (i < right)
            {
                QuickSort(ref data, i, right);
            }

           
        }
        public static void CreateDescendingList(int[] array, ref int[] OutputArray)
        {

            for (int x = 0; x < array.Length; x++)
            {
                OutputArray[x] = array[((array.Length-1) - x)];
            }
        }

        public static void DisplayValues(int[] ascArray, int[] descArray)
        {

            Console.WriteLine("The log sorted in ascending order, displaying every tenth item");
            for (int x = 0; x < ascArray.Length; x += 10)
            {
                Console.WriteLine(ascArray[x]);
            }
            Console.WriteLine("");

            Console.WriteLine("The log sorted in descending order, displaying every tenth item");
            for (int x = 0; x < descArray.Length; x += 10)
            {
                Console.WriteLine(descArray[x]);
            }

        }
        

        

        public static void LinearSearch(int[] array, int ItemSearchedFor, ref List<int> foundPositions)
        {
            
            int currentValue = 0;
            int MaxValue = array.Length;
 
            int NoFound = 0;
            do
            {
                if (array[currentValue] == ItemSearchedFor)
                {
                    foundPositions.Add(currentValue);
                    NoFound++;
                    currentValue += 1;
                }
                else
                {
                    currentValue += 1;
                }

            } while (currentValue<MaxValue);

            if (foundPositions.Count > 0)
            {
                Console.WriteLine("Input integer has been found in the list at the following positions;");
               for (int x = 0; x < foundPositions.Count; x++)
                {
                    Console.WriteLine(foundPositions[x]);
                }

            }
            else
            {
                Console.WriteLine("Input integer has not been found in the list");
            }

        }

    }
}
