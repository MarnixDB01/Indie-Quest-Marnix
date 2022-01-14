using System;

namespace Ordinal_numbers__Algorithm_design____part_3
{
    class Program
    {
        static string OrdinalNumber(int number)
        {
            int lastDigit = number % 10;
            int secondDigit = (number / 10) % 10;

            if (secondDigit == 1)
            {
                Console.WriteLine($"{number}th");
            }
            else if (lastDigit == 1)
            {
                Console.WriteLine($"{number}st");
            }
            else if (lastDigit == 2)
            {
                Console.WriteLine($"{number}nd");
            }
            else if (lastDigit == 3)
            {
                Console.WriteLine($"{number}rd");
            }
            else
            {
                Console.WriteLine($"{number}th");
            }
            return Convert.ToString(number);
        }

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 10, 11, 12, 13, 21, 101, 111, 121 };

            foreach (var number in numbers)
            {
                OrdinalNumber(number);
            }
            Console.ReadKey(true);
        }
    }
}

