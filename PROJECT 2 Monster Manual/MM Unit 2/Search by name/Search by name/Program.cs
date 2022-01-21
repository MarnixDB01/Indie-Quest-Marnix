using System;
using System.Collections.Generic;
using System.IO;

namespace Search_by_name
{
    class MonsterEntry
    {
        //public strings to save data.
        public string Name;
        public string Description;
        public string Alignment;
        public int HitPoints;
        public string HitPointsRoll;
    }

    class Program
    {
        static void MonsterEntryInformation(string playerEntry, List<string> monsterManualInfo, List<MonsterEntry> monsterEntries)
        {
            //Find index of descripion and alignment line from player entry (1 down from playerEntry).
            //Split the line so we can seperate the description and alignment
            string[] playerEntryDescriptionLine = monsterManualInfo[monsterManualInfo.IndexOf(playerEntry) + 1].Split(',');

            //Specific strings for the description and alignment based on the index of the split string.
            string playerEntryDescription = playerEntryDescriptionLine[0];
            string playerEntryAlignment = playerEntryDescriptionLine[1];

            //Find index of hit points line from player entry (2 down from playerEntry).
            string[] playerEntryHitPointsLine = monsterManualInfo[monsterManualInfo.IndexOf(playerEntry) + 2].Split(' ');

            //Parse player Hit Points and make it a seperate int.
            int playerHitPoints = Int32.Parse(playerEntryHitPointsLine[2]);

            //Make player Hit Points Roll a seperate string.
            string playerHitPointsRoll = playerEntryHitPointsLine[3];

            //Store current information into a monsterEntries list.
            monsterEntries.Add(new MonsterEntry
            {
                Name = playerEntry,
                Description = playerEntryDescription,
                Alignment = playerEntryAlignment,
                HitPoints = playerHitPoints,
                HitPointsRoll = playerHitPointsRoll
            });

            //Write current player entry name to console.
            Console.WriteLine($"Name: {monsterEntries[0].Name}");

            //Write current player entry description to console.
            Console.WriteLine($"Description: {monsterEntries[0].Description}");

            //Write current player entry alignment to console.
            Console.WriteLine($"Alignment:{monsterEntries[0].Alignment}");

            //Write current hit points  player entry to console.
            Console.WriteLine($"Hit points: {monsterEntries[0].HitPoints} {monsterEntries[0].HitPointsRoll}");
        }

        static void Main(string[] args)
        {
            //Reads the MonsterManual.txt and stores it inside the list.
            var monsterManualInfo = new List<string>(File.ReadAllLines("MonsterManual.txt"));

            //Tool title.
            Console.WriteLine("MONSTER MANUAL:");
            Console.WriteLine();

            //Write out to console asking for player input.
            Console.WriteLine("Enter a query to search monsters by name:");

            //Player input.
            var playerEntry = Console.ReadLine();

            //Clear console so it doesn't stay when writing info to console.
            Console.Clear();

            var monsterEntries = new List<MonsterEntry>();

            //If playerEntry exists within the manual information
            if (monsterManualInfo.Contains(playerEntry))
            {
                Console.WriteLine("Which monster did you want to look up?");

                foreach ()

                MonsterEntryInformation(playerEntry, monsterManualInfo, monsterEntries);
            }
            else
            {
                Console.WriteLine("No monsters were found. Try again:");
                playerEntry = Console.ReadLine();

                //Clear console so it doesn't stay when writing info to console.
                Console.Clear();
            }
        }
    }
}