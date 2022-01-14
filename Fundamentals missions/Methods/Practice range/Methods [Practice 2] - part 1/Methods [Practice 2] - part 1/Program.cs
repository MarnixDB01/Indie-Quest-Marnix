using System;

namespace Methods__Practice_2____part_1
{
    class Program
    {
        static int Power(int a, int b)
        {
            int aSquared = a * a;
            int equation = a * a ^ (b - 1);

            return equation;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Insert Integer A");
            Console.Write(">");
            string inputA = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Insert Integer B");
            Console.Write(">");
            string inputB = Console.ReadLine();

           Power(Convert.ToInt32(inputA), Convert.ToInt32(inputB));
        }
    }
}
