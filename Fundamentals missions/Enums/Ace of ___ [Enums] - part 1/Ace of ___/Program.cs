using System;
using System.IO;

namespace Ace_of____
{
    class Program
    {
        //Card Suits, depending on the Suit chosen.
        enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        //Card printing
        static void DrawAce(Suits suit)
        {
            string symbol;
            switch (suit)
            {
                case Suits.Hearts:
                    symbol = "♥";
                    break;
                case Suits.Spades:
                    symbol = "♠";
                    break;
                case Suits.Diamonds:
                    symbol = "♦";
                    break;
                default:
                    symbol = "♣";
                    break;
            }

            string aceArt = File.ReadAllText("Card.txt");
            string aceOutput = aceArt.Replace("*", symbol);
            Console.WriteLine(aceOutput);


            //Card print
            //Line 1
            /*
            Console.Write("╭");
            for (int line1 = 0; line1 < 7; line1++)
            {
                Console.Write("─");
            }
            Console.WriteLine("╮");

            //Line 2
            Console.Write("│A");
            for (int line2 = 0; line2 < 6; line2++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");

            //Line 3
            Console.Write($"|{symbol}");
            for (int line3 = 0; line3 < 6; line3++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            
            //Line 4
            Console.Write("|");
            for (int line3 = 0; line3 < 3; line3++)
            {
                Console.Write(" ");
            }
            Console.Write(symbol);
            for (int line4 = 0; line4 < 3; line4++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");

            //Line 5
            Console.Write("|");
            for (int line5 = 0; line5 < 6; line5++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{symbol}|");

            //Line 6
            Console.Write("|");
            for (int line6 = 0; line6 < 6; line6++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("A|");

            //Line 7
            Console.Write("╰");
            for (int line1 = 0; line1 < 7; line1++)
            {
                Console.Write("─");
            }
            Console.WriteLine("╯");
            */
        }
        
        //Calling method of printing the card with the value of which Suit.
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var random = new Random();

            var chosenSuit = (Suits)random.Next(Enum.GetNames(typeof(Suits)).Length);

            DrawAce(chosenSuit);

            Console.ReadKey(true);
        }
    }
}