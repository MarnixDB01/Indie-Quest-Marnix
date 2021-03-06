using System;
using System.Collections.Generic;

namespace Battle_Simulator
{
    class Program
    {
        static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC)
        {
            var random = new Random();
            Console.WriteLine($"Beware, " + monster + " with " + monsterHP + " health appears!");

            while (monsterHP > 0)
            {
                int damage = 0;
                foreach (var name in heroes)
                {
                    Console.Write($"{name} hits the {monster} for: ");
                    for (int attacks = 0; attacks < 2; attacks++)
                    {
                        damage += random.Next(1, 7);
                    }
                    monsterHP -= damage;
                    Console.WriteLine($"{damage} damage");
                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                        Console.WriteLine($"The {monster} has {monsterHP} Health left");
                        Console.WriteLine($"The party has succesfully slain the {monster}!");
                        break;
                    }
                    Console.WriteLine($"The {monster} has {monsterHP} Health left");
                    damage = 0;
                }
                if (monsterHP <= 0)
                {
                    break;
                }

                var monsterAttack = heroes[random.Next(0, heroes.Count)];
                Console.WriteLine($"The {monster} attacks {monsterAttack}");

                int savingThrow = random.Next(1, 21);
                savingThrow += 5;

                if (savingThrow < savingThrowDC)
                {
                    Console.WriteLine($"{monsterAttack} rolled a {savingThrow} and failed, the hero dies!.");
                    heroes.Remove(monsterAttack);
                }
                else
                {
                    Console.WriteLine($"{monsterAttack} rolled a {savingThrow} and made the save! Hurray!");
                }
                if (heroes.Count == 0)
                {
                    Console.WriteLine("The party has perished. You lose!");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            var random = new Random();
            var party = new List<string> { "Razor", "Brayton", "Darwyn", "Winfrey" };
            Console.Write("A party of warriors (");
            Console.Write(String.Join(", ", party));
            Console.WriteLine(") descends into\nthe dark and mysterious dungeon");
            Console.WriteLine();

            SimulateBattle(party, "Orc", 15, 12);
            Console.WriteLine();

            SimulateBattle(party, "Mage", 40, 20);
            Console.WriteLine();

            SimulateBattle(party, "Troll", 84, 18);

            Console.ReadKey(true);
        }
    }
}
