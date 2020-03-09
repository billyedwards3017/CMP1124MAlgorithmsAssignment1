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

            string[] Net1 = File.ReadAllLines(@"C:\Users\Billy\source\repos\billyedwards3017\CMP1124MAlgorithmsAssignment1");

            foreach (string log in Net1)
            {
                Console.WriteLine(log);
                Console.ReadKey();
            }

        }
    }
}
