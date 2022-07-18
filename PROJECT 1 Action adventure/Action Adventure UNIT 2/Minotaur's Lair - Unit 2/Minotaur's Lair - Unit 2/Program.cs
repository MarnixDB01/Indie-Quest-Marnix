using System;
using System.IO;
using System.Collections.Generic;

namespace Minotaur_s_Lair___Unit_2
{
    class Program
    {
        //Store the values outside of the main method so it is easy access for other methods.
        //width and height of the maze
        static int width;
        static int height;

        //2d array of current maze state.
        static char[,] map;
        static ConsoleColor[,] mapColor;

        //Original maze layout.
        static List<string> originalMazeLayoutLines;

        //Player coordinates & startpoint of maze.
        static int playerX;
        static int playerY;

        static void Main(string[] args)
        {
            //Setup console defaults.
            Console.CursorVisible = false;

            //Reads the file and makes it a string list.
            originalMazeLayoutLines = new List<string>(File.ReadAllLines("MazeLevel.txt"));

            //Putting maze title from first line into a new string.
            string mazeTitle = originalMazeLayoutLines[0];

            //Putting maze sizes from second line into a new string.
            string mazeSize = originalMazeLayoutLines[1];

            //Removes mazeSize and mazeTitle lines.
            for (int removelineIndex = 0; removelineIndex < 2; removelineIndex++)
            {
                originalMazeLayoutLines.RemoveAt(0);
            }

            //Getting width and height values from the indexes of the mazeSize string ("39x21").
            string[] number = mazeSize.Split('x');
            width = Convert.ToInt32((number[0]));
            height = Convert.ToInt32((number[1]));

            //Setup the map including procedural data.
            SetupLevel();

            //Main title screen.
            DisplayTitleScreen(mazeTitle);

            //Start gameplay.
            PlayLevel();

            Console.ReadKey(true);
        }

        static void DisplayTitleScreen(string mazeTitle)
        {
            //Display welcome.
            Console.WriteLine($"Get ready for: {mazeTitle}");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");

            //Add ReadKey so maze doesnt pop up instantly.
            Console.ReadKey();

            //Clear so welcome message doesnt stay.
            Console.Clear();
        }

        static void SetupLevel()
        {
            var random = new Random();

            //Creating 2d array from width and height previously extracted from the file.
            map = new char[width, height];

            //mapColor array same size as map.
            mapColor = new ConsoleColor[width, height];

            //Inserting information from the original maze layout into the 2d map array.
            for (int mazeY = 0; mazeY < height; mazeY++)
            {
                for (int mazeX = 0; mazeX < width; mazeX++)
                {
                    //Generating each X coordinate in the 2d char array as the char from the same X index as the array from the list.
                    map[mazeX, mazeY] = originalMazeLayoutLines[mazeY][mazeX];
                    mapColor[mazeX, mazeY] = ConsoleColor.Gray;

                    if (mazeY < 3)
                    {
                        int treeChance = random.Next(6);

                        if (map[mazeX, mazeY] == ' ')
                        {
                            if (treeChance < 2)
                            {
                                map[mazeX, mazeY] = '♠';
                                mapColor[mazeX, mazeY] = ConsoleColor.DarkGreen;
                            }
                        }
                    }

                    //Setting player coordinates at startpoint when map[x, y] is at 'S'-"startpoint".
                    if (map[mazeX, mazeY] == 'S')
                    {
                        playerX = mazeX;
                        playerY = mazeY;

                        //setting player at startpoint to a smiley character.
                        map[playerX, playerY] = '☺';
                        mapColor[playerX, playerY] = ConsoleColor.DarkYellow;

                        //Replaces the S from the list to a space. Otherwise the S will remain on the map.
                        originalMazeLayoutLines[mazeY] = originalMazeLayoutLines[mazeY].Replace("S", " ");
                    }
                    //Whenever x, y coordinates = M-"minotaur", make it the color Red
                    if (map[mazeX, mazeY] == 'M')
                    {
                        mapColor[mazeX, mazeY] = ConsoleColor.Red;
                    }
                }
            }
        }

        static void PlayLevel()
        {
            //Drawing map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = mapColor[x, y];
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }

            //Infinite loop for movement inputs
            while (true)
            {
                var playerInput = Console.ReadKey();

                Console.ForegroundColor = mapColor[playerX, playerY];

                //Move player with the arrow keys.
                void RemovePlayerFromCurrentPosition()
                {
                    //Writes out the char from the original list, which we previously put into the array. (2 lines above).
                    map[playerX, playerY] = originalMazeLayoutLines[playerY][playerX];

                    //sets cursor to X, Y location.
                    Console.SetCursorPosition(playerX, playerY);

                    //Writes out new data to the console.
                    Console.Write(map[playerX, playerY]);
                }

                //Makes X, Y location in array original from mazeList on that X, Y location.
                //Move playerX or Y coordinate to whichever directional arrow key was pressed.
                switch (playerInput.Key)
                {
                    case ConsoleKey.UpArrow:

                        if (map[playerX, playerY - 1] == ' ' || map[playerX, playerY - 1] == 'M')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerY--;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (map[playerX, playerY + 1] == ' ' || map[playerX, playerY + 1] == 'M')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerY++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:

                        if (map[playerX - 1, playerY] == ' ' || map[playerX - 1, playerY] == 'M')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerX--;
                        }
                        break;

                    case ConsoleKey.RightArrow:

                        if (map[playerX + 1, playerY] == ' ' || map[playerX + 1, playerY] == 'M')
                        {
                            RemovePlayerFromCurrentPosition();
                            playerX++;
                        }
                        break;
                    //Ends game if Escape key is pressed.
                    case ConsoleKey.Escape:
                        return;
                }
                bool reachedMinotaur = map[playerX, playerY] == 'M';

                //Set cursor to new X, Y position, which was changed in the switch above depending on which directional arrow key was pressed.
                Console.SetCursorPosition(playerX, playerY);

                //Generate smiley on the new cursor position.
                map[playerX, playerY] = '☺';

                //Make smiley char dark yellow color.
                mapColor[playerX, playerY] = ConsoleColor.DarkYellow;

                //Write out smiley in cursor position.
                Console.Write(map[playerX, playerY]);

                //Winning condition, if current location = M.. WIN!
                if (reachedMinotaur)
                {
                    //Changes winning text to gray!
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //Set cursorposition to below the maze
                    //Write out the winning message.
                    Console.SetCursorPosition(0, height);
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, you have beaten the Minotaur's Maze");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
