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
        //2d array of maze
        static char[,] map;

        static List<string> mazeList;

        //Player coordinates & startpoint of maze.
        static int playerX;
        static int playerY;
        static (int, int) playerPosition;

        static void Main(string[] args)
        {
            //Reads the file and makes it a string list.
            mazeList = new List<string>(File.ReadAllLines("MazeLevel.txt"));

            //putting maze title from first line into a new string
            string mazeTitle = mazeList[0];
            //putting maze sizes from second line into a new string
            string mazeSize = mazeList[1];

            //Removes mazeSize and mazeTitle lines.
            for (int removelineIndex = 0; removelineIndex < 2; removelineIndex++)
            {
                mazeList.RemoveAt(0);
            }

            //Getting width and height values from the indexes of the mazeSize string ("39x21").
            string[] number = mazeSize.Split('x');
            width = Convert.ToInt32((number[0]));
            height = Convert.ToInt32((number[1]));

            //Main title screen
            //Display welcome
            //Add ReadKey so maze doesnt pop up instantly
            //Clear so welcome message doesnt stay.
            Console.CursorVisible = false;

            Console.WriteLine($"Get ready for: {mazeTitle}");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Call DrawMap method
            DrawMap(width, height);

            Console.ReadKey(true);
        }
        
        //Method for drawing the map
        static void DrawMap(int width, int height)
        {
            var random = new Random();
            //mapColor array same size as map
            var mapColor = new ConsoleColor[width, height];

            //sets console cursor position to 0, 0 (top left)
            Console.SetCursorPosition(0, 0);

            //Creating 2d array from width and height previously extracted from the file.
            map = new char[width, height];


            //Inserting information from the text file "MazeLevel.txt" into the 2d char array.
            for (int mazeY = 0; mazeY < height; mazeY++)
            {
                for (int mazeX = 0; mazeX < width; mazeX++)
                {
                    //Creating a new string every new Y line in the list
                    //Creating a char list out of the line
                    //List<char> mazeCurrentLineList = new List<char>(mazeCurrentLine);

                    //Generating each X coordinate in the 2d char array as the char from the same X index as the array from the list
                    map[mazeX, mazeY] = mazeList[mazeY][mazeX];
                    mapColor[mazeX, mazeY] = ConsoleColor.Gray;

                    if (mazeY < 3)
                    {
                        int treetype = random.Next(6);

                        if (map[mazeX, mazeY] == ' ')
                        {
                            if (treetype < 2)
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

                        //set player position based on player's X and Y value
                        playerPosition = (playerX, playerY);

                        //setting player at startpoint to a smiley character.
                        map[playerX, playerY] = '☺';
                        mapColor[playerX, playerY] = ConsoleColor.DarkYellow;

                        //Replaces the S from the list to a space. Otherwise the S will remain on the map.
                        mazeList[mazeY] = mazeList[mazeY].Replace("S", " ");
                    }
                    //Whenever x, y coordinates = M-"minotaur", make it the color Red
                    if (map[mazeX, mazeY] == 'M')
                    {
                        mapColor[mazeX, mazeY] = ConsoleColor.Red;
                    }
                }
            }

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

                //Switch for deciding which key is pressed.
                //Makes X, Y location in array original from mazeList on that X, Y location.
                //sets cursor to X, Y location
                //Writes out the char from the original list, which we previously put into the array. (2 lines above)
                //Move playerX or Y coordinate to whichever directional arrow key was pressed.
                switch (playerInput.Key)
                {
                    case ConsoleKey.UpArrow:

                        if (map[playerX, playerY - 1] == ' ' || map[playerX, playerY - 1] == 'M')
                        {
                            map[playerX, playerY] = mazeList[playerY][playerX];
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerY--;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (map[playerX, playerY + 1] == ' ' || map[playerX, playerY + 1] == 'M')
                        {
                            map[playerX, playerY] = mazeList[playerY][playerX];
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerY++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:

                        if (map[playerX - 1, playerY] == ' ' || map[playerX - 1, playerY] == 'M')
                        {
                            map[playerX, playerY] = mazeList[playerY][playerX];
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerX--;
                        }
                        break;

                    case ConsoleKey.RightArrow:

                        if (map[playerX + 1, playerY] == ' ' || map[playerX + 1, playerY] == 'M')
                        {
                            map[playerX, playerY] = mazeList[playerY][playerX];
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerX++;
                        }
                        break;
                        //Ends game if Escape key is pressed.
                    case ConsoleKey.Escape:
                        return;
                }

                //Winning condition, if current location = M.. WIN!
                if (map[playerX, playerY] == 'M')
                {

                    //Set cursor to new X, Y position, which was changed in the switch above depending on which directional arrow key was pressed.
                    //Generate smiley on the new cursor position.
                    //Make smiley char dark yellow color.
                    //Write out smiley in cursor position.
                    Console.SetCursorPosition(playerX, playerY);
                    map[playerX, playerY] = '☺';
                    mapColor[playerX, playerY] = ConsoleColor.DarkYellow;
                    Console.Write(map[playerX, playerY]);

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

                //Same as with the winning condition, but it happens even if not winning!
                //--
                //Set cursor to new X, Y position, which was changed in the switch above depending on which directional arrow key was pressed.
                //Generate smiley on the new cursor position.
                //Make smiley char dark yellow color.
                //Write out smiley in cursor position.
                Console.SetCursorPosition(playerX, playerY);
                map[playerX, playerY] = '☺';
                mapColor[playerX, playerY] = ConsoleColor.DarkYellow;
                Console.Write(map[playerX, playerY]);
            }
        }
    }
}
