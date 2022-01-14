using System;

namespace Tank_Boss_level
{
    class Program
    {
        static void Main(string[] args)
        {

            //Introduction text

             Console.WriteLine("Something large and dangerous is approaching our position, soldier. We just recieved visuals,\nit's a humongous metal machine of destruction! We need YOU to take it out, alone!");
             Console.WriteLine();
             Console.WriteLine("But wait! Before that, you haven't introduced yourself... maybe you should have done that earlier.\nWhat is your name, soldier?");
             string userName = Console.ReadLine();
             Console.WriteLine("Took you long enough to introduce yourself, " + userName);
             Console.WriteLine();

             //battlefield


            var random = new Random();

            
            int tankDistance = random.Next(40, 71);

            Console.WriteLine("Let me provide you a map of the battlefield:");
            Console.WriteLine();

            Console.Write("_/");
            for (int tankStep = 0; tankStep < 78; tankStep++)
            {
                Console.Write("_");

                if (tankDistance == tankStep)
                {
                    Console.Write("T");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int shells = 0; shells < 5; shells++)
            {
                int shellsRemaining = 4 - shells;

                Console.WriteLine();
                Console.Write($"Aim your shot {userName}: ");
                int playerShot = Convert.ToInt32(Console.ReadLine());

                if (playerShot == tankDistance)
                {
                    Console.WriteLine("Woah, dude. You blew that thing right up. Well done!");
                    break;
                }
                else if (playerShot > tankDistance)
                {
                    Console.WriteLine($"Dude. You suck. That's way overboard.");
                }
                else Console.WriteLine($"Too short man, use your bloody aim next time.");

                Console.WriteLine($"Remaining shells: {shellsRemaining}");
            }
           

            //bonus round

            Console.Clear();
            Console.WriteLine($"Welcome to the bonus level, {userName}.");
            Console.WriteLine("Are you ready for the battle ahead?");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hah! As if your answer makes any difference.");
            Console.WriteLine("I have generously provided you with a new board. Have fun, soldier.");

            
            int tankDistance2 = random.Next(40, 71);
            Console.WriteLine();

            while (tankDistance2 > 0)
            {
                //Console.WriteLine(tankDistance2);
                Console.Write("_/");
                for (int tankStep = 0; tankStep < 78; tankStep++)
                {

                    if (tankDistance2 == tankStep)
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write($"Aim your shot, {userName}: ");
                int playerShot2 = Convert.ToInt32(Console.ReadLine());

                for (int hitStep = 0; hitStep < playerShot2 + 2; hitStep++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");

                if (playerShot2 == tankDistance2)
                {
                    Console.WriteLine("... Dude what the hell. Stop blowing up the tanks.");
                    break;
                }
                else
                {
                    Console.WriteLine("Try again, soldier.");
                }

                Console.ReadKey(true);
                Console.Clear();
                tankDistance2 -= random.Next(1, 16);
                if (tankDistance2 <= 0)
                {
                    Console.WriteLine("Sucks to be you man, you lost the bloody game. What a disappo-- I mean... try again-");
                }
            }
        }
    }
}

