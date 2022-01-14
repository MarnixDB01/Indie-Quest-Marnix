using System;

namespace Sort_an_array__Arrays____part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] levelmonsterCount = new int[10];

            for (int monsterIndex = 0; monsterIndex < levelmonsterCount.Length; monsterIndex++)
            {
                int monsterCount = random.Next(1, 31);
                levelmonsterCount[monsterIndex] = monsterCount;
            }
            Array.Sort(levelmonsterCount);

            Console.Write("Number of monsters in levels: ");
            Console.WriteLine(string.Join(", ", levelmonsterCount));

            Console.ReadKey(true);
        }
    }
}
