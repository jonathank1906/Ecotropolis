using System;
using System.Collections.Generic;

namespace Ecotropolis
{
    public class Game
    {
        private Player player;
        private List<Location> locations;

        public static void Main(string[] args)
        {
            Game game = new Game();
            game.DisplayStartMenu();
        }

        public Game()
        {
            player = new Player();
            locations = new List<Location>
            {
                new Location("City Center"),
                new Location("Suburban Area"),
                new Location("Industrial Zone"),
                new Location("Historic District"),
                new Location("Coastal Area"),
                new Location("Rural Village")
            };
        }

        public void DisplayStartMenu()
        {
            Console.WriteLine("Welcome to Ecotropolis!");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DisplayTravelMenu();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }

        public void DisplayTravelMenu()
        {
            Console.WriteLine("Select a location to travel to:");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {locations[i].Name}");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < locations.Count)
            {
                Travel(locations[choice]);
            }
            else
            {
                Console.WriteLine("Invalid choice. Returning to menu.");
                DisplayTravelMenu();
            }
        }

        public void Travel(Location location)
        {
            Console.WriteLine($"Traveling to {location.Name}...");
            location.DisplayStartMessage();
            location.PlayLocation(player);
        }
    }
}
