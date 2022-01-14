using System;
using System.Linq;

namespace Seasons____Arrays__part_1
{
    class Program
    {
        static string CreateDayDescription(int day, int seasonIndex, int year)
        {
            string[] seasonNames = { "Spring", "Summer", "Fall", "Winter" };

            string dayDescription = ($"{day} day of {seasonNames[seasonIndex]} in the year {year}");
            return dayDescription;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CreateDayDescription(7, 1, 132));
            Console.WriteLine();

            Console.WriteLine(CreateDayDescription(41, 3, 22));
            Console.WriteLine();

            Console.WriteLine(CreateDayDescription(3, 0, 1601));
            Console.WriteLine();

            Console.ReadKey(true);
        }
    }
}
