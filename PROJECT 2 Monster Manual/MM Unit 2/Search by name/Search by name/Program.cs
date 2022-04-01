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
        static MonsterEntry CreateMonsterEntry(string[] monsterLines)
        {
            //Get monster name from first line.
            string name = monsterLines[0];

            //Find index of descripion and alignment line for this monster(1 down from monster name).
            //Split the line so we can seperate the description and alignment
            string[] descriptionLine = monsterLines[1].Split(", ");

            //Specific strings for the description and alignment based on the index of the split string.
            string description = descriptionLine[0];
            string alignment = descriptionLine[1];

            //Get data out of Hit Points line from monster data(2 down from monster name).
            string[] hitPointsLine = monsterLines[2].Split(" ");

            //Parse player Hit Points and make it a seperate int.
            int hitPoints = Int32.Parse(hitPointsLine[2]);

            string hitPointsRoll = "";

            //Make player Hit Points Roll a seperate string.
            if (hitPointsLine[3].Length > 0)
            {
                hitPointsRoll = hitPointsLine[3].Substring(1, hitPointsLine[3].Length - 2);
            }

            //Store current information into a monsterEntries list.
            return new MonsterEntry
            {
                Name = name,
                Description = description,
                Alignment = alignment,
                HitPoints = hitPoints,
                HitPointsRoll = hitPointsRoll
            };

        }

        static List<MonsterEntry> CreateMonsterEntries(string[] monsterManualLines)
        {
            var monsterEntries = new List<MonsterEntry>();

            for (int startIndex = 0; startIndex < monsterManualLines.Length; startIndex += 7)
            {
                int endIndex = startIndex + 5;
                monsterEntries.Add(CreateMonsterEntry(monsterManualLines[startIndex..endIndex]));
            }

            return monsterEntries;
        }

        static void DisplayMonsterEntry(MonsterEntry monsterEntry)
        {
            //Clear console so UI doesn't stay when writing data to console.
            Console.Clear();

            //Write current player entry name to console.
            Console.WriteLine($"Name: {monsterEntry.Name}");

            //Write current player entry description to console.
            Console.WriteLine($"Description: {monsterEntry.Description}");

            //Write current player entry alignment to console.
            Console.WriteLine($"Alignment: {monsterEntry.Alignment}");

            //Write current hit points  player entry to console.
            Console.WriteLine($"Hit points: {monsterEntry.HitPoints} {monsterEntry.HitPointsRoll}");
        }

        static void Main(string[] args)
        {
            //Reads the MonsterManual.txt and stores it inside the list.
            string[] monsterManualLines = File.ReadAllLines("MonsterManual.txt");

            List<MonsterEntry> monsterEntries = CreateMonsterEntries(monsterManualLines);

            //UI
            //Title.
            Console.WriteLine("MONSTER MANUAL:");
            Console.WriteLine();

            //Write out to console asking for player input.
            Console.WriteLine("Enter a query to search monsters by name:");

            do
            {
                //Player input.
                string playerEntry = Console.ReadLine().ToLowerInvariant();

                var matchingMonsterEntries = new List<MonsterEntry>();

                //Find which monster entries match the player input.
                foreach (MonsterEntry monsterEntry in monsterEntries)
                {
                    //Temporary monsterEntry name in lowercase.
                    string lowerCaseName = monsterEntry.Name.ToLowerInvariant();

                    //If playerEntry exists within the manual information.
                    if (lowerCaseName.Contains(playerEntry))
                    {
                        matchingMonsterEntries.Add(monsterEntry);
                    }
                }

                //If there is no matching monsters with the player entry, output a try again.
                if (matchingMonsterEntries.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("No monsters were found. Try again:");
                }
                //If there is only one matching monster name then just output the monster data.
                else if (matchingMonsterEntries.Count == 1)
                {
                    DisplayMonsterEntry(matchingMonsterEntries[0]);
                    return;
                }
                //If there are multiple matching monster names
                else
                {
                    Console.Clear();
                    Console.WriteLine("Which monster did you want to look up?");

                    //For the amount of matching monster names, display monster name from matchingMonsterEntries list.
                    //Max the amount of {i} loops with the count of the matching number of monster names.  
                    for (int i = 0; i < matchingMonsterEntries.Count; i++)
                    {
                        //Write out the {i}.
                        //Write out the monster names from the matchingMonsterEntriesList with the correct index. (in this case the index will be -1 of {i}.
                        Console.WriteLine($"{i + 1}: {matchingMonsterEntries[i].Name}");
                    }

                    do
                    {
                        //Ask for player input.
                        Console.WriteLine();
                        Console.WriteLine("Enter number:");

                        //Player input.
                        playerEntry = Console.ReadLine();

                        //Create a variable for the playerEntryNumber
                        int playerEntryNumber;

                        //Bool for if the playerEntry is considered an Int. 
                        //If playerEntry is an int, output the int into the playerEntryNumber variable.
                        bool parsingSucceeded = Int32.TryParse(playerEntry, out playerEntryNumber);

                        //If playerEntry is an int
                        if (parsingSucceeded)
                        {
                            //If the playerEntry int is larger than the amount of matching monster names
                            //Or if playerEntry int is smaller than 1 (because the chooseable numbers start from 1)
                            //Result in Error
                            if (playerEntryNumber > matchingMonsterEntries.Count || playerEntryNumber < 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Error: Number does not exist!");
                            }
                            //Otherwise display the monster data which is associated with the chosen playerEntry number.
                            else
                            {
                                int playerEntryIndex = playerEntryNumber - 1;

                                DisplayMonsterEntry(matchingMonsterEntries[playerEntryIndex]);
                                return;
                            }
                        }
                        //If the parsing fails (playerEntry is not an int) then display Error.
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error: No number found!");
                        }
                    } while (true);
                }
            } while (true);
        }
    }
}