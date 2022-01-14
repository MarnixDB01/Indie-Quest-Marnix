using System;

namespace Generate_characters_and_monsters
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int diceRollIndex = 0;

            // Character generation
            int charStrength = 0;
            
            while (diceRollIndex < 3)
            {
                int roll = random.Next(1, 7);
                charStrength += roll;
                diceRollIndex++;
            }
            Console.WriteLine($"A character with {charStrength} strength was created.");

            // one gelatinous cube
            int gelcubeHP = 0;
            diceRollIndex = 0;

            while (diceRollIndex < 8)
            {
                int roll = random.Next(1, 11);
                gelcubeHP += roll;
                diceRollIndex++;
            }
            gelcubeHP += 40;
            Console.WriteLine($"A gelatinous cube with {gelcubeHP} HP appears!");

            // 100 cubes
            int totalcubesHP = 0;

            for (int cubeAmount = 0; cubeAmount < 100; cubeAmount++)
            {
                for (diceRollIndex = 0; diceRollIndex < 8; diceRollIndex++)
                {
                    int roll = random.Next(1, 11);
                    totalcubesHP += roll;
                }
                totalcubesHP += 40;
            }

            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {totalcubesHP} HP. We are doomed!");
        }

    }
}



