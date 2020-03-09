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
                     Net = File.ReadAllLines(@"C:\Users\Billy\source\repos\billyedwards3017\CMP1124MAlgorithmsAssignment1\Net_1_256.txt");
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

            int[] NetInt = Array.ConvertAll(Net, int.Parse);
            for (int log = 0; log < NetInt.Length; log++)
            {
                Console.WriteLine(NetInt[log]);
                Console.ReadKey();
            }


        }

        public static void QuickSort(int [] data)
        {



        }
    }
}
