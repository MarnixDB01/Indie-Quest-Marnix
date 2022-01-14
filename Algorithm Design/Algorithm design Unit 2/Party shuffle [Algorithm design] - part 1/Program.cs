using System;
using System.Collections.Generic;

namespace Party_shuffle__Algorithm_design____part_1
{
    class Program
    {
        static List<string> ShuffleList(List<string> items)
        {
            int participantsCount = items.Count;
            var random = new Random();

            for (int i = participantsCount - 1; i > 0; i--)
            {
                int j = random.Next(0, i);
                string tempI = items[i];
                items[i] = items[j];
                items[j] = tempI;
            }
            return items;
        }

        static void Main(string[] args)
        {
            var participants = new List<string>
            {
            "Marnix",
            "Gustaf",
            "Viktor",
            "Matej",
            "Gommes",
            "Johanna",
            "Max",
            "Adam",
            "Arthur",
            "Sebastian"
            };

            Console.Write("Signed-up participants: ");
            Console.WriteLine(string.Join(", ", participants));
            Console.WriteLine();

            Console.WriteLine("Generating starting order ...");
            Console.WriteLine();

            List<string> shuffledParticipants = ShuffleList(participants);
            Console.WriteLine(string.Join(", ", shuffledParticipants));

            Console.ReadKey(true);
        }
    }
}
