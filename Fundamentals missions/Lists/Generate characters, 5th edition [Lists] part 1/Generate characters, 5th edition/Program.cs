using System;
using System.Collections.Generic;

namespace Generate_characters__5th_edition
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var abilityScores = new List<int>();

            for (int abilityscoreLine = 0; abilityscoreLine < 6; abilityscoreLine++)
            {
                int totalScore = 0;
                Console.Write("You roll: ");
                var diceRolls = new List<int>();

                for (int rolls = 0; rolls < 4; rolls++)
                {
                    int diceRoll = random.Next(1, 7);
                    diceRolls.Add(diceRoll);
                    totalScore += diceRoll;
                }
                Console.Write(String.Join(", ", diceRolls));
                diceRolls.Sort();
                totalScore -= diceRolls[0];
                abilityScores.Add(totalScore);

                Console.WriteLine($" The ability score is {totalScore}");

            }
            abilityScores.Sort();
            Console.Write("Your available ability scores are ");
            Console.Write(string.Join(", ", abilityScores));
            Console.ReadKey(true);
        }

    }
}

