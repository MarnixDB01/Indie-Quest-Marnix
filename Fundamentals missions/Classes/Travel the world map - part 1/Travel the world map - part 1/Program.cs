using System;
using System.Collections.Generic;

namespace Travel_the_world_map___part_1
{
    class Location
    {
        public string Name;
        public string Description;
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            //Creates list called locations based off of the class Location which has our public strings.
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
                Description = " the stronghold and seat of House Greyjoy"
            });

            //currentLocation variables from indexes from the locations list.
            var currentLocation1 = locations[2];
            var currentLocation2 = locations[5];
            var currentLocation3 = locations[3];

            //Displays the different currentLocations by Name and Description.
            Console.WriteLine($"Welcome to {currentLocation1.Name}, {currentLocation1.Description}.");
            Console.WriteLine("---");
            Console.WriteLine($"Welcome to {currentLocation2.Name}, {currentLocation2.Description}.");
            Console.WriteLine("---");
            Console.WriteLine($"Welcome to {currentLocation3.Name}, {currentLocation3.Description}.");

            Console.ReadKey(true);
        }
    }
    
}
