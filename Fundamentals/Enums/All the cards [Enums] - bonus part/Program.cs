using System;
using System.IO;

namespace Ace_of____
{
    class Program
    {
        //Possible card suits and ranks
        enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }
        enum Ranks
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        //Choosing card print
        static void DrawCard(Suits suit, Ranks rank)
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

            int linesPerCard = 9;
            int charactersPerLine = 13;
            int startingLine = (int)rank * linesPerCard;
            int startingCharacterIndex = startingLine * charactersPerLine;
            string cardsArt = File.ReadAllText("Cards.txt");
            string cardArt = cardsArt.Substring(startingCharacterIndex, linesPerCard * charactersPerLine - 2);
            string cardOutput = cardArt.Replace("*", symbol);

            Console.WriteLine(cardOutput);
        }

        //Calling method of card printing with input rank/suit
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var random = new Random();

            var chosenSuit = (Suits)random.Next(Enum.GetNames(typeof(Suits)).Length);
            var chosenRank = (Ranks)random.Next(Enum.GetValues(typeof(Ranks)).Length);

            DrawCard(chosenSuit, chosenRank);

            Console.ReadKey(true);
        }
    }
}