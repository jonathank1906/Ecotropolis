namespace Ecotropolis;
using static EcoTropolis.Messages;
using System.Text.Json;
using System.Threading.Channels;

public class Game
{
    private Player player;
    private List<Location> locations;
    private PawnShop pawnShop;

    public Game() 
    {
        Console.WriteLine("Game constructor started.");

        player = new Player();
        pawnShop = new PawnShop(player);

        // Check if the path to the JSON is correct and if it's being invoked.
        Console.WriteLine("Attempting to load locations from folder...");

        // Correct the assignment to the class-level 'locations' field
        locations = LocationLoader.LoadLocationsFromFolder("jsons");

        foreach (var location in locations)
        {
            Console.WriteLine($"Loaded location: {location.Name}"); // Assuming `Name` is a property in `Location`
        }

        // Start game
        StartMenu startMenu = new StartMenu();
        GamePlay();
    }
   
   
    public void GamePlay() {
        bool enterPawnShopSequence = false;
        while (true) {
            if (locations.Count == 0) { 
                DisplayMessage("All Locations Visited");
                enterPawnShopSequence = true;
                break;
            }
            DisplayTravelMenu(); // Display the travel menu to the player
            string? input = Console.ReadLine(); // Get the player's choice from the menu

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Parse input and adjust for zero-based index
                    if (choice >= 0 && choice < locations.Count) { // Valid location
                        Location selectedLocation = locations[choice];
                        selectedLocation.DisplayStartMessage();
                        selectedLocation.PlayLocation(player); // Play the challenges at the location
                        locations.RemoveAt(choice);
                        Console.WriteLine("Press any key to return to the travel menu...");
                        Console.ReadKey(true);
                    }
                    else if (choice == -1) { // Exit the game
                        DisplayMessage("Exit Game");
                        break;
                    }
                    else if (choice == locations.Count) { // Display help menu
                        DisplayMessage("help");
                    }
                    else { // Invalid choice
                        DisplayMessage("invalid option");
                    }
                }
                catch (FormatException) { // Handle invalid numeric input
                    DisplayMessage("invalid command");
                }
           }
           else { // Null or empty input
               DisplayMessage("empty input");
           }
        }
        if (enterPawnShopSequence) {
            pawnShop.Open();
        }
        EndGame();
    }

    public void DisplayTravelMenu() {  // Display the travel menu
        Console.WriteLine("0. Exit Game"); // Exit the game
        for (int i = 0; i < locations.Count; i++) { // Display the available locations
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }
        Console.WriteLine($"{locations.Count + 1}. Help"); // Display the help option
        Console.Write("> ");
    }

    public void EndGame() {
        DisplayMessage("game_end");
        EvaluatePerformance();
        Console.WriteLine("Thank you for playing Ecotropolis!");
    }
    public void EvaluatePerformance()
    {
        Console.WriteLine($@"You have completed your journey with a sustainability score of... 
+------------------+
      {player.SustainabilityScore}/1000     
+------------------+");
        if (player.SustainabilityScore >= 200)
        {
            Console.WriteLine("Congratulations! You have achieved a high sustainability score.");
        }
        else if (player.SustainabilityScore >= 100)
        {
            Console.WriteLine("You have achieved a moderate sustainability score.");
        }
        else
        {
            Console.WriteLine("Your sustainability score is low. Consider playing again and revist the locations to improve it.");
        }
        // Your items will be used to build a sustainable city of your own.
    }


    public static class LocationLoader
    {
        public static List<Location> LoadLocationsFromFolder(string folderPath)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var locations = new List<Location>();

            try
            {
                // Get all JSON files in the folder
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

                foreach (string filePath in jsonFiles)
                {
                    string json = File.ReadAllText(filePath);
                    Console.WriteLine($"Reading file: {filePath}");
                    
                    Location? location = JsonSerializer.Deserialize<Location>(json, options);

                    if (location != null)
                    {
                        locations.Add(location);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Failed to deserialize {filePath}. Skipping.");
                    }
                }

                Console.WriteLine($"Successfully loaded {locations.Count} location(s).");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: Folder not found - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return locations;
        }
    }
}