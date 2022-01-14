using System;
using System.Collections.Generic;

namespace Basilisk_Boss_battle__lists_part_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var party = new List<string> { "Razor", "Brayton", "Darwyn", "Winfrey" };
            Console.Write("A party of warriors: ");
            Console.WriteLine(String.Join(", ", party));

            int basiliskHP = 0;

            for (int rolls = 0; rolls < 8; rolls++)
            {
                basiliskHP += random.Next(1, 9);
            }
            basiliskHP += 16;
            Console.WriteLine($"A basilisk with {basiliskHP} health appears");
            Console.WriteLine();

            while (basiliskHP > 0)
            {
                int damage = 0;
                foreach (var name in party)
                {
                    Console.Write($"{name} hits the basilisk for: ");
                    for (int attacks = 0; attacks < 1; attacks++)
                    {
                        damage += random.Next(1, 5);
                    }
                    basiliskHP -= damage;
                    Console.WriteLine($"{damage} damage");
                    if (basiliskHP < 0)
                    {
                        basiliskHP = 0;
                        Console.WriteLine($"The basilisk has {basiliskHP} Health left");
                        Console.WriteLine($"The party has succesfully slain the basilisk! Congratulations, you earn {random.Next(1, 1001)} gold pieces!");
                        break;
                    }
                    Console.WriteLine($"The basilisk has {basiliskHP} Health left");
                    damage = 0;
                }
                if (basiliskHP <= 0) { break; }

                var petrifying = party[random.Next(0, party.Count)];
                Console.WriteLine($"The basilisk uses petrifying gaze on {petrifying}");

                int savingThrow = random.Next(1, 21);
                savingThrow += 5;


                if (savingThrow < 12)
                {
                    Console.WriteLine($"{petrifying} rolled a {savingThrow} and didn't succeed. What a shame.");
                    party.Remove(petrifying);
                }
                else
                {
                    Console.WriteLine($"{petrifying} rolled a {savingThrow} and made the save! Hurray!");
                }

                if (party.Count == 0)
                {
                    Console.WriteLine("The party has perished. You lose!");
                    break;
                }
                Console.WriteLine();
            }
            Console.ReadKey(true);
        }
    }
}
