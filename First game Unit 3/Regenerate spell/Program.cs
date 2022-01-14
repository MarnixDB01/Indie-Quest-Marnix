using System;

namespace Regenerate_spell
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();
            int warriorHP = random.Next(0, 101);

            Console.WriteLine($"Warrior HP: {warriorHP}");
            Console.WriteLine("The Regenerate spell has been cast!");

            while (warriorHP < 50)
            {
                warriorHP += 10;
                Console.WriteLine($"Warrior HP: {warriorHP}");
            }

            Console.WriteLine("The Regenerate spell has been completed!");
        }

    }
}










