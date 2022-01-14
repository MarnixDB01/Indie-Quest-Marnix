using System;
using System.Collections.Generic;

namespace A_better_Join
{
    class Program
    {
        //Method to decide on when to implement "and" with/without serial comma
        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            Console.Write($"The heroes in the party are: ");

            //Counting total items in party
            int count = items.Count;
            if (count == 0)
            {
                return "";
            }
            else if (count == 1)
            {
                return items[0];
            }
            else if (count == 2)
            {
                return String.Join(" and ", items);
            }
            //If the party is more than 2, then put "and" inbetween last and second last.
            else
            {
                var itemsCopy = new List<string>(items);

                if (useSerialComma)
                {
                    itemsCopy[^1] = "and " + itemsCopy[^1];
                }
                else 
                //If no serial comma, then make second to last = second to last + "and" + last. This removes the serial comma.
                //also removing the last item otherwise it will write twice.
                {
                    itemsCopy[^2] = itemsCopy[^2] + " and " + itemsCopy[^1];
                    itemsCopy.Remove(itemsCopy[^1]);
                }
                return string.Join(", ", itemsCopy);
            }
        }

        static void Main(string[] args)
        {
            //Party list
            var party = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };

            //Party with serial comma before the and
            Console.WriteLine("With serial comma:");
            Console.WriteLine(JoinWithAnd(party));

            //3 total in party
            party.Remove("Jazlyn");
            Console.WriteLine(JoinWithAnd(party));

            //2 total in party
            party.Remove("Theron");
            Console.WriteLine(JoinWithAnd(party));

            //1 total in party
            party.Remove("Dayana");
            Console.WriteLine(JoinWithAnd(party));

            Console.WriteLine();

            //Restoring the removed party members (in order), otherwise the output will only write "Rolando"
            party.Remove("Rolando");
            party.Add("Jazlyn");
            party.Add("Theron");
            party.Add("Dayana");
            party.Add("Rolando");

            //Party without serial comma before the and
            Console.WriteLine("Without serial comma:");
            Console.WriteLine(JoinWithAnd(party, false));

            //3 total in party
            party.Remove("Jazlyn");
            Console.WriteLine(JoinWithAnd(party, false));

            //2 total in party
            party.Remove("Theron");
            Console.WriteLine(JoinWithAnd(party, false));

            //1 total in party
            party.Remove("Dayana");
            Console.WriteLine(JoinWithAnd(party, false));

            Console.ReadKey(true);
        }
    }
}
