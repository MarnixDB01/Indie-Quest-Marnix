using System;

namespace Roll_till_six
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int diceRoll;
            int totalScore = 0;

            do
            {
                diceRoll = random.Next(1, 7);
                Console.WriteLine($"The player rolled: {diceRoll}");
                totalScore += diceRoll;

            } while (diceRoll < 6);

            Console.WriteLine($"Total score: {totalScore}");
        }
    }
}
