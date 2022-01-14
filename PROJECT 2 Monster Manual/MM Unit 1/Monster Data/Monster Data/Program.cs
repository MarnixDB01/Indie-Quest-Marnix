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
        public string HitPoints;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //list that reads the MonsterManual.txt and stores it inside the list.
            var monsterEntries = new List<string>(File.ReadAllLines("MonsterManual.txt"));


            var playerEntry = Console.ReadLine();
            var playerEntryDescriptionLine = monsterEntries[monsterEntries.IndexOf(playerEntry) + 1];
            string[] playerEntryDescription = playerEntryDescriptionLine.Split(',');

            Console.Clear();

            if (monsterEntries.Contains(playerEntry))
            {

            }
            else
            {

            }
        }
    }
}
