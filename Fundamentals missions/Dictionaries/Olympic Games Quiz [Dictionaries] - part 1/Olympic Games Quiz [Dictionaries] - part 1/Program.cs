using System;
using System.Collections.Generic;

namespace Olympic_Games_Quiz__Dictionaries____part_1
{
    class Program
    {
        //Random year for quiz calculation
        static int yearCalculation()
        {
            var random = new Random();

            int result = 2000 + random.Next(0, 11) * 2;
            return result;
        }

        //Dictionary + quiz & answer
        static void olympicgamesDictionary(int year)
        {
            IDictionary<int, string> hostCountries = new Dictionary<int, string>();
            {
                hostCountries.Add(2000, "Australia");
                hostCountries.Add(2002, "United States");
                hostCountries.Add(2004, "Greece");
                hostCountries.Add(2006, "Italy");
                hostCountries.Add(2008, "China");
                hostCountries.Add(2010, "Canada");
                hostCountries.Add(2012, "United Kingdom");
                hostCountries.Add(2014, "Russia");
                hostCountries.Add(2016, "Brazil");
                hostCountries.Add(2018, "South Korea");
                hostCountries.Add(2020, "Japan");
            }

            Console.Write($"Which country hosted the Summer Olympic Games in {year}?\n> ");

            string countryInput = Console.ReadLine();
            Console.WriteLine();

            if (hostCountries.ContainsKey(year)) ;
            {
                if (hostCountries[year] == countryInput)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect!, it was {hostCountries[year]}");
                }
            }
        }

        //Method call with values
        static void Main(string[] args)
        {
            olympicgamesDictionary(yearCalculation());

            Console.ReadKey(true);
        }
    }
}

