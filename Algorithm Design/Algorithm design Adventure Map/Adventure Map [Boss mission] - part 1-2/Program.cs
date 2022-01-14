using System;

namespace Algorithm_boss_Adventure_map
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 80;
            int height = 20;

            //Calls method which will generate the array based on the changeable parameters width and height.
            DrawMap(width, height);

        }

        //Method which generates Watch Tower
        static void GenerateFarmHouse(char[,] map, ConsoleColor[,] mapColor, int houseStartY, int houseStartX)
        {
            //farmHouse generation
            for (int houseLayerIndex = 0; houseLayerIndex < 2; houseLayerIndex++)
            {
                //farmHouse base
                if (houseLayerIndex < 1)
                    map[houseStartX + 5, houseStartY - houseLayerIndex] = '|';
                map[houseStartX + 9, houseStartY - houseLayerIndex] = '|';
                mapColor[houseStartX + 5, houseStartY - houseLayerIndex] = ConsoleColor.DarkRed;
                mapColor[houseStartX + 9, houseStartY - houseLayerIndex] = ConsoleColor.DarkRed;

                //farmHouse roof
                if (houseLayerIndex == 1)
                {
                    map[houseStartX + 5, houseStartY - houseLayerIndex] = '/';
                    map[houseStartX + 9, houseStartY - houseLayerIndex] = '\\';
                    map[houseStartX + 6, houseStartY - houseLayerIndex - 1] = '_';
                    map[houseStartX + 7, houseStartY - houseLayerIndex - 1] = '_';
                    map[houseStartX + 8, houseStartY - houseLayerIndex - 1] = '_';
                    mapColor[houseStartX + 5, houseStartY - houseLayerIndex] = ConsoleColor.Red;
                    mapColor[houseStartX + 9, houseStartY - houseLayerIndex] = ConsoleColor.Red;
                    mapColor[houseStartX + 6, houseStartY - houseLayerIndex - 1] = ConsoleColor.Red;
                    mapColor[houseStartX + 7, houseStartY - houseLayerIndex - 1] = ConsoleColor.Red;
                    mapColor[houseStartX + 8, houseStartY - houseLayerIndex - 1] = ConsoleColor.Red;

                }
            }
            //farmHouse Silo generation
            for (int towerLayerIndex = 0; towerLayerIndex < 4; towerLayerIndex++)
            {
                //farmHouse Silo base
                if (towerLayerIndex < 3)
                {
                    map[houseStartX + 10, houseStartY - towerLayerIndex] = '|';
                    map[houseStartX + 12, houseStartY - towerLayerIndex] = '|';
                    mapColor[houseStartX + 10, houseStartY - towerLayerIndex] = ConsoleColor.DarkGray;
                    mapColor[houseStartX + 12, houseStartY - towerLayerIndex] = ConsoleColor.DarkGray;
                }
                //farmHouse Silo roof
                if (towerLayerIndex == 3)
                {
                    map[houseStartX + 10, houseStartY - towerLayerIndex] = '/';
                    map[houseStartX + 12, houseStartY - towerLayerIndex] = '\\';
                    map[houseStartX + 11, houseStartY - towerLayerIndex - 1] = '_';
                    mapColor[houseStartX + 10, houseStartY - towerLayerIndex] = ConsoleColor.Gray;
                    mapColor[houseStartX + 12, houseStartY - towerLayerIndex] = ConsoleColor.Gray;
                    mapColor[houseStartX + 11, houseStartY - towerLayerIndex - 1] = ConsoleColor.Gray;
                }
            }
        }
        //Generate wheatfield
        static void GenerateWheatField(char[,] map, ConsoleColor[,] mapcolor, int fieldWidth, int fieldHeight, int wheatFieldStartPointY)
        {
            var random = new Random();
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            int wheatFieldStartPointX = 0;

            //Finding startpoint for wheat field
            for (int mapArrayX = 1; mapArrayX < (width / 4) * 2; mapArrayX++)
            {
                bool foundWall = map[mapArrayX, wheatFieldStartPointY] == '|' || map[mapArrayX, wheatFieldStartPointY] == '\\' || map[mapArrayX, wheatFieldStartPointY] == '/';

                if (foundWall)
                {
                    wheatFieldStartPointX = mapArrayX + 14;
                    break;
                }
            }
            //Generating the wheat field
            for (int wheatFieldHeigtIndex = 0; wheatFieldHeigtIndex < fieldHeight; wheatFieldHeigtIndex++)
            {
                for (int wheatFieldWidthIndex = 0; wheatFieldWidthIndex < fieldWidth; wheatFieldWidthIndex++)
                {
                    int wheatGrowthSize = random.Next(4);

                    bool isEmptyWheat = map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] == ' ';

                    if (wheatGrowthSize == 0)
                    {
                        map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex - 1] = '╦';
                        mapcolor[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex - 1] = ConsoleColor.DarkYellow;
                        if (isEmptyWheat)
                        {
                            map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = '│';
                            mapcolor[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = ConsoleColor.DarkYellow;
                        }
                    }
                    else if (wheatGrowthSize == 1)
                    {
                        map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex - 1] = '║';
                        mapcolor[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex - 1] = ConsoleColor.DarkYellow;
                        if (isEmptyWheat)
                        {
                            map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = '│';
                            mapcolor[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = ConsoleColor.DarkYellow;
                        }

                    }
                    else if (isEmptyWheat)
                    {
                        map[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = '|';
                        mapcolor[wheatFieldStartPointX + wheatFieldWidthIndex, wheatFieldStartPointY - wheatFieldHeigtIndex] = ConsoleColor.DarkYellow;
                    }
                }
            }
        }

        //Method which decides if a curve will be generated on the set location within the array.
        static void GenerateCurve(char[,] map, ConsoleColor[,] mapColor, ConsoleColor curveColor, int curveWidth, int curveChance, int startPosQuarters)
        {
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            var random = new Random();
            //Starting position depending on quarters of the map
            int curveX = (width / 4) * startPosQuarters;
            for (int curveY = 1; curveY < height - 1; curveY++)
            {
                //Decides if the curve will go left, right or go straight
                int curveChange = random.Next(curveChance);
                //curveRight
                if (curveChange == 0 && curveX < width - 2)
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '\\';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }
                    curveX++;
                }
                //curveLeft
                else if (curveChange == 1 && curveX > 1)
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '/';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }
                    curveX--;
                }
                //straight
                else
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '|';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }
                }
            }
        }
        //Method which generates the intersection of a curve.
        static void GenerateCurveIntersection(char[,] map, ConsoleColor[,] mapColor, int intersectionLength, string edgeSymbols, ref int roadX, int roadY, ConsoleColor roadColor, ConsoleColor edgeColor)
        {
            int width = map.GetLength(0);
            int symbolIndex = 0;

            for (int roadBridge = 0; roadBridge < intersectionLength; roadBridge++)
            {
                //Depending on the chosen parameter symbol at callMethod, it generates it with the set length parameter.
                char edgeSymbol = edgeSymbols[symbolIndex];
                symbolIndex = (symbolIndex + 1) % edgeSymbols.Length;
                map[roadX, roadY] = '#';
                map[roadX, roadY - 1] = edgeSymbol;
                map[roadX, roadY + 1] = edgeSymbol;
                mapColor[roadX, roadY] = roadColor;
                mapColor[roadX, roadY - 1] = edgeColor;
                mapColor[roadX, roadY + 1] = edgeColor;
                roadX++;
                if (roadX == width - 1)
                {
                    break;
                }
            }
        }
        static void DrawMap(int width, int height)
        {
            //Different colors set into an array depending on elements.
            var map = new char[width, height];
            var mapColor = new ConsoleColor[width, height];
            var forestColor = ConsoleColor.Green;
            var borderColor = ConsoleColor.Yellow;
            var riverColor = ConsoleColor.DarkBlue;
            var wallColor = ConsoleColor.DarkGray;
            var roadColor = ConsoleColor.Yellow;
            var bridgeColor = ConsoleColor.DarkGray;
            var random = new Random();
            int wheatFieldStartPointY = 7;
            int farmhouseStartPointY = 7;

            //Generate border and trees
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = ' ';
                    //GenerateBorder
                    //Top left corner
                    if (x == 0 && y == 0)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Top row
                    else if (x < width - 1 && y == 0)
                    {
                        map[x, y] = '-';
                        mapColor[x, y] = borderColor;
                    }
                    //Top right corner
                    else if (x == width - 1 && y == 0)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Left row
                    else if (x == 0 && y > 0 && y < height - 1)
                    {
                        map[x, y] = '|';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom left corner
                    else if (x == 0 && y == height - 1)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom row
                    else if (x > 0 && x < width - 1 && y == height - 1)
                    {
                        map[x, y] = '-';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom right corner
                    else if (x == width - 1 && y == height - 1)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Right row
                    else if (x == width - 1 && y > 0 && y < height - 1)
                    {
                        map[x, y] = '|';
                        mapColor[x, y] = borderColor;
                    }
                    //GenerateTrees (Decreasing density over x amount width)
                    else if (x > 0 && x < width / 4 && y > 0 && y < height - 1)
                    {
                        int treeType = random.Next(6);
                        int rng = random.Next(width / 4 + 1);
                        if (rng >= x)
                        {
                            //Character for tree depending on treetype roll
                            string treeTypes = "T@%()A";
                            map[x, y] = treeTypes[treeType];

                            //Forest color
                            mapColor[x, y] = forestColor;
                        }
                    }
                }

                //Adventure map title generation
                for (int titleX = 0; titleX < width; titleX++)
                {
                    string title = "ADVENTURE MAP";
                    if (titleX == width / 2 - 6 && y == 1)
                    {
                        for (int titleIndex = 0; titleIndex < title.Length; titleIndex++)
                        {
                            map[titleX, y] = title[titleIndex];
                            mapColor[titleX, y] = borderColor;
                            titleX++;
                        }
                    }
                }
            }
            //calling GenerateCurve method with different parameters depending on if it's the wall or river.
            //Generate River
            GenerateCurve(map, mapColor, riverColor, 3, 3, 3);
            //Generate Wall
            GenerateCurve(map, mapColor, wallColor, 2, 25, 1);

            //local function instead of a seperate method
            bool IsCurve(int x, int y)
            {
                return map[x, y] == '|' || map[x, y] == '\\' || map[x, y] == '/';
            }

            //Generate FarmHouse
            
            for (int farmLocationX = 1; farmLocationX < (width / 4) * 2; farmLocationX++)
            {
                //For each curve it will put tower char at +5 from it. So if I didn't cap the towerLocationX before river startpoint.
                //Then there would be a watchtower of thickness 3 after the river!
                //Could do seperate method so when IsCurve, call the method with starting point which pre generates the tower!.
                if (IsCurve(farmLocationX, farmhouseStartPointY))
                {
                    GenerateFarmHouse(map, mapColor, farmhouseStartPointY, farmLocationX);
                    break;
                }
            }

            //GenerateWheatField
            GenerateWheatField(map, mapColor, 15, 4, wheatFieldStartPointY);

            //local function for generating the riverRoad instead of a seperate method
            //Prepare for riverRoad generation
            void GenerateRiverRoad(int x, int startY)
            {
                for (int riverRoad = startY; riverRoad < height - 1; riverRoad++)
                {
                    int riverGap = 4;
                    if (x < width - riverGap && IsCurve(x + riverGap, riverRoad) && map[x + riverGap - 1, riverRoad] == ' ' && mapColor[x + riverGap, riverRoad] == riverColor)
                    {
                        map[x, riverRoad] = '#';
                        mapColor[x, riverRoad] = roadColor;
                    }
                }
            }

            //Generate roads
            int roadY = height / 2;
            for (int roadX = 1; roadX < width - 1; roadX++)
            {
                //Road up or down
                int roadChange = random.Next(11);
                if (roadChange == 0 && roadY > Math.Max(wheatFieldStartPointY, farmhouseStartPointY) + 1) 
                {
                    roadY--;
                }
                else if (roadChange == 1 && roadY < height - 2)
                {
                    roadY++;
                }
                //Generating the river road
                GenerateRiverRoad(roadX, roadY);
                //Generating the bridge
                int bridgeGap = 2;
                if (roadX < width - bridgeGap && IsCurve(roadX + bridgeGap, roadY) && mapColor[roadX + bridgeGap, roadY] == riverColor)
                {
                    int bridgeLength = 7;
                    for (int bridgeX = 0; bridgeX < bridgeLength; bridgeX++)
                    {
                        GenerateRiverRoad(roadX + bridgeX, roadY);
                    }
                    GenerateCurveIntersection(map, mapColor, bridgeLength, "=", ref roadX, roadY, roadColor, bridgeColor);
                }
                //Generating the towers
                int towerGap = 0;
                if (roadX < width - towerGap && IsCurve(roadX + towerGap, roadY) && mapColor[roadX + towerGap, roadY] == wallColor)
                {
                    int towerLength = 2;
                    GenerateCurveIntersection(map, mapColor, towerLength, "[]", ref roadX, roadY, roadColor, wallColor);
                }
                map[roadX, roadY] = '#';
                mapColor[roadX, roadY] = roadColor;
            }

            //Map Drawing! (Draws the generated map to the console)
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
    }
}