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

            Console.WriteLine("Would you like to work with the 256 log (1) or the 2048 (2) log version?");

            int vAns = Convert.ToInt32(Console.ReadLine());


            string[] Net = new string[255];

            if (vAns == 2)
            {
                Array.Resize(ref Net, 2047);
            }

            do
            {
                if (vAns == 1)
                {
                    if (ans == 1)
                    {
                        Net = File.ReadAllLines(@"Net_1_256.txt");
                    }
                    else if (ans == 2)
                    {
                        Net = File.ReadAllLines(@"Net_2_256.txt");

                    }
                    else if (ans == 3)
                    {
                        Net = File.ReadAllLines(@"Net_3_256.txt");
                    }
                    else
                    {
                        Console.WriteLine("You have entered a log value that is not 1, 2 or 3. Please enter one of these values");

                    }
                }
                else if (vAns == 2)
                {
                    if (ans == 1)
                    {
                        Net = File.ReadAllLines(@"Net_1_2048.txt");
                    }
                    else if (ans == 2)
                    {
                        Net = File.ReadAllLines(@"Net_2_2048.txt");

                    }
                    else if (ans == 3)
                    {
                        Net = File.ReadAllLines(@"Net_3_2048.txt");
                    }
                    else
                    {
                        Console.WriteLine("You have entered a log value that is not 1, 2 or 3. Please enter one of these values");

                    }
                }
            } while (ans != 1 && ans != 2 && ans != 3);
            //This is the code which allows the user to choose which string they would like the code to interact with


            int[] NetInt = Array.ConvertAll(Net, int.Parse);
            //This line converts the string array of the inputted text file into a integer array of the same data for the sorting algorithm

            int sortCount = 0;

            Console.WriteLine("Would you like to use quicksort (1) or bubblesort (2)");
            int sortChoice = Convert.ToInt32(Console.ReadLine());

            if (sortChoice == 1)
            {
                QuickSort(ref NetInt, ref sortCount);
            }
            else if (sortChoice == 2)
            {

                BubbleSort(ref NetInt, ref sortCount);
            }

            QuickSort(ref NetInt, ref sortCount);
            //This line is calling the Quick Sort algorithm on the integer array.

            int[] DescNetInt = new int[255]; 
            if (vAns == 2)
            {
                Array.Resize(ref DescNetInt, 2047);
            }
            CreateDescendingList(NetInt, ref DescNetInt);
            //This line creates a new array which shows the sorted array in descending order 

            DisplayValues(NetInt, DescNetInt);
            //This line calls a method which displays every 10th digit of both the ascending and descending arrays 

            Console.WriteLine($"This sort took {sortCount} steps");
            List<int> foundPositions = new List<int>();

            Console.WriteLine("Enter a value you would like to find in the array");
            int SearchValue = Convert.ToInt32(Console.ReadLine());

            int searchCount = 0;

            Console.WriteLine("would you like to use linear search (1) or binary search (2)?");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                LinearSearch(NetInt, SearchValue, ref foundPositions, ref searchCount);
            }
            else if (choice == 2)
            {
                bool found = false;
               int closest = RecursiveBinary(NetInt, SearchValue, 0, NetInt.Length - 1,((NetInt.Length-1)/2) , ref found, ref foundPositions, ref searchCount);

                if (foundPositions.Count > 0) {
                    Console.WriteLine("(Keep in mind the list starts at 0)");
                    Console.WriteLine("Input integer has been found in the list at the following positions;");
                    for (int x = 0; x < foundPositions.Count; x++)
                    {
                        Console.WriteLine(foundPositions[x]);
                    }
                } else
                {
                    Console.WriteLine("(Keep in mind the list starts at 0)");
                    Console.WriteLine($"Value not found, closest value is {closest}");
                }
            }
            Console.WriteLine($"The search algorithm took {searchCount} amount of steps");




        }

        public static void QuickSort(ref int[] data, ref int count)
        {
            QuickSort(ref data, 0, data.Length - 1, ref count);
        }

        public static void QuickSort(ref int[] data, int left, int right, ref int count)
        {
            int i = left;
            int j = right;
            int pivot = data[(left + right)/2];
            int temp;

            do
            {
                count++;

                while ((data[i] < pivot) && (i < right))
                {
                    i++;
                }
                while ((pivot < data[j]) && (j > left))
                {
                    j--;
                }

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
                QuickSort(ref data, left, j, ref count);
            }
            if (i < right)
            {
                QuickSort(ref data, i, right, ref count);
            }

           
        }
        public static void CreateDescendingList(int[] array, ref int[] OutputArray)
        {

            for (int x = 0; x < array.Length-1; x++)
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
        

        

        public static void LinearSearch(int[] array, int ItemSearchedFor, ref List<int> foundPositions, ref int count)
        {          
            int currentValue = 0;
            int MaxValue = array.Length;
            bool MoreOrLess = false;
            int closestValue = 0;
            int closestLocation = 0;
            int NoFound = 0;

            do
            {
                count++;
                if (array[currentValue] == ItemSearchedFor)
                {
                    foundPositions.Add(currentValue);
                    NoFound++;
                    currentValue += 1;
                }
                else
                {
                    if (MoreOrLess == false && array[currentValue] > ItemSearchedFor)
                    {
                        MoreOrLess = true;

                        if ((array[currentValue] - ItemSearchedFor) < (ItemSearchedFor - array[(currentValue-1)]))
                        {
                            closestValue = array[currentValue];
                            closestLocation = currentValue;
                        }
                        else
                        {
                            closestValue = array[(currentValue - 1)];
                            closestLocation = (currentValue - 1);
                        }
                    }
                    currentValue += 1;
                }

            } while (currentValue<MaxValue);

            if (foundPositions.Count > 0)
            {
                Console.WriteLine("(Keep in mind the list starts at 0)");
                Console.WriteLine("Input integer has been found in the list at the following positions;");
               for (int x = 0; x < foundPositions.Count; x++)
                {
                    Console.WriteLine(foundPositions[x]);
                }

            }
            else
            {
                Console.WriteLine("(Keep in mind the list starts at 0)");
                Console.WriteLine("Input integer has not been found in the list");
                Console.WriteLine($"Your closest value is {closestValue} and is in location {closestLocation}");                    
            }

        }

        public static int RecursiveBinary(int[] array, int ItemSearchedFor, int min, int max, int midpoint, ref bool found, ref List <int> FoundPositions, ref int count)
        {
            count++;
            if (min > max)
            {
                found = false;
                return midpoint;
            }
            else
            {
                midpoint = (max + min) / 2;

                if (ItemSearchedFor == array[midpoint])
                {
                    found = true;
                    FoundPositions.Add(midpoint);
                    CheckLeft(array, midpoint, ref FoundPositions);
                    CheckRight(array, midpoint, ref FoundPositions);
                    return midpoint;
                }
                else if (ItemSearchedFor < array[midpoint])
                {
                    return RecursiveBinary(array, ItemSearchedFor, min, midpoint - 1, ((min+(midpoint - 1))/2), ref found, ref FoundPositions, ref count);
                }
                else
                {
                    return RecursiveBinary(array, ItemSearchedFor, midpoint + 1, max, (((midpoint + 1) + max)/2), ref found, ref FoundPositions, ref count);
                }
            }


        }

        public static int CheckLeft(int[] array, int midpoint, ref List<int> FoundPositions)
        {
            if (array[midpoint] == array[midpoint - 1])
            {
                FoundPositions.Add(midpoint - 1);
                CheckLeft(array, (midpoint - 1), ref FoundPositions);
            }            
                return -1;
        }

        public static int CheckRight(int[] array, int midpoint, ref List<int> FoundPositions)
        {
            if (array[midpoint] == array[midpoint + 1])
            {
                FoundPositions.Add(midpoint + 1);
                CheckRight(array, (midpoint + 1), ref FoundPositions);
            }
                return -1;
        }

        public static void BubbleSort(ref int[] array, ref int count)
        {
            int temp;
            for (int x = 0; x < array.Length-1; x++)
            {
                for (int y = 0; y < array.Length - 1; y++)
                {
                    count++; 
                    if (array[y] > array[y+1])
                    {
                        temp = array[y + 1];
                        array[y + 1] = array[y];
                        array[y] = temp;
                    }
                }
            }

        }
    }
}
