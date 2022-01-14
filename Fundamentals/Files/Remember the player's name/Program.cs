using System;
using System.IO;


namespace Remember_the_player_s_name
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerNamePath = "player-name.txt";

            if (File.Exists(playerNamePath))
            {
                Console.WriteLine($"Welcome back, {File.ReadAllText(playerNamePath)}, let's continue!");
            }
            else
            {
                Console.WriteLine("Welcome to your biggest adventure yet!\n\nWhat is your name, traveler?");
                Console.Write("> ");
                File.WriteAllText(playerNamePath, Console.ReadLine());

                if (File.Exists(playerNamePath))
                    {
                    Console.WriteLine();
                    Console.WriteLine($"Nice to meet you, {File.ReadAllText(playerNamePath)}");
                }
            }
            Console.ReadKey();
        }

    }
}
