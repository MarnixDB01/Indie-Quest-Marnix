using System;
using System.Collections.Generic;
using System.IO;

namespace Search_by_armor_type
{
    class ArmorTypeEntry
    {
        public string Name;
        public ArmorCategory Category;
        public int Weight;
    }

    enum ArmorCategory
    {
        Light,
        Medium,
        Heavy,
        Unassigned
    }

    class ArmorInformation
    {
        public int Class;
        public ArmorType Type;
    }

    enum ArmorType
    {
        Unspecified,
        Natural,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ChainMail,
        ScaleMail,
        Plate,
        Other
    }
    class MonsterEntry
    {
        //public strings to save data.
        public string Name;
        public string Description;
        public string Alignment;
        public int HitPoints;
        public string HitPointsRoll;

        //add an instance of ArmorInformation class into MonsterEntry class.
        public ArmorInformation Armor;

        //add an instance of ArmorTypeEntry class into MonsterEntry class.
        public ArmorTypeEntry ArmorType;
    }

    class Program
    {
        static Dictionary<string, ArmorType> armorTypesByName = new Dictionary<string, ArmorType>();

        static Dictionary<ArmorType, ArmorTypeEntry> armorTypeEntries = new Dictionary<ArmorType, ArmorTypeEntry>();

        //Reads and stores the text file with armor types information into a list.
        static string[] armorTypeLines = File.ReadAllLines("ArmorTypes.txt");

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

            //Get data out of Hit Points line from monster data (2 down from monster name).
            string[] hitPointsLine = monsterLines[2].Split(" ");

            //Parse monster Hit Points and make it a seperate int.
            int hitPoints = Int32.Parse(hitPointsLine[2]);

            string hitPointsRoll = "";

            //Make player Hit Points Roll a seperate string.
            if (hitPointsLine[3].Length > 0)
            {
                hitPointsRoll = hitPointsLine[3].Substring(1, hitPointsLine[3].Length - 2);
            }

            //Get data out of armor line from monster data (3 down from monster name).
            string[] armorLine = monsterLines[3].Split(" ");

            //Parse monster armor class and make it a seperate int.
            int armorClass = Int32.Parse(armorLine[2]);

            ArmorType armorType = ArmorType.Unspecified;

            ArmorCategory armorCategory = ArmorCategory.Unassigned;

            int armorWeight = 0;

            foreach (KeyValuePair<string, ArmorType> entry in armorTypesByName)
            {
                if (monsterLines[3].Contains(entry.Key))
                {
                    armorType = entry.Value;

                    //Go over each line in the ArmorTypes.txt file.
                    for (int armorTypeLinesIndex = 0; armorTypeLinesIndex < armorTypeLines.Length; armorTypeLinesIndex++)
                    {
                        string[] currentArmorTypesLine = armorTypeLines[armorTypeLinesIndex].Split(",");

                        //Check if the current line contains the current armorType.
                        if (currentArmorTypesLine[1].Contains(entry.Key))
                        {
                            //Check which armor category the current line possesses and change the official ArmorCategory to that value.
                            if (currentArmorTypesLine[2] == "Light")
                            {
                                armorCategory = ArmorCategory.Light;
                            }

                            if (currentArmorTypesLine[2] == "Medium")
                            {
                                armorCategory = ArmorCategory.Medium;
                            }

                            if (currentArmorTypesLine[2] == "Heavy")
                            {
                                armorCategory = ArmorCategory.Heavy;
                            }

                            armorWeight = Int32.Parse(currentArmorTypesLine[3]);
                        }
                    }
                }
            }

            //If we did not find an armortype, check if there was something written for it.
            if (armorType == ArmorType.Unspecified && monsterLines[3].Contains("("))
            {
                armorType = ArmorType.Other;
            }

            //Store current information into a monsterEntries list.
            return new MonsterEntry
            {
                Name = name,
                Description = description,
                Alignment = alignment,
                HitPoints = hitPoints,
                HitPointsRoll = hitPointsRoll,

                Armor = new ArmorInformation
                {
                    Class = armorClass,
                    Type = armorType,
                },

                ArmorType = new ArmorTypeEntry
                {
                    Category = armorCategory,
                    Weight = armorWeight
                }
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

            //Write current  player entry hit points  to console.
            Console.WriteLine($"Hit points: {monsterEntry.HitPoints} {monsterEntry.HitPointsRoll}");

            //Write current player entry armor class to console.
            Console.WriteLine($"Armor Class: {monsterEntry.Armor.Class}");

            if (monsterEntry.Armor.Type != ArmorType.Unspecified)
            {
                //Write current player entry armor type to console.
                Console.WriteLine($"Armor Type: {monsterEntry.Armor.Type}");

                if (monsterEntry.ArmorType.Category != ArmorCategory.Unassigned)
                {
                    //Write current player entry armor category to console.
                    Console.WriteLine($"Armor category: {monsterEntry.ArmorType.Category}");

                    //Write current player entry armor weight to console.
                    Console.WriteLine($"Armor weight: {monsterEntry.ArmorType.Weight} lb");
                }
            }
        }

        static void Main(string[] args)
        {
            //Initialize all armorTypeEntries

            //Initialize all armor types.
            armorTypesByName["Natural"] = ArmorType.Natural;
            armorTypesByName["Leather"] = ArmorType.Leather;
            armorTypesByName["Studded Leather"] = ArmorType.StuddedLeather;
            armorTypesByName["Hide"] = ArmorType.Hide;
            armorTypesByName["Chain Shirt"] = ArmorType.ChainShirt;
            armorTypesByName["Chain Mail"] = ArmorType.ChainMail;
            armorTypesByName["Scale Mail"] = ArmorType.ScaleMail;
            armorTypesByName["Plate"] = ArmorType.Plate;

            //Reads the MonsterManual.txt and stores it inside the list.
            string[] monsterManualLines = File.ReadAllLines("MonsterManual.txt");

            List<MonsterEntry> monsterEntries = CreateMonsterEntries(monsterManualLines);

            var matchingMonsterEntries = new List<MonsterEntry>();

            //UI
            //Title.
            Console.WriteLine("MONSTER MANUAL:");
            Console.WriteLine();

            Console.WriteLine("Do you want to search by (n)ame or (a)rmor type?");
            string playerTypeEntry = Console.ReadLine();

            string playerEntry;

            if (playerTypeEntry == "a")
            {
                string[] armorTypeNames = Enum.GetNames<ArmorType>();
                ArmorType[] armorTypes = Enum.GetValues<ArmorType>();

                Console.Clear();
                Console.WriteLine("Which armor type do you want to display?");
                Console.WriteLine();

                for (int armorTypeNamesIndex = 0; armorTypeNamesIndex < armorTypeNames.Length; armorTypeNamesIndex++)
                {
                    Console.WriteLine($"{armorTypeNamesIndex + 1}: {armorTypeNames[armorTypeNamesIndex]}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter number:");
                playerEntry = Console.ReadLine().ToLowerInvariant();
                int playerEntryIndexVersion = Int32.Parse(playerEntry);

                foreach (MonsterEntry monsterEntry in monsterEntries)
                {
                    if (monsterEntry.Armor.Type == armorTypes[playerEntryIndexVersion - 1])
                    {
                        matchingMonsterEntries.Add(monsterEntry);
                    }
                }

                //If there is no matching monsters with the player entries chosen armor type. Output a try again.
                if (matchingMonsterEntries.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("No monsters were found with that armor type. Try again:");
                }

                //If there is only one matching monster with the chosen armor type then just output the monster data.
                else if (matchingMonsterEntries.Count == 1)
                {
                    DisplayMonsterEntry(matchingMonsterEntries[0]);
                    return;
                }
                //If there are multiple matching monsters with the chosen armor type.
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


            }
            if (playerTypeEntry == "n")
            {
                //Write out to console asking for player input.
                Console.Clear();
                Console.WriteLine("Enter a query to search monsters by name:");

                do
                {
                    //Player input.
                    playerEntry = Console.ReadLine().ToLowerInvariant();

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
                    //If there are multiple matching monster names.
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
}