using System;
using System.Collections.Generic;
using System.IO;

namespace Monster_Data
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
        static void Main(string[] args)
        {
            //Reads the MonsterManual.txt and stores it inside the list.
            var monsterManualInfo = new List<string>(File.ReadAllLines("MonsterManual.txt"));

            //Write out to console asking for player input.
            Console.WriteLine("Please enter your desired monster name:");

            //Player input.
            var playerEntry = Console.ReadLine();

            //Clear console so it doesn't stay when writing info to console.
            Console.Clear();

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

            var monsterEntries = new List<MonsterEntry>();

            //If playerEntry exists within the manual information
            if (monsterManualInfo.Contains(playerEntry))
            {
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

                Console.ReadKey(true);
            }
        }
    }
}