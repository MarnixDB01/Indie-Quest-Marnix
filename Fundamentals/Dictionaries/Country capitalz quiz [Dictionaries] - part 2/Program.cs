using System;
using System.Collections.Generic;

namespace Country_capitalz_quiz__Dictionaries____part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var capitals = new SortedList<string, string>()
            {
                {"Sweden", "Stockholm"},
                {"Netherlands", "Amsterdam"},
                {"Germany", "Berlin"},
                {"Australia", "Canberra"},
                {"Denmark", "Copenhagen"},
                {"Finland", "Helsinki"},
                {"Ukraine", "Kyiv"},
                {"Slovenia", "Ljubljana"},
                {"Norway", "Oslo"},
                {"Italy", "Rome"},
                {"Japan", "Tokyo"},
                {"South Korea", "Seoul"}
            };
            var countries = new List<string>(capitals.Keys);

            var random = new Random();
            int countryIndex = random.Next(capitals.Count);

            string countryName = countries[countryIndex];
            Console.WriteLine($"What is the capital of {countryName}");

            string capitalInput = Console.ReadLine();
            Console.WriteLine();

            string correctResult = capitals[countryName];

            if (correctResult == capitalInput)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect! The capital is {correctResult}");
            }
            Console.ReadKey(true);
        }
    }
}

