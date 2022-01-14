using System;


namespace City_Generator__Arrays____boss_level_part_1
{
    class Program
    {
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {

            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            //direction = right
            if (direction == 0)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x >= startX)
                    {
                        roads[x, startY] = true;
                    }
                }
            }
            //direction = down
            else if (direction == 1)
            {
                for (int y = 0; y <= height - 1; y++)
                {
                    if (y >= startY)
                    {
                        roads[startX, y] = true;
                    }
                }
            }
            //direction = left
            else if (direction == 2)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x <= startX)
                    {
                        roads[x, startY] = true;
                    }
                }
            }
            //direction = up
            else if (direction == 3)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y <= startY)
                    {
                        roads[startX, y] = true;
                    }
                }
            }
        }

        static void GenerateIntersection(bool[,] roads, int x, int y)
        {
            var random = new Random();

            for (int directionIndex = 0; directionIndex < 4; directionIndex++)
            {
                int percent = random.Next(11);
                if (percent < 7)
                {
                    GenerateRoad(roads, x, y, directionIndex);
                }
            }
        }
        static void DrawMap(bool[,] roads)
        {
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            //draw array
            for (int y = 0; y < height; y++)
            {
                //Draw roads
                for (int x = 0; x < width; x++)
                {
                    if (roads[x, y])
                    {
                        bool roadUp = y > 0 && roads[x, y - 1];
                        bool roadDown = y < height - 1 && roads[x, y + 1];
                        bool roadLeft = x > 0 && roads[x - 1, y];
                        bool roadRight = x < width - 1 && roads[x + 1, y];

                        if (roadRight && roadLeft && !roadUp && !roadDown)
                        {
                            Console.Write("â•");
                        }
                        else if (!roadRight && !roadLeft && roadUp && roadDown)
                        {
                            Console.Write("â•‘");
                        }
                        else if (roadRight && !roadLeft && !roadUp && roadDown)
                        {
                            Console.Write("â•”");
                        }
                        else if (roadRight && !roadLeft && roadUp && !roadDown)
                        {
                            Console.Write("â•š");
                        }
                        else if (!roadRight && roadLeft && !roadUp && roadDown)
                        {
                            Console.Write("â•—");
                        }
                        else if (!roadRight && roadLeft && roadUp && !roadDown)
                        {
                            Console.Write("â•");
                        }
                        else if (roadRight && roadLeft && !roadUp && roadDown)
                        {
                            Console.Write("â•¦");
                        }
                        else if (roadRight && roadLeft && roadUp && roadDown)
                        {
                            Console.Write("â•¬");
                        }
                        else if (roadRight && roadLeft && roadUp && !roadDown)
                        {
                            Console.Write("â•©");
                        }
                        else if (roadRight && !roadLeft && roadUp && roadDown)
                        {
                            Console.Write("â• ");
                        }
                        else if (!roadRight && roadLeft && roadUp && roadDown)
                        {
                            Console.Write("â•£");
                        }
                        else if (roadUp || roadDown)
                        {
                            Console.Write("â•‘");
                        }
                        else
                        {
                            Console.Write("â•");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var random = new Random();
            int width = 80;
            int height = 20;
            var roads = new bool[width, height];
            var intersectionsCount = 5;

            //Repeat method for multiple roads
            for (int i = 0; i < intersectionsCount; i++)
            {
                int intersectionX = random.Next(width);
                int intersectionY = random.Next(height);

                GenerateIntersection(roads, intersectionX, intersectionY);
            }
            DrawMap(roads);
        }
    }
}