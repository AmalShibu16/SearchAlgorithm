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
        static int counter = 0; //counter for watch
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        static int userOption1;
        static int userOption2;

        static void Main(string[] args)
        {
            long timeTaken;
            watch.Start();// start the watch

            List<double> listOfDoubles = new List<double>();
            List<string> listOfStrings = new List<string>();

            userOption1 = -1;
            // For List Type Menu
            while (userOption1 < 0 || userOption1 > 3) // loop to check if option is valid or not
            {
                Console.WriteLine("MENU");
                Console.WriteLine("SELECT THE TYPE OF LIST YOU WANT TO IMPLEMENT");
                Console.WriteLine("1. Numerical List");
                Console.WriteLine("2. String List");
                userOption1 = int.Parse(Console.ReadLine());
                if (userOption1 < 0 || userOption1 > 3)
                {
                    Console.WriteLine("Inavlid Input. Please enter an option between 1 and 3.");
                }
            }

            int size = 0;
            while (size < 1 || size > 1000) // loop to check if option is valid or not
            {
                Console.WriteLine("\n How many elements do you need in your list?(1-1000) ");
                bool isValid = int.TryParse(Console.ReadLine(), out size);
                if (!isValid || size < 1 || size > 1000)
                {
                    Console.WriteLine("Inavlid Input. Please enter a number between 1 and 1000.");
                }
            }

            if (userOption1 == 1)
            {
                PopulateListWithRandomDoubles(ref listOfDoubles, size);
            }
            else
            {
                PopulateListWithRandomStrings(ref listOfStrings, size);
            }

            // For Search Menu
            userOption2 = -1;
            while (userOption2 < 0 || userOption2 > 4) // loop to check if option is valid or not
            {
                Console.WriteLine("\n SELECT THE SEARCH METHOD YOU WANT TO IMPLEMENT");
                Console.WriteLine("1. Linear Search");
                Console.WriteLine("2. Binary Search");
                Console.WriteLine("3. Jump Search");
                userOption2 = int.Parse(Console.ReadLine());
                if (userOption2 < 0 || userOption2 > 4)
                {
                    Console.WriteLine("Inavlid Input. Please enter an option between 1 and 3.");
                }
            }
            if (userOption1 == 1)
                doublePrintList(listOfDoubles);
            else
                stringPrintList(listOfStrings);

            watch.Stop();// stop the watch
            timeTaken = watch.ElapsedMilliseconds; // saved the time in a variable
            TimeUsed(timeTaken);

            watch.Reset();// reset the time to start the time again
            watch.Start();

            if (userOption1 == 1 && (userOption2 == 1 || userOption2 == 2 || userOption2 == 3))
                doubleRequestSearch(listOfDoubles);

            else
                stringRequestSearch(listOfStrings);

            watch.Stop();
            timeTaken = watch.ElapsedMilliseconds; // saved the time in a variable
            TimeUsed(timeTaken);

            Console.ReadKey();
        }

        static void doubleRequestSearch(List<double> list)
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
                int index;
                if (userOption2 == 1)
                    index = LinearSearch.Perform(searchValue, list);
                else if (userOption2 == 2)
                    index = BinarySearch.Perform(searchValue, list);
                else
                    index = JumpSearch.Perform(searchValue, list);

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
        static void stringRequestSearch(List<string> list)
        {
            counter = 1;
            Console.WriteLine("What value would you like to search for? ");
            string searchValue = Console.ReadLine();
            int index;

            if (userOption2 == 1)
                index = LinearSearch.Perform(searchValue, list);
            else if (userOption2 == 2)
                index = BinarySearch.Perform(searchValue, list);
            else
                index = JumpSearch.Perform(searchValue, list);

            if (index < 0)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine("Found at: " + (index + 1));
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

        public static void PopulateListWithRandomStrings(ref List<string> strings, int size)
        {
            for (int a = 0; a < size; a++)
            {
                int stringlength = randomGenerator.Next(4, 8);
                StringBuilder generatedString = new StringBuilder();

                for (int i = 0; i < stringlength; i++)
                {
                    int randvalue = randomGenerator.Next(0, 26);
                    char letter = Convert.ToChar(randvalue + 65);// 65 ASCII value of "A"
                    generatedString.Append(letter);
                }
                strings.Add(generatedString.ToString());
            }
            strings.Sort();
        }


        static void doublePrintList(List<double> list)
        {
            Console.WriteLine("\n\nLIST PRINT\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + list[i].ToString());
            }

            Console.WriteLine("\n END \n");
        }
        static void stringPrintList(List<string> strings)
        {

            Console.WriteLine("\n\nLIST PRINT\n");
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + strings[i]);
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
