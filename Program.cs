using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SearchAlgorithm
{
    internal class Program
    {
        static Random randomGenerator = new Random();
        static int counter = 0;
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        static void Main(string[] args)
        {
            long timeTaken;
            watch.Start();// start the watch

            List<double> listOfDoubles = new List<double>();

            PopulateListWithRandomDoubles(ref listOfDoubles, 100);
            PrintList(listOfDoubles);
            watch.Stop();// stop the watch
            timeTaken = watch.ElapsedMilliseconds; // saved the time in a variable
            TimeUsed(timeTaken);

            watch.Reset();// reset the time to start the time again
            watch.Start();
            RequestSearch(listOfDoubles);
            PrintList(listOfDoubles);
            watch.Stop();
            timeTaken = watch.ElapsedMilliseconds; // saved the time in a variable
            TimeUsed(timeTaken);

            Console.ReadKey();
        }

        static void RequestSearch(List<double> list)
        {
            counter = 1;
            Double searchValue;
            Console.WriteLine("What value would you like to search for? ");

            //string input = Console.ReadLine();
            //searchValue = Convert.ToDouble(input);
            //if (Double.TryParse(Console.ReadLine(), out searchValue))
            //{ 
            //}

            if (Double.TryParse(Console.ReadLine(), out searchValue))
            {
                //int index = LinearSearch.Perform(searchValue, list);
                int index = JumpSearch.Perform(searchValue, list);
                //int index = BinarySearch.Perform(searchValue, list);
                if (index < 0)
                {
                    Console.WriteLine("Not Found");
                }
                else
                {
                    Console.WriteLine("Found at: " + (index + 1));
                }

            }
        }

        static void PopulateListWithRandomDoubles(ref List<double> list, int size)
        {
            for (int i = 0; i < size; i++)
            {
                double twoDigitDouble = Double.Parse(randomGenerator.NextDouble().ToString("0.000"));
                list.Add(twoDigitDouble);
            }
            list.Sort();
        }

        static void PrintList(List<double> list)
        {
            Console.WriteLine("\n\nLIST PRINT\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + list[i].ToString());
            }

            Console.WriteLine("\n END \n");
        }
        static void TimeUsed(long time)
        {
            if (counter == 0)
            {
                Console.WriteLine("The time taken before the search is " + time + "ms");
            }
            else
            {
                Console.WriteLine("The time taken after the search is " + time + "ms");
            }
        }
    }



}
