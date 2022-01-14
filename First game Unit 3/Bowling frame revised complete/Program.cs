using System;

namespace Bowling_frame_revised_complete
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int totalPins = 10;
            int bowlingRoll1 = random.Next(0, totalPins + 1);
            int bowlingRoll2 = random.Next(0, ((totalPins + 1) - bowlingRoll1));
            int knockedPins = bowlingRoll1 + bowlingRoll2;

            Console.Write($"First roll: ");

            if (bowlingRoll1 == 10)
            {
                Console.WriteLine("X");
            }
            else
            {
                if (bowlingRoll1 == 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine(bowlingRoll1);
                }

                Console.Write($"Second roll: ");
                if (knockedPins == 10)
                {
                    Console.WriteLine($"/");
                }
                else if (bowlingRoll2 == 0)
                {
                    Console.WriteLine($"-");
                }
                else
                {
                    Console.WriteLine(bowlingRoll2);


                }
            }
            Console.WriteLine($"Knocked pins: {knockedPins}");
        }


    }
}
