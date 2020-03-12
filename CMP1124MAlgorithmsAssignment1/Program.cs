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
            // This section of code is to get user input into what file the program should use



            string[] Net = new string[255];

            if (vAns == 2)
            {
                Array.Resize(ref Net, 2047);
            }
            // This section resizes the input array for if the use rselected a higher length file

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

            Console.WriteLine("Would you like to use Quick Sort (1), Bubble Sort (2), Insertion Sort (3) or Selection Sort (4)");
            int sortChoice = Convert.ToInt32(Console.ReadLine());
            //This segment lets the uer choose whether they want to use the sorting method you want.
            if (sortChoice == 1)
            {
                QuickSort(ref NetInt, ref sortCount);
            }
            else if (sortChoice == 2)
            {

                BubbleSort(ref NetInt, ref sortCount);
            }
            else if (sortChoice == 3)
            {
                InsertionSort(ref NetInt, ref sortCount);
            }
            else if (sortChoice == 4)
            {
                SelectionSort(ref NetInt, ref sortCount);
            }

            int[] DescNetInt = new int[255];
            if (vAns == 2)
            {
                Array.Resize(ref DescNetInt, 2047);
            }
            CreateDescendingList(NetInt, ref DescNetInt);
            //This line creates a new array which shows the sorted array in descending order 

            DisplayValues(NetInt, DescNetInt, vAns);
            //This line calls a method which displays every 10th digit of both the ascending and descending arrays 

            Console.WriteLine($"This sort took {sortCount} steps");
            //This gives the time complexity of the chosen sorting program



            Console.WriteLine("Enter a value you would like to find in the array");
            int SearchValue = Convert.ToInt32(Console.ReadLine());
            //This lets you enter a value to search for in the log
            int searchCount = 0;
            List<int> foundPositions = new List<int>();
            //this list will hold all the positions that contain the number being searched for.
            Console.WriteLine("would you like to use Linear Search (1) or Binary Search (2)?");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                LinearSearch(NetInt, SearchValue, ref foundPositions, ref searchCount);
                //This calls the linear search method
            }
            else if (choice == 2)
            {
                bool found = false;
                int closest = RecursiveBinary(NetInt, SearchValue, 0, NetInt.Length - 1, ((NetInt.Length - 1) / 2), ref found, ref foundPositions, ref searchCount);
                //this calls the binary search method and displays the values
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
                    Console.WriteLine($"Value not found, closest value is {NetInt[closest]} at position {closest}");
                }
            }
            Console.WriteLine($"The search algorithm took {searchCount} amount of steps");




        }

        public static void QuickSort(ref int[] data, ref int count)
        {
            QuickSort(ref data, 0, data.Length - 1, ref count);
            //This method exists to fill in extra parameters 
        }

        public static void QuickSort(ref int[] data, int left, int right, ref int count)
        {
            int i = left;
            int j = right;
            int pivot = data[(left + right) / 2];
            int temp;
            //declaring the required variables for this method
            //pivot is declared as the midpoint 
            do
            {
                

                while ((data[i] < pivot) && (i < right))
                {
                    i++;
                    //this checks if the leftmost unsorted digit is less than the pivot and if it is then we check the next value
                }
                while ((pivot < data[j]) && (j > left))
                {
                    j--;
                    // this does the same for the rightmost value
                }

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                   
                    //this swaps the values checked and moves them into a more sorted order using a temp variable
                }
                count++;
            } while (i <= j);

            if (left < j)
            {
                QuickSort(ref data, left, j, ref count);
            }
            if (i < right)
            {
                QuickSort(ref data, i, right, ref count);
            }
            //recursively calls the quicksort again. divide and conquer technique

        }
        public static void CreateDescendingList(int[] array, ref int[] OutputArray)
        {

            for (int x = 0; x < array.Length - 1; x++)
            {
                OutputArray[x] = array[((array.Length - 1) - x)];
            }
            //this adds to the recently created array every element in the original array but in a reverse order 
        }

        public static void DisplayValues(int[] ascArray, int[] descArray, int vAns)
        {
            if (vAns == 1)
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
            else if (vAns == 2)
            {
                Console.WriteLine("The log sorted in ascending order, displaying every 50th item");
                for (int x = 0; x < ascArray.Length; x += 50)
                {
                    Console.WriteLine(ascArray[x]);
                }
                Console.WriteLine("");

                Console.WriteLine("The log sorted in descending order, displaying every 50th item");
                for (int x = 0; x < descArray.Length; x += 50)
                {
                    Console.WriteLine(descArray[x]);
                }

            }
            //this displays every 10th value of the ascending and descending arrays if using the smaller files, or every 50th value if using the larger files.
        }




        public static void LinearSearch(int[] array, int ItemSearchedFor, ref List<int> foundPositions, ref int count)
        {
            int currentValue = 0;
            int MaxValue = array.Length;
            bool MoreOrLess = false;
            int closestValue = 0;
            int closestLocation = 0;
            int NoFound = 0;
            //declares the required variables
            do
            {
                count++;//counter tick
                if (array[currentValue] == ItemSearchedFor)
                {
                    foundPositions.Add(currentValue);
                    NoFound++;
                    currentValue += 1;
                    //if the currently selected element of the array is the same as the item beign searched for, the position of the value is added to a list.
                }
                else
                {
                    if (MoreOrLess == false && array[currentValue] > ItemSearchedFor)
                    {
                        MoreOrLess = true;
                        //this checks if the value has been passed yet.
                        if ((array[currentValue] - ItemSearchedFor) < (ItemSearchedFor - array[(currentValue - 1)]))
                        {
                            closestValue = array[currentValue];
                            closestLocation = currentValue;

                        }
                        else
                        {
                            closestValue = array[(currentValue - 1)];
                            closestLocation = (currentValue - 1);
                        }
                        //this checks if the closest value to the searched item is the value lower or the value higher.
                    }
                    currentValue += 1;
                }

            } while (currentValue < MaxValue);

            if (foundPositions.Count > 0)
            {
                Console.WriteLine("(Keep in mind the list starts at 0)");
                Console.WriteLine("Input integer has been found in the list at the following positions;");
                for (int x = 0; x < foundPositions.Count; x++)
                {
                    Console.WriteLine(foundPositions[x]);
                }
                //this lists the positions of the searched value
            }
            else
            {
                Console.WriteLine("(Keep in mind the list starts at 0)");
                Console.WriteLine("Input integer has not been found in the list");
                Console.WriteLine($"Your closest value is {closestValue} and is in location {closestLocation}");
                //this displays the closest value to the searched value, if the value is not in the array.
            }

        }

        public static int RecursiveBinary(int[] array, int ItemSearchedFor, int min, int max, int midpoint, ref bool found, ref List<int> FoundPositions, ref int count)
        {
            count++;
            //ticks the counter
            if (min > max)
            {
                found = false;
                return midpoint;
                //this is the base case if the value is not in the array
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
                    //this is the base case if the value is found, this code then calls methods to check both sides of the selected value to see if the variable being searched for is duplicated
                }
                else if (ItemSearchedFor < array[midpoint])
                {
                    return RecursiveBinary(array, ItemSearchedFor, min, midpoint - 1, ((min + (midpoint - 1)) / 2), ref found, ref FoundPositions, ref count);
                    //this recursively calls the method with the max value being shifted down to the value below the midpoint, as the value being searched fo rhas to be in the lower half.
                }
                else
                {
                    return RecursiveBinary(array, ItemSearchedFor, midpoint + 1, max, (((midpoint + 1) + max) / 2), ref found, ref FoundPositions, ref count);
                    //this recursively calls the method with the max value being shifted down to the value below the midpoint, as the value being searched fo rhas to be in the lower half.

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
            //this method checks the values to the left of the found variable in the binary search to see if the found value has multiple elements in the array to the left of the selected array
        }

        public static int CheckRight(int[] array, int midpoint, ref List<int> FoundPositions)
        {
            if (array[midpoint] == array[midpoint + 1])
            {
                FoundPositions.Add(midpoint + 1);
                CheckRight(array, (midpoint + 1), ref FoundPositions);
            }
            return -1;
            //this method checks the values to the right of the found variable in the binary search to see if the found value has multiple elements in the array to the right of the selected array 
        }

        public static void BubbleSort(ref int[] array, ref int count)
        {
            int temp;
            for (int x = 0; x < array.Length - 1; x++)
            {
                //the following code will iterate for every value in the array
                for (int y = 0; y < array.Length - 1; y++)
                {
                    //the code will iterate through each value
                    count++;
                    if (array[y] > array[y + 1])
                    {
                        temp = array[y + 1];
                        array[y + 1] = array[y];
                        array[y] = temp;
                        //this will swap the currently selected value with the next one along if the next value is smaller than the selected valu
                    }
                }
            }

        }

        public static void InsertionSort(ref int[] array, ref int count)
        {

            for (int x = 1; x < array.Length; x++)
            {
                int key = array[x];
                int y = x - 1;
                //this declares required variables

                while (y >= 0 && array[y] > key)
                {
                    count++;
                    array[y + 1] = array[y];
                    y = y - 1;
                    //this moves the selected variable down the array if the selected variable is less than the ones behind it
                }
                array[y + 1] = key;
            }                      
        }

        public static void SelectionSort(ref int[] array, ref int count)
        {
           for (int x = 0; x < array.Length - 1; x++)
            {
                int min = x;
                for (int y = 0; y < array.Length - 1; y++)
                {
                    count++;
                    if (array[y] > array[min])
                    {
                        min = y;
                        SwapSelection(ref array[x], ref array[min]);
                        //checks to see if the value selected is larger than the currently smallest value, if it is, moves the minimum to this new value then calls the swapping method
                    }
                }
            }

        }

        public static void SwapSelection(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
            //this submethod does the swapping function for the selection swap method
        }
    }
}