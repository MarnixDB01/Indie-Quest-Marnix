using System;
using System.IO;
using System.Collections.Generic;

namespace Minotaur_s_lair___part_1
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
        static int startpoint;

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

            DrawMap(width, height);

            Console.ReadKey(true);
        }
        static void DrawMap(int width, int height)
        {
            var mapColor = new ConsoleColor[width, height];

            //Creating 2d array from width and height previously extracted from the file.
            map = new char[width, height];

            //Inserting information from the text file "MazeLevel.txt" into the 2d char array.
            for (int mazeY = 0; mazeY < height; mazeY++)
            {
                for (int mazeX = 0; mazeX < width; mazeX++)
                {
                    //Creating a new string every new Y line in the list
                    string mazeCurrentLine = mazeList[mazeY];
                    //Creating a char list out of the line
                    //List<char> mazeCurrentLineList = new List<char>(mazeCurrentLine);

                    //Generating each X coordinate in the 2d char array as the char from the same X index as the array from the list
                    map[mazeX, mazeY] = mazeList[mazeY][mazeX];
                    mapColor[mazeX, mazeY] = ConsoleColor.DarkMagenta;

                    //Setting player coordinates at startpoint when map[x, y] is at 'S'-"startpoint".
                    if (map[mazeX, mazeY] == 'S')
                    {
                        playerX = mazeX;
                        playerY = mazeY;

                        //setting player at startpoint to a smiley character.
                        map[playerX, playerY] = '☺';
                        mapColor[playerX, playerY] = ConsoleColor.Yellow;

                        //Making startpoint variable
                        startpoint = map[playerX, playerY];
                    }
                    //Whenever x, y coordinates = M-"minotaur", make it the color Red
                    if (map[mazeX, mazeY] == 'M')
                    {
                        mapColor[mazeX, mazeY] = ConsoleColor.Red;
                    }
                }
            }
            //Call Generate trees method
            GenerateTrees(mapColor);

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
        }

        //Method for generating trees in first three rows.
        static void GenerateTrees(ConsoleColor[,] mapColor)
        {
            var random = new Random();

            //Generates trees
            //Parameter set to if Y < 3, which means first 3 rows
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int treetype = random.Next(6);

                    //If x, y location is not a smiley, then check if a tree can will be "planted"
                    //If treetype is < 2 then "plant" tree, if not, do nothing.
                    if (map[x, y] != '☺')
                    {
                        if (treetype < 2)
                        {
                            map[x, y] = '♠';
                            mapColor[x, y] = ConsoleColor.DarkGreen;
                        }
                    }
                }
            }
        }
    }
}
