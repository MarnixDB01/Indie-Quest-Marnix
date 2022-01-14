using System;
using System.IO;

namespace Detect_Kickstarter_backers
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerNamePath = "player-name.txt";
            string[] backers = File.ReadAllLines("backer.txt");
            string playerName;

            if (File.Exists(playerNamePath))
            {
                playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Welcome back, {playerName}, let's continue!");
            }
            else
            {
                Console.WriteLine("Welcome to your biggest adventure yet!\n\nWhat is your name, traveler?");
                Console.Write("> ");
                playerName = Console.ReadLine();
                File.WriteAllText(playerNamePath, playerName);

                Console.WriteLine();
                Console.WriteLine($"Nice to meet you, {playerName}");
            }
            Console.WriteLine();

            for (int backerIndex = 0; backerIndex < backers.Length; backerIndex++)
            {
                string name = backers[backerIndex];
                if (name == playerName)
                {
                    Console.WriteLine("You successfully enter Dr. Fred's secret laboratory and are greeted with a warm welcome for backing the game's Kickstarter!");
                    break;
                }
                else if (backerIndex == backers.Length - 1)
                {
                    Console.WriteLine("Unfortunately I cannot let you into Dr. Fred's secret laboratory.");
                }
            }
            Console.ReadKey(true);
        }
    }
}











