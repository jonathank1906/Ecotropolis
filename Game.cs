namespace Ecotropolis;
using static Ecotropolis.Messager;

public class Game
{
    private Player player;
    private List<Location> locations;
    private PawnShop pawnShop;

    public Game() 
    {
        player = new Player();
        pawnShop = new PawnShop(player);
        locations = LocationLoader.LoadLocationsFromFolder("jsons"); // Load locations from JSON files
        StartMenu startMenu = new StartMenu();
        GamePlay();
    }
    public void GamePlay() {
        bool enterPawnShopSequence = false;
        while (true) {
            if (locations.Count == 0) { 
                PrintMessage("all_locations_visited");
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
                        selectedLocation.PlayLocation(player); // Play the challenges at the location
                        locations.RemoveAt(choice);
                    }
                    else if (choice == -1) { // Exit the game
                        PrintMessage("exit_game");
                        return;
                    }
                    else if (choice == locations.Count) { // Display help menu
                        PrintMessage("help");
                    }
                    else { // Invalid choice
                        PrintMessage("invalid_option");
                    }
                }
                catch (FormatException) { // Handle invalid numeric input
                    PrintMessage("invalid_command");
                }
            } 
            else { // Null or empty input
               PrintMessage("empty_input");
            }
        }
        if (enterPawnShopSequence) {
            pawnShop.Open();
        }
        GameEnd();
    }
    public void DisplayTravelMenu() { // Display the travel menu
        string variable = "0. Exit Game\n";
        for (int i = 0; i < locations.Count; i++) { // Display the available locations
            variable += $"{i + 1}. {locations[i].Name}\n";
        }
        variable += $"{locations.Count + 1}. Help"; // Display the help option
        PrintMessage("travel_menu", variable);
    }

    public void GameEnd()
    {
        string stringVariable = (player.SustainabilityScore / 100).ToString();
        stringVariable += "\n";

        if (player.SustainabilityScore >= 85)
        {
            stringVariable += "Congratulations! You have achieved a high sustainability score.";
        }
        else if (player.SustainabilityScore >= 50)
        {
            stringVariable += "You have achieved a moderate sustainability score.";
        }
        else
        {
            stringVariable +=
                "Your sustainability score is low. Consider playing again and revist the locations to improve it.";
        }

        PrintMessage("game_end", stringVariable);

        stringVariable = player.Inventory.GenerateEndGameFeedback();
        PrintMessage("feedback", stringVariable);

        PrintMessage("exit_game");
    }
}