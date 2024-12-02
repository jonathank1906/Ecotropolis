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
            Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣄⣤⣦⣶⣶⣖⣲⣦⣶⣼⣶⣿⣿⣿⣦⡤⠄⠀⠀⠀⢀⢀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣤⣿⣸⣷⣿⣿⣿⣿⠛⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠀⠀⠀⠀⠀⠘⢻⠻⠅⠀⠀⠀⠀⠀⠀⣀⣠⡀⠀⠀⠀⣈⣉⣻⣆⣤⠀⠀⠀⠀⢀⣠⡀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣽⡟⡯⡿⣿⣿⣧⣄⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⡋⠀⣀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⣾⡉⠀⣴⣦⣰⣾⣿⣿⣿⣿⣿⣷⣶⣴⣆⣀⣉⣧⣭⣀⣀⡀⠀⠀⠀⣠⠀⠀⠀⠀
⠀⢀⣤⣿⣿⣿⣿⣤⣄⣼⣧⣧⣼⣿⣿⣃⣿⣧⣜⡿⣿⢿⣟⡀⠀⣻⣿⣿⣿⣿⠿⠟⠀⠀⠛⠀⠀⠀⠀⢠⣧⣿⣿⣧⣄⢠⢀⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣄⡀⠀⠀
⠀⢺⣲⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠅⡷⢿⣿⠋⠀⢹⣿⡿⠉⠁⠀⠸⠿⠃⠀⠀⠀⢀⣠⣿⡿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⠙⠏⠀
⠀⠻⣿⡟⠟⠛⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⠀⠀⢸⣿⣷⣤⡀⠀⠀⠙⠁⠀⠀⠀⠀⠀⠀⢠⣴⠂⠹⣿⣿⠇⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠛⠛⢨⣿⡉⠃⠀⠀⠀⠀
⠰⠛⠁⠁⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⣾⣿⣿⣿⣷⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⡶⣿⣧⣠⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣄⠀⠘⠿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠹⠷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢩⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡿⠉⢾⢳⡿⣿⣻⣶⣦⣽⣿⡦⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡿⣟⠋⠀⢻⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣨⣿⣶⣿⣿⣀⢀⣈⡉⠙⣻⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡅⠹⢳⡶⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⠟⠛⠉⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⣿⣿⣀⣴⡄⠛⣶⣠⡄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡹⣿⣿⣿⣿⠃⠀⠙⣻⣿⣿⡟⠋⢿⣿⣿⣿⠟⠉⢘⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠻⣷⠀⢀⣠⣀⢁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣋⣍⠀⠀⠀⠀⠘⣿⡃⠀⠀⠈⢻⡿⣿⠆⠀⣸⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⣾⣿⣿⣿⣷⣤⡄⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⠿⠟⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠈⠟⠀⠀⠠⢌⣷⡍⠀⣰⡧⢙⢃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢴⣿⣿⣿⣿⣿⣿⣿⣦⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣤⠿⢿⢿⡝⠼⠆⣴⣤⣀⢀⣤⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠓⠃⠨⠾⠀⣀⣀⠻⡟⠿⠉⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⡿⢠⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣷⣿⣿⣼⣷⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⡿⠀⢺⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣾⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠛⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⠿⣿⣿⣿⣿⣿⠄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠀⠀⠈⢹⣿⣿⠃⠀⠀⠀⠀⢸⡄
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⠄⠀⠀⠀⣀⣴⠿⠉
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢧⠄⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");


             Console.WriteLine("Welcome to Ecotropolis – the city-building adventure where your decisions shape the future!\n\n" +
                        "As a visionary leader, you'll travel to different cities, taking on roles like mayor, corporate CEO, or urban planner.\n" +
                        "Each city faces unique environmental and urban challenges that only you can solve.\n" +
                        "Complete quests to earn rewards that you can use to design and build your own perfect, sustainable city.\n" +
                        "Can you balance progress with preservation and create a thriving, green metropolis?\n" +
                        "The fate of Ecotropolis is in your hands!\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            Console.WriteLine("\n----------\n");
                
            Console.WriteLine("Please name your city and press enter:");
            Console.Write("> ");
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

        // Display the travel menu
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


        // Travel to a specific location
        public void Travel(Location location)
        {
            Console.WriteLine($"Traveling to {location.Name}...");
            location.DisplayStartMessage();
            location.PlayLocation(player);
        }
    }
}
