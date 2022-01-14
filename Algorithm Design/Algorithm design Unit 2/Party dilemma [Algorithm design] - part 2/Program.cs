using System;

namespace Party_dilemma__Algorithm_design____part_2
{
    class Program
    {
        static double Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static void Main(string[] args)
        {
            for (int factorialIndex = 0; factorialIndex < 21; factorialIndex++)
            {
                Console.Write($"{factorialIndex}! = ");
                Console.WriteLine(Factorial(factorialIndex));
            }
            Console.ReadKey(true);
        }
    }
}


