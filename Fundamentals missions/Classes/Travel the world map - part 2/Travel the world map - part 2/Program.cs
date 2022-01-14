using System;
using System.Collections.Generic;

namespace Travel_the_world_map___part_2
{
    class Location
    {
        public string Name;
        public string Description;
        public List<Location> Neighbors = new List<Location>();
    }

    class Program
    {
        static void ConnectLocations(Location a, Location b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        static void Main(string[] args)
        {
            //Creates list based off of the class Location which has our public strings.
            var locations = new List<Location>();

            //Adds the different locations, first by name, then by description.
            //Winterfell
            locations.Add(new Location
            {
                Name = "Winterfell",
                Description = "the stronghold and seat of House Greyjoy"
            });

            //The Trident
            locations.Add(new Location
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros"
            });

            //Riverrun
            locations.Add(new Location
            {
                Name = "Riverrun",
                Description = "the seat of House Tully, which was once occupied by House Frey"
            });

            //King's Landing
            locations.Add(new Location
            {
                Name = "King's Landing",
                Description = "the capital of the Seven Kingdoms"
            });

            //Highgarden
            locations.Add(new Location
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and is the regional capital of the Reach"
            });

            //Pyke
            locations.Add(new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy"
            });

            //I will not need to add all everywhere, because if I add Pyke as neighbor to Winterfell, then I will not need to add Winterfell as neighbor to Pyke anymore
            //Adding neighbors for Winterfell
            ConnectLocations(locations[0], locations[1]);
            ConnectLocations(locations[0], locations[5]);

            //Adding neighbors for Pyke
            ConnectLocations(locations[5], locations[2]);
            ConnectLocations(locations[5], locations[4]);

            //Adding neighbors for Riverrun
            ConnectLocations(locations[2], locations[1]);
            ConnectLocations(locations[2], locations[3]);

            //Adding neighbors for The Trident
            ConnectLocations(locations[1], locations[3]);

            //Adding neighbors for King's Landing
            ConnectLocations(locations[3], locations[4]);

            //adding neighbors for Highgarden
            ConnectLocations(locations[4], locations[2]);

            //currentLocation variables from indexes from the locations list.
            //randomly chooses index from the location list
            var random = new Random();
            var randomLocation = random.Next(6);

            var currentLocation = locations[randomLocation];

            Console.WriteLine($"Welcome to {currentLocation.Name}, {currentLocation.Description}.");
            Console.WriteLine();
            Console.WriteLine("Possible destinations are:");

            for (int neighborsIndex = 0; neighborsIndex < currentLocation.Neighbors.Count; neighborsIndex++)
            {
                Console.WriteLine($"{neighborsIndex + 1}. {currentLocation.Neighbors[neighborsIndex].Name}");
            }
            
            Console.ReadKey(true);
        }
    }
}