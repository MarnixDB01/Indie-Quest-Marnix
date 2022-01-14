using System;

namespace Simple_Calculator__Switch____part_1
{
    class Program
    {
        //Equation method
        static void Equation(string numbers)
        {
            string[] numbersArray = numbers.Split(' ');
            double a = Convert.ToInt32(numbersArray[0]);
            double b = Convert.ToInt32(numbersArray[2]);
            double result = 0;

            // Calculations depending on which operator!
            switch (numbersArray[1])
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }
            Console.WriteLine($"The price was set to {result}.");
        }

        //Main method
        static void Main(string[] args)
        {
            Console.Write("Set the price: ");
            string Input = Console.ReadLine();

            Equation(Input);

            Console.ReadKey(true);
        }
    }
}

