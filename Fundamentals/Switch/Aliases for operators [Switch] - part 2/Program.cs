using System;

namespace Simple_Calculator__Switch____part_2
{
    class Program
    {
        //Equation method
        static void Equation(string equation)
        {
            int firstSpaceIndex = equation.IndexOf(" ");
            int lastSpaceIndex = equation.LastIndexOf(" ");
            string operation = equation.Substring(firstSpaceIndex + 1, lastSpaceIndex - firstSpaceIndex - 1);

            double a = Convert.ToDouble(equation.Substring(0, firstSpaceIndex));
            double b = Convert.ToDouble(equation.Substring(lastSpaceIndex + 1, equation.Length - lastSpaceIndex - 1));
            double result = 0;

            // Calculations depending on which operator!
            // switch (Convert.ToString(numbersArray[(numbersArray.Length - numbersArray.Length)..(numbersArray.Length - 2)]))
            switch (operation)
            {
                case "+":
                case "plus":
                case "add":
                    result = a + b;
                    break;
                case "minus":
                case "-":
                case "remove":
                    result = a - b;
                    break;
                case "times":
                case "multiplied by":
                case "*":
                    result = a * b;
                    break;
                case "divided by":
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


