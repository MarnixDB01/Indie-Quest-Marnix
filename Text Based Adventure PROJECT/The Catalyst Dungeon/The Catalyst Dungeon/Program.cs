using System;
using System.IO;
using System.Collections.Generic;
using System.Media;

namespace The_Catalyst_Dungeon
{
    class Program
    {
        //Store the values outside of the main method so it is easy to access for other methods.

        //Width and height of the level.
        static int width;
        static int height;

        //Player data.
        static char player;

        static string playerHPLine = "Health:";

        static int playerHP = 40;
        static int playerDMG = 5;

        //Player position.
        static int playerX;
        static int playerY;

        //Monster data.
        //Slime.
        static char slime;

        static string slimeHPLine = "Slime HP=";

        static int slimeHP = 10;
        static int slimeDMG;

        //Slime Position.
        static int slimeX;
        static int slimeY;

        //Lich.
        static char lich;

        static string lichHPLine = "Lich HP =";

        static int lichHP = 14;
        static int lichDMG;

        //Lich position.
        static int lichX;
        static int lichY;

        //Ogre.
        static char ogre;

        static string ogreHPLine = "Ogre HP =";

        static int ogreHP = 18;
        static int ogreDMG;

        //Ogre position.
        static int ogreX;
        static int ogreY;

        //Chimera boss.
        static char chimeraBoss;

        static int chimeraBossHP = 30;
        static int chimeraBossDMG;

        //Chimera boss position.
        static int chimeraBossX = 29;
        static int chimeraBossY = 8;

        //2d array of level layout.
        static char[,] level;
        static ConsoleColor[,] levelColor;

        static List<string> dungeonLevelLayout;


        static void GameIntro()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Display story.
            Console.WriteLine("THE CATALYST DUNGEON!");
            Console.WriteLine();

            Console.WriteLine("After a short sleep, you wake up and decide to walk outside.\nWhen you suddenly see a letter laying under your door.");
            Console.WriteLine("When you pick up the letter, you notice that it has the post stamp of the Royal Palace, you immediately start reading it.");
            Console.WriteLine();

            Console.WriteLine("'Dear hero...\nWe urge you to help our kingdom which is in great danger to a threat only you can eradicate!");
            Console.WriteLine("Our scouts have investigated a certain abandoned mineshaft which was closed because of certain anomalies.");
            Console.WriteLine("The miners had discovered a purple glowing crystal.");
            Console.WriteLine();

            Console.WriteLine("After abandoning and closing off the mineshaft for safety, it seems that monstrous creatures have shown up and have made the mineshaft their habitat.");
            Console.WriteLine("We are uncertain of the creatures intentions and why they are drawn to the crystal, which we have officialy named 'The Catalyst'.");
            Console.WriteLine("But what we do know for certain is that these creatures are growing stronger by the day,\nresulting in surrounding villages being destroyed and many warriors to have fallen.");
            Console.WriteLine();

            Console.WriteLine("Help us, Hero! The kingdom of Astria needs you!'");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("(N)EXT →");

            //Continue to next phase of story after pressing N for continue.
            while (true)
            {
                var playerInput = Console.ReadKey();

                if (playerInput.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    break;
                }
            }

            //Display next part of story.
            Console.WriteLine("You travel to the dungeon and arrive at the mineshaft entrance.\nYou notice a strange old man wearing a worn out robe sitting behind a small wooden cart.");
            Console.WriteLine();

            Console.WriteLine("As you approach the old man, he silently says in a raspy voice 'Boy~ you shall choose a piece of equipment passed down from the legendary hero of the dark ages'.");
            Console.WriteLine();

            Console.WriteLine("You see two pieces of equipment ontop of the cart.");
            Console.WriteLine("An armorstand with a plate breastplate and a platinum longsword.");
            Console.WriteLine();

            Console.WriteLine("'Which piece would you like to use, boy~?' he firmly asked.");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("(1) Plate Breastplate [+10 HP]");
            Console.WriteLine("(2) Platinum Longsword [+3 DMG]");

            //Depending on player choice between items, change the player stats accordingly.
            while (true)
            {
                var playerInput = Console.ReadKey();

                switch (playerInput.Key)
                {
                    case ConsoleKey.D1:
                        {
                            playerHP = playerHP + 10;
                        }
                        break;

                    case ConsoleKey.NumPad1:
                        {
                            playerHP = playerHP + 10;
                        }
                        break;

                    case ConsoleKey.D2:
                        {
                            playerDMG = playerDMG + 3;
                        }
                        break;

                    case ConsoleKey.NumPad2:
                        {
                            playerDMG = playerDMG + 3;
                        }
                        break;

                    default:
                        {
                            continue;
                        }

                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                break;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("I see~, that is definitely a wise choice.");
            Console.WriteLine("Now go forth boy~, this kingdom needs you!");
            Console.WriteLine();

            Console.WriteLine("After entering the old mineshaft through a heavy wooden door, it suddenly shuts tight after you! Leaving you in the darkness!");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("(N)EXT →");

            while (true)
            {
                var playerInput = Console.ReadKey();

                if (playerInput.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        static void DrawLevel()
        {
            //Level size
            width = 34;
            height = 17;

            //Creating 2d array from size of level layout.
            level = new char[width, height];
            levelColor = new ConsoleColor[width, height];

            for (int levelHeight = 0; levelHeight < height; levelHeight++)
            {
                for (int levelWidth = 0; levelWidth < width; levelWidth++)
                {
                    level[levelWidth, levelHeight] = dungeonLevelLayout[levelHeight][levelWidth];
                    levelColor[levelWidth, levelHeight] = ConsoleColor.Gray;

                    //Set player startpoint
                    if (level[levelWidth, levelHeight] == 'S')
                    {
                        playerX = levelWidth;
                        playerY = levelHeight;

                        player = 'P';
                        level[levelWidth, levelHeight] = player;
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Magenta;

                        //Replace the S, otherwise it will remain on the level after movement.
                        dungeonLevelLayout[levelHeight] = dungeonLevelLayout[levelHeight].Replace('S', ' ');
                    }

                    //Set monster locations
                    //Draw slime
                    if (level[levelWidth, levelHeight] == '1')
                    {
                        slimeX = levelWidth;
                        slimeY = levelHeight;

                        slime = 'S';
                        level[levelWidth, levelHeight] = slime;
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Green;

                        //replace the a, otherwise it will remain on the level after movement.
                        dungeonLevelLayout[levelHeight] = dungeonLevelLayout[levelHeight].Replace('1', ' ');
                    }

                    //Draw lich
                    if (level[levelWidth, levelHeight] == '2')
                    {
                        lichX = levelWidth;
                        lichY = levelHeight;

                        lich = 'L';
                        level[levelWidth, levelHeight] = lich;
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Blue;

                        //Replace the b, otherwise it will remain on the level after movement.
                        dungeonLevelLayout[levelHeight] = dungeonLevelLayout[levelHeight].Replace('2', ' ');
                    }

                    //Draw ogre
                    if (level[levelWidth, levelHeight] == '3')
                    {
                        ogreX = levelWidth;
                        ogreY = levelHeight;

                        ogre = 'O';
                        level[levelWidth, levelHeight] = ogre;
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;

                        //Replace the c, otherwise it will remain on the level after movement.
                        dungeonLevelLayout[levelHeight] = dungeonLevelLayout[levelHeight].Replace('3', ' ');
                    }

                    //Draw level aesthetics.
                    //Draw rock#1.
                    if (level[levelWidth, levelHeight] == level[15, 2])
                    {
                        level[levelWidth, levelHeight] = '{';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    if (level[levelWidth, levelHeight] == level[16, 2])
                    {
                        level[levelWidth, levelHeight] = '@';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    if (level[levelWidth, levelHeight] == level[17, 2])
                    {
                        level[levelWidth, levelHeight] = '}';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    //Draw rock#2.
                    if (level[levelWidth, levelHeight] == level[10, 12])
                    {
                        level[levelWidth, levelHeight] = '[';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    if (level[levelWidth, levelHeight] == level[11, 12])
                    {
                        level[levelWidth, levelHeight] = '@';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[12, 12])
                    {
                        level[levelWidth, levelHeight] = ')';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    //Draw rock#3.
                    if (level[levelWidth, levelHeight] == level[30, 15])
                    {
                        level[levelWidth, levelHeight] = '{';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    if (level[levelWidth, levelHeight] == level[31, 15])
                    {
                        level[levelWidth, levelHeight] = '&';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGray;
                    }

                    if (level[levelWidth, levelHeight] == level[32, 15])
                    {
                        level[levelWidth, levelHeight] = ')';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Green;
                    }

                    //Draw pool of water.
                    if (level[levelWidth, levelHeight] == level[21, 14])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[22, 14])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[23, 14])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[24, 14])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[22, 13])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[23, 13])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[22, 15])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    if (level[levelWidth, levelHeight] == level[23, 15])
                    {
                        level[levelWidth, levelHeight] = '~';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.Cyan;
                    }

                    //Draw bush#1.
                    if (level[levelWidth, levelHeight] == level[1, 6])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[2, 6])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[3, 6])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    //Draw bush#2.
                    if (level[levelWidth, levelHeight] == level[30, 1])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[31, 1])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[32, 1])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }

                    if (level[levelWidth, levelHeight] == level[32, 2])
                    {
                        level[levelWidth, levelHeight] = '#';
                        levelColor[levelWidth, levelHeight] = ConsoleColor.DarkGreen;
                    }
                }
            }
        }

        static void DisplayLevel()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = levelColor[x, y];
                    Console.Write(level[x, y]);
                }
                Console.WriteLine();
            }

            while (true)
            {
                PlayerUI();

                EnemyNPCUI();

                if (chimeraBossHP == 0)
                {
                    break;
                }

                PlayerMovement();

                CombatSequence();

                if (lichHP == 0 && slimeHP == 0 && ogreHP == 0)
                {
                    BossSequence();
                }

                SlimeMovement();

                LichMovement();

                OgreMovement();
            }
        }

        static void GameOverDisplay()
        {
            Console.Clear();

            string gameOverText = @"
 ________   ________   _____ ______    _______           ________   ___      ___  _______    ________     
|\   ____\ |\   __  \ |\   _ \  _   \ |\  ___ \         |\   __  \ |\  \    /  /||\  ___ \  |\   __  \    
\ \  \___| \ \  \|\  \\ \  \\\__\ \  \\ \   __/|        \ \  \|\  \\ \  \  /  / /\ \   __/| \ \  \|\  \   
 \ \  \  ___\ \   __  \\ \  \\|__| \  \\ \  \_|/__       \ \  \\\  \\ \  \/  / /  \ \  \_|/__\ \   _  _\  
  \ \  \|\  \\ \  \ \  \\ \  \    \ \  \\ \  \_|\ \       \ \  \\\  \\ \    / /    \ \  \_|\ \\ \  \\  \| 
   \ \_______\\ \__\ \__\\ \__\    \ \__\\ \_______\       \ \_______\\ \__/ /      \ \_______\\ \__\\ _\ 
    \|_______| \|__|\|__| \|__|     \|__| \|_______|        \|_______| \|__|/        \|_______| \|__|\|__|
";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(gameOverText);

            Console.ReadKey();
            Environment.Exit(0);

        }

        static void GameCompletionDisplay()
        {
            if (chimeraBossHP == 0)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;

                //Ending story.
                Console.WriteLine("After a long drawn out battle with powerful dungeon monsters, you venture into the back of the mineshaft, where you see the glowing purple crystal floating above the ground.");
                Console.WriteLine("At first you don't believe your eyes, but then realise you also just witnessed dangerous otherwordly monsters, and quickly decide you should get out of the dungeon as soon as possible.");
                Console.WriteLine("You find an alternative entrance to the mineshaft, upon opening the big wooden door, you lose sight for a few seconds after seeing the bright sunrise.");
                Console.WriteLine();

                Console.WriteLine("You notice that the old traveling merchant seems to have already left, and you start venturing towards the Capital city of Astria, Zerivar");
                Console.WriteLine("After a long and tiresome two day travel, you enter the city of Zerivar, and head straight towards the King's castle.");
                Console.WriteLine("Upon entering the castle, you are instantly shown your way to the King's Hall by two guards.");
                Console.WriteLine();

                Console.WriteLine("After entering the King's Hall, you instantly get greeted by the grateful king of Astria, Astur Maxim the seventh!");

                Console.WriteLine("CONGRATULATIONS HERO!");
                Console.WriteLine("YOU have successfully eradicated the dungeon from all it's monsters!");
                Console.WriteLine("Our scouts saw you leave the dungeon and had our researchers sent immediately to the site!");
                Console.WriteLine("This has given our researchers the freedom to fully investigate the Catalyst, where we have discovered that it is a magical weapon of destruction from the dark ages, 500 years ago!");
                Console.WriteLine("According to our history books, it was created by a powerful dark mage, to summon the powers of the devil and eventually the Demon King himself!");
                Console.WriteLine();

                Console.WriteLine("We have now safely stored it in a magic consealment chamber within our kingdom walls, while trying to find a way to destroy it for good!");
                Console.WriteLine("I would like to thank you, Hero! For saving the kingdom and all of it's people. We are forever indebted to you, and you may receive whichever reward you ask for!");
                Console.WriteLine();
                Console.WriteLine("THE END");
            }
        }

        static void PlayerMovement()
        {
            var playerInput = Console.ReadKey();

            Console.ForegroundColor = levelColor[playerX, playerY];

            void RemovePlayerFromCurrentPosition()
            {
                //draw out the char from the original list.
                level[playerX, playerY] = dungeonLevelLayout[playerY][playerX];

                //Sets cursor to X, Y location.
                Console.SetCursorPosition(playerX, playerY);

                //Writes out new data to the console.
                Console.Write(level[playerX, playerY]);
            }

            switch (playerInput.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (level[playerX, playerY - 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerY--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (level[playerX, playerY + 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerY++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (level[playerX - 1, playerY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerX--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (level[playerX + 1, playerY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerX++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }
            //Set cursor to new X, Y player position which was changed in the switch above depending on which directional arrow key was pressed.
            Console.SetCursorPosition(playerX, playerY);

            //draw new player icon at new cursor position
            level[playerX, playerY] = player;
            levelColor[playerX, playerY] = ConsoleColor.Magenta;

            //Write out new player position to console.
            Console.Write(level[playerX, playerY]);
        }

        static void SlimeMovement()
        {
            if (slimeHP > 0)
            {

                var random = new Random();
                int randomDirection = random.Next(5);

                Console.ForegroundColor = levelColor[slimeX, slimeY];

                void RemovePlayerFromCurrentPosition()
                {
                    //Writes out the char from the original list.
                    level[slimeX, slimeY] = dungeonLevelLayout[slimeY][slimeX];

                    //Sets cursor to X, Y location.
                    Console.SetCursorPosition(slimeX, slimeY);

                    //Writes out new data to the console.
                    Console.Write(level[slimeX, slimeY]);
                }

                switch (randomDirection)
                {
                    case 0:
                        if (level[slimeX, slimeY - 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            slimeY--;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 1:
                        if (level[slimeX, slimeY + 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            slimeY++;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 2:
                        if (level[slimeX - 1, slimeY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            slimeX--;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 3:
                        if (level[slimeX + 1, slimeY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            slimeX++;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 4:
                        {
                            break;
                        }
                }
            }
            //Set cursor to new X, Y player position which was changed in the switch above depending on which directional arrow key was pressed.
            Console.SetCursorPosition(slimeX, slimeY);

            //draw new player icon at new cursor position
            level[slimeX, slimeY] = slime;
            levelColor[slimeX, slimeY] = ConsoleColor.Green;

            //Write out new player position to console.
            Console.Write(level[slimeX, slimeY]);
        }

        static void LichMovement()
        {

            if (lichHP > 0)
            {
                var random = new Random();
                int randomDirection = random.Next(5);

                Console.ForegroundColor = levelColor[lichX, lichY];

                void RemovePlayerFromCurrentPosition()
                {
                    //Writes out the char from the original list.
                    level[lichX, lichY] = dungeonLevelLayout[lichY][lichX];

                    //Sets cursor to X, Y location.
                    Console.SetCursorPosition(lichX, lichY);

                    //Writes out new data to the console.
                    Console.Write(level[lichX, lichY]);
                }

                switch (randomDirection)
                {
                    case 0:
                        if (level[lichX, lichY - 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            lichY--;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 1:
                        if (level[lichX, lichY + 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            lichY++;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 2:
                        if (level[lichX - 1, lichY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            lichX--;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 3:
                        if (level[lichX + 1, lichY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            lichX++;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 4:
                        {
                            break;
                        }
                }
            }
            //Set cursor to new X, Y player position which was changed in the switch above depending on which directional arrow key was pressed.
            Console.SetCursorPosition(lichX, lichY);

            //draw new player icon at new cursor position
            level[lichX, lichY] = lich;
            levelColor[lichX, lichY] = ConsoleColor.Blue;

            //Write out new player position to console.
            Console.Write(level[lichX, lichY]);
        }

        static void OgreMovement()
        {
            if (ogreHP > 0)
            {
                var random = new Random();
                int randomDirection = random.Next(5);

                Console.ForegroundColor = levelColor[ogreX, ogreY];

                void RemovePlayerFromCurrentPosition()
                {
                    //Writes out the char from the original list.
                    level[ogreX, ogreY] = dungeonLevelLayout[ogreY][ogreX];

                    //Sets cursor to X, Y location.
                    Console.SetCursorPosition(ogreX, ogreY);

                    //Writes out new data to the console.
                    Console.Write(level[ogreX, ogreY]);
                }

                switch (randomDirection)
                {
                    case 0:
                        if (level[ogreX, ogreY - 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            ogreY--;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 1:
                        if (level[ogreX, ogreY + 1] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            ogreY++;
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 2:
                        if (level[ogreX - 1, ogreY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            ogreX--;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 3:
                        if (level[ogreX + 1, ogreY] == ' ')
                        {
                            RemovePlayerFromCurrentPosition();
                            ogreX++;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 4:
                        {
                            break;
                        }
                }
            }
            //Set cursor to new X, Y player position which was changed in the switch above depending on which directional arrow key was pressed.
            Console.SetCursorPosition(ogreX, ogreY);

            //draw new player icon at new cursor position
            level[ogreX, ogreY] = ogre;
            levelColor[ogreX, ogreY] = ConsoleColor.DarkGreen;

            //Write out new player position to console.
            Console.Write(level[ogreX, ogreY]);

        }

        static void PlayerUI()
        {
            //PlayerUI border.
            Console.SetCursorPosition(width + 1, 0);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("╔");
            for (int borderLengthTop = 0; borderLengthTop < 12; borderLengthTop++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            for (int borderLengthHeight = 1; borderLengthHeight < 5; borderLengthHeight++)
            {
                Console.SetCursorPosition(width + 1, borderLengthHeight);
                Console.Write("║");
                Console.SetCursorPosition(width + 14, borderLengthHeight);
                Console.Write("║");
            }

            Console.SetCursorPosition(width + 1, 5);
            Console.Write("╚");
            for (int borderLengthBottom = 0; borderLengthBottom < 12; borderLengthBottom++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

            //Player headline.
            Console.SetCursorPosition(width + 2, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("PLAYER");

            //Player health.
            if (playerHP > 9)
            {
                Console.SetCursorPosition(width + 2, 3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerHPLine} {playerHP}");
            }
            else if (playerHP < 10)
            {
                Console.SetCursorPosition(width + 2, 3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerHPLine} 0{playerHP}");
            }

            //Player damage.
            Console.SetCursorPosition(width + 2, 4);
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine($"Damage: 0{playerDMG}");
        }

        static void EnemyNPCUI()
        {
            //EnemyNPCUI border
            Console.SetCursorPosition(width + 1, 7);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("╔");
            for (int borderLengthTop = 0; borderLengthTop < 12; borderLengthTop++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            for (int borderLengthHeight = 8; borderLengthHeight < 16; borderLengthHeight++)
            {
                Console.SetCursorPosition(width + 1, borderLengthHeight);
                Console.Write("║");
                Console.SetCursorPosition(width + 14, borderLengthHeight);
                Console.Write("║");
            }

            Console.SetCursorPosition(width + 1, 16);
            Console.Write("╚");
            for (int borderLengthBottom = 0; borderLengthBottom < 12; borderLengthBottom++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

            //Slime health
            if (slimeHP > 9)
            {
                Console.SetCursorPosition(width + 2, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{slimeHPLine} {slimeHP}");
            }
            else if (slimeHP < 10)
            {
                Console.SetCursorPosition(width + 2, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{slimeHPLine} 0{slimeHP}");
            }

            //Slime damage
            Console.SetCursorPosition(width + 2, 9);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"DMG = 1d3");

            //Lich health
            if (lichHP > 9)
            {
                Console.SetCursorPosition(width + 2, 11);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{lichHPLine} {lichHP}");
            }
            else if (lichHP < 10)
            {
                Console.SetCursorPosition(width + 2, 11);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{lichHPLine} 0{lichHP}");
            }

            //Lich damage
            Console.SetCursorPosition(width + 2, 12);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"DMG = 1d4");

            //Ogre health
            if (ogreHP > 9)
            {
                Console.SetCursorPosition(width + 2, 14);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{ogreHPLine} {ogreHP}");
            }
            else if (ogreHP < 10)
            {
                Console.SetCursorPosition(width + 2, 14);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{ogreHPLine} 0{ogreHP}");
            }

            //Ogre damage
            Console.SetCursorPosition(width + 2, 15);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"DMG = 1d5");

            //Chimera bossUI border
            if (lichHP == 0 && slimeHP == 0 && ogreHP == 0)
            {
                //Removing old enemyNPCUI with spaces, so I can place new Chimera bossUI at same spot.

                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 15; x++)
                    {
                        Console.SetCursorPosition(width + x, 7 + y);
                        Console.Write(" ");
                    }
                }

                //Drawing new border for Chimera bossUI

                Console.SetCursorPosition(width + 1, 7);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.Write("╔");
                for (int borderLengthTop = 0; borderLengthTop < 12; borderLengthTop++)
                {
                    Console.Write("═");
                }
                Console.Write("╗");

                for (int borderLengthHeight = 8; borderLengthHeight < 13; borderLengthHeight++)
                {
                    Console.SetCursorPosition(width + 1, borderLengthHeight);
                    Console.Write("║");
                    Console.SetCursorPosition(width + 14, borderLengthHeight);
                    Console.Write("║");
                }

                Console.SetCursorPosition(width + 1, 13);
                Console.Write("╚");
                for (int borderLengthBottom = 0; borderLengthBottom < 12; borderLengthBottom++)
                {
                    Console.Write("═");
                }
                Console.Write("╝");

                //Chimera boss title
                Console.SetCursorPosition(width + 2, 8);
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.Write("CHIMERA");

                //Chimera health
                if (chimeraBossHP > 9)
                {
                    Console.SetCursorPosition(width + 2, 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Health = {chimeraBossHP}");
                }
                else if (chimeraBossHP < 10)
                {
                    Console.SetCursorPosition(width + 2, 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Health = 0{chimeraBossHP}");
                }

                //Chimera damage
                Console.SetCursorPosition(width + 2, 12);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"DMG = 1d6+1");
            }
        }

        static void CombatSequence()
        {
            var random = new Random();

            void BlockAudio()
            {
                SoundPlayer blockPlayer = new SoundPlayer("Shield Block.wav");
                blockPlayer.Play();
            }

            void AttackAudio()
            {
                SoundPlayer attackPlayer = new SoundPlayer("Sword slash Catalyst Dungeon.wav");
                attackPlayer.Play();
            }

            void DamageTakenAudio()
            {
                SoundPlayer damageTakenPlayer = new SoundPlayer("Player Damage Taken.wav");
                damageTakenPlayer.Play();
            }

            void RemovePreviousCombatLog()
            {
                Console.SetCursorPosition(0, height + 1);
                Console.WriteLine("                                                            ");

                //Removes playerAbilityLine
                Console.SetCursorPosition(0, height + 2);
                Console.WriteLine("                                                            ");

                //Removes combatLogLine
                Console.SetCursorPosition(0, height + 3);
                Console.WriteLine("                                                            ");

                //Removes combatLogLine
                Console.SetCursorPosition(0, height + 4);
                Console.WriteLine("                                                            ");

                //Removes combatLogLine
                Console.SetCursorPosition(0, height + 6);
                Console.WriteLine("                                                            ");
            }

            void CombatDamageRolls(char monsterType)
            {
                var random = new Random();

                switch (monsterType)
                {
                    case 'S':
                        int slimeDMGRoll = random.Next(1, 4);

                        slimeDMG = slimeDMGRoll;
                        break;

                    case 'L':
                        int lichDMGRoll = random.Next(1, 5);

                        lichDMG = lichDMGRoll;
                        break;

                    case 'O':
                        int ogreDMGRoll = random.Next(1, 6);

                        ogreDMG = ogreDMGRoll;
                        break;

                    case 'C':
                        int chimeraDMGRoll = random.Next(1, 6);

                        chimeraBossDMG = chimeraDMGRoll + 1;
                        break;
                }
            }

            //Slime combat.
            if (level[playerX + 1, playerY] == 'S' || level[playerX - 1, playerY] == 'S' || level[playerX, playerY + 1] == 'S' || level[playerX, playerY - 1] == 'S' || level[playerX - 1, playerY - 1] == 'S' || level[playerX + 1, playerY - 1] == 'S' || level[playerX - 1, playerY + 1] == 'S' || level[playerX + 1, playerY + 1] == 'S')
            {
                Console.SetCursorPosition(0, height + 1);
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("You are engaged in combat with a Slime");

                while (true)
                {
                    if (slimeHP > 0)
                    {
                        Console.SetCursorPosition(0, height + 2);
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("X = Attack, B = Block");

                        //Slime's 1d3 damage roll
                        CombatDamageRolls(slime);

                        var playerInput = Console.ReadKey();

                        switch (playerInput.Key)
                        {
                            //case of attack.
                            case ConsoleKey.X:

                                AttackAudio();

                                slimeHP = slimeHP - playerDMG;
                                playerHP = playerHP - slimeDMG;

                                Console.SetCursorPosition(0, height + 3);
                                Console.Write($" You swung at the Slime for {playerDMG} DMG");

                                Console.SetCursorPosition(0, height + 4);
                                Console.Write($" Slime hit you for {slimeDMG} DMG");

                                break;

                            //Case of block.
                            case ConsoleKey.B:

                                int blockChanceRoll = random.Next(6);

                                //Successful block.
                                if (blockChanceRoll > 2)
                                {
                                    BlockAudio();

                                    slimeHP = slimeHP - slimeDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write("You succesfully blocked the slime's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The slime hurt itself for {slimeDMG} DMG");
                                }

                                //Unsuccessful block.
                                else if (blockChanceRoll < 3)
                                {
                                    DamageTakenAudio();

                                    playerHP = playerHP - slimeDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write($"You failed to block the slime's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The slime hits you for {slimeDMG} DMG");
                                }
                                break;
                        }
                        Console.SetCursorPosition(0, height + 6);
                        Console.Write("Choose your next move!");

                        PlayerUI();
                        EnemyNPCUI();

                    }
                    else if (slimeHP < 1)
                    {
                        RemovePreviousCombatLog();

                        slimeHP = 0;

                        slime = ' ';
                        break;
                    }

                    if (playerHP < 1)
                    {
                        GameOverDisplay();
                    }
                }
            }

            //Lich Combat.
            else if (level[playerX + 1, playerY] == 'L' || level[playerX - 1, playerY] == 'L' || level[playerX, playerY + 1] == 'L' || level[playerX, playerY - 1] == 'L' || level[playerX - 1, playerY - 1] == 'L' || level[playerX + 1, playerY - 1] == 'L' || level[playerX - 1, playerY + 1] == 'L' || level[playerX + 1, playerY + 1] == 'L')
            {
                Console.SetCursorPosition(0, height + 1);
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("You are engaged in combat with a Lich");

                while (true)
                {
                    if (lichHP > 0)
                    {
                        Console.SetCursorPosition(0, height + 2);
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("X = Attack, B = Block");

                        //Lich's 1d4 damage roll.
                        CombatDamageRolls(lich);

                        var playerInput = Console.ReadKey();

                        switch (playerInput.Key)
                        {
                            //Case of attack.
                            case ConsoleKey.X:

                                AttackAudio();

                                lichHP = lichHP - playerDMG;
                                playerHP = playerHP - lichDMG;

                                Console.SetCursorPosition(0, height + 3);
                                Console.Write($" You swung at the Lich for {playerDMG} DMG");

                                Console.SetCursorPosition(0, height + 4);
                                Console.Write($" Lich casts icebolt and hits you for {lichDMG} DMG");

                                break;

                            //Case of block.
                            case ConsoleKey.B:

                                int blockChanceRoll = random.Next(6);

                                //successful block.
                                if (blockChanceRoll > 2)
                                {
                                    BlockAudio();

                                    lichHP = lichHP - lichDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write("You succesfully blocked the lich's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The lich hurt itself for {lichDMG} DMG");
                                }

                                //Unsuccessful block.
                                else if (blockChanceRoll < 3)
                                {
                                    DamageTakenAudio();

                                    playerHP = playerHP - lichDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write($"You failed to block the lich's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The lich hits you for {lichDMG} DMG");
                                }
                                break;
                        }
                        Console.SetCursorPosition(0, height + 6);
                        Console.Write("Choose your next move!");

                        PlayerUI();
                        EnemyNPCUI();

                    }
                    else if (lichHP < 1)
                    {
                        RemovePreviousCombatLog();

                        lichHP = 0;

                        lich = ' ';
                        break;
                    }

                    if (playerHP < 1)
                    {
                        GameOverDisplay();
                    }
                }
            }

            //Ogre combat.
            else if (level[playerX + 1, playerY] == 'O' || level[playerX - 1, playerY] == 'O' || level[playerX, playerY + 1] == 'O' || level[playerX, playerY - 1] == 'O' || level[playerX - 1, playerY - 1] == 'O' || level[playerX + 1, playerY - 1] == 'O' || level[playerX - 1, playerY + 1] == 'O' || level[playerX + 1, playerY + 1] == 'O')
            {
                Console.SetCursorPosition(0, height + 1);
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("You are engaged in combat with an Ogre");

                while (true)
                {
                    if (ogreHP > 0)
                    {
                        Console.SetCursorPosition(0, height + 2);
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("X = Attack, B = Block");

                        //Ogre's 1d5 damage roll.
                        CombatDamageRolls(ogre);

                        var playerInput = Console.ReadKey();

                        switch (playerInput.Key)
                        {
                            //Case of attack.
                            case ConsoleKey.X:

                                AttackAudio();

                                ogreHP = ogreHP - playerDMG;
                                playerHP = playerHP - ogreDMG;

                                Console.SetCursorPosition(0, height + 3);
                                Console.Write($" You swung at the Ogre for {playerDMG} DMG");

                                Console.SetCursorPosition(0, height + 4);
                                Console.Write($" Ogre overhead smashes you for {ogreDMG} DMG");

                                break;

                            //Case of block.
                            case ConsoleKey.B:

                                int blockChanceRoll = random.Next(6);

                                //Successful block.
                                if (blockChanceRoll > 2)
                                {
                                    BlockAudio();

                                    ogreHP = ogreHP - ogreDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write("You succesfully blocked the ogre's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The ogre hurt itself for {ogreDMG} DMG");
                                }

                                //Unsuccessful block.
                                else if (blockChanceRoll < 3)
                                {
                                    DamageTakenAudio();

                                    playerHP = playerHP - ogreDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write($"You failed to block the ogre's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The ogre hits you for {ogreDMG} DMG");
                                }
                                break;
                        }


                        Console.SetCursorPosition(0, height + 6);
                        Console.Write("Choose your next move!");

                        PlayerUI();
                        EnemyNPCUI();

                    }
                    else if (ogreHP < 1)
                    {
                        RemovePreviousCombatLog();

                        ogreHP = 0;

                        ogre = ' ';
                        break;
                    }

                    if (playerHP < 1)
                    {
                        GameOverDisplay();
                    }
                }
            }

            //Chimera boss combat.
            else if (level[playerX + 1, playerY] == 'C' || level[playerX - 1, playerY] == 'C' || level[playerX, playerY + 1] == 'C' || level[playerX, playerY - 1] == 'C' || level[playerX - 1, playerY - 1] == 'C' || level[playerX + 1, playerY - 1] == 'C' || level[playerX - 1, playerY + 1] == 'C' || level[playerX + 1, playerY + 1] == 'C')
            {
                Console.SetCursorPosition(0, height + 1);
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("You engaged the Chimera boss!");

                while (true)
                {
                    if (chimeraBossHP > 0)
                    {
                        Console.SetCursorPosition(0, height + 2);
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("X = Attack, B = Block");

                        //Chimera's damage roll from 2 to 7.
                        CombatDamageRolls(chimeraBoss);

                        var playerInput = Console.ReadKey();

                        switch (playerInput.Key)
                        {
                            //Case of attack.
                            case ConsoleKey.X:

                                AttackAudio();

                                chimeraBossHP = chimeraBossHP - playerDMG;
                                playerHP = playerHP - chimeraBossDMG;

                                Console.SetCursorPosition(0, height + 3);
                                Console.Write($" You swung at the Chimera for {playerDMG} DMG");

                                Console.SetCursorPosition(0, height + 4);
                                Console.Write($" Chimera strikes you for {chimeraBossDMG} DMG");

                                break;

                            //Case of block.
                            case ConsoleKey.B:

                                int blockChanceRoll = random.Next(6);

                                //Successful block.
                                if (blockChanceRoll > 2)
                                {
                                    BlockAudio();

                                    chimeraBossHP = chimeraBossHP - chimeraBossDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write("You succesfully blocked the Chimera's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The Chimera hurt itself for {chimeraBossDMG} DMG");
                                }

                                //Unsuccessful block.
                                else if (blockChanceRoll < 3)
                                {
                                    DamageTakenAudio();

                                    playerHP = playerHP - chimeraBossDMG;

                                    RemovePreviousCombatLog();

                                    Console.SetCursorPosition(0, height + 3);
                                    Console.Write($"You failed to block the Chimera's attack");

                                    Console.SetCursorPosition(0, height + 4);
                                    Console.Write($"The Chimera hits you for {chimeraBossDMG} DMG");
                                }
                                break;
                        }

                        Console.SetCursorPosition(0, height + 6);
                        Console.Write("Choose your next move!");

                        PlayerUI();
                        EnemyNPCUI();

                    }
                    else if (chimeraBossHP < 1)
                    {
                        RemovePreviousCombatLog();

                        chimeraBossHP = 0;

                        chimeraBoss = ' ';
                        break;
                    }

                    if (playerHP < 1)
                    {
                        GameOverDisplay();
                    }
                }
            }
        }

        static void BossSequence()
        {
            Console.ForegroundColor = levelColor[chimeraBossX, chimeraBossY];

            chimeraBoss = 'C';

            Console.SetCursorPosition(chimeraBossX, chimeraBossY);

            level[chimeraBossX, chimeraBossY] = chimeraBoss;
            levelColor[chimeraBossX, chimeraBossY] = ConsoleColor.DarkYellow;

            Console.Write(level[chimeraBossX, chimeraBossY]);

        }

        static void Main(string[] args)
        {
            //Setup console defaults.
            Console.CursorVisible = false;

            //Reads levelLayout file and puts it into a string list.
            dungeonLevelLayout = new List<string>(File.ReadAllLines("CatalystDungeonLevelLayout.txt"));

            GameIntro();

            DrawLevel();

            DisplayLevel();

            GameCompletionDisplay();

            Console.ReadKey(true);
        }
    }
}
