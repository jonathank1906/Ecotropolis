namespace Ecotropolis;
using static Ecotropolis.Messager;

/*
 * ========================================================================================================
 * internal class Game:
 * The Game class is responsible for managing the game loop and the player's progress throughout the game.
 * It is "internal", because we only have one assembly and therefore there is no difference
 * between "internal" and "public" in our use case.
 *
 * This class provides the core logic of the game, including the game loop, travel menu, and game end sequence.
 * ========================================================================================================
 */

internal class Game {
    /*
     * ===============================================================================================
     * Fields: private readonly Player _player: holds the player object
     *     private readonly List<Location> _locations: holds the list of locations in the game.
     * ===============================================================================================
     */
    private readonly Player _player;
    private readonly List<Location> _locations;
    
    /*
     * ===============================================================================================
     * Constructor: internal Game():
     * Initializes the player and loads the locations from JSON files.
     * Starts the game loop.
     * ===============================================================================================
     */
    
    internal Game() {
        _player = new Player();
        _locations = LocationLoader.LoadLocationsFromFolder("jsons"); // Load locations from JSON files
        GamePlay();
    }
    
    /*
     * ===============================================================================================
     * Methods: private void GamePlay(): main game loop that handles player input and location progression
     *          private void TravelMenuContent(): displays the travel menu to the player
     *          private void GameEnd(): handles the end of the game, including feedback and final score
     * ===============================================================================================
     */
    
    /*
     * GamePlay():
     * The main game loop that handles player input and location progression.
     * Displays the travel menu to the player and processes their choices.
     * If all locations are visited, triggers the pawn shop sequence.
     * After the pawn shop sequence, ends the game and displays the final score.
     */
    private void GamePlay() {
        PrintMessage("welcome");
        while (true) {
            if (_locations.Count == 0) { 
                PrintMessage("all_locations_visited");
                break;
            }
            string? input = InteractiveMessage("travel_menu", TravelMenuContent()); // Display the travel menu to the player

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Parse input and adjust for zero-based index
                    switch (choice) {
                        case >= 0 when choice < _locations.Count: {
                            // Valid location
                            Location selectedLocation = _locations[choice];
                            selectedLocation.PlayLocation(_player); // Play the challenges at the location
                            _locations.RemoveAt(choice);
                            break;
                        }
                        case -1: // Exit the game
                            PrintMessage("exit_game");
                            return;
                        default: {
                            if (choice == _locations.Count) { // Display help menu
                                PrintMessage("help");
                                Console.ReadLine();
                            }
                            else { // Invalid choice
                                PrintMessage("invalid_option");
                            }
                            break;
                        }
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
        PawnShop pawnShop = new(_player);
        pawnShop.Open();
        GameEnd();
    }
    
    /*
     * TravelMenuContent():
     * Logic for displaying the travel menu to the player.
     */
    private string TravelMenuContent() {
        string variable = string.Empty; 
        for (int i = 0; i < _locations.Count; i++) { // Display the available locations
            variable += $"{i + 1}. {_locations[i].Name}\n";
        }
        variable += $"{_locations.Count + 1}. Help"; // Display the help option
        return variable; 
    }
    
    
    /*
     * GameEnd():
     * Handles the end of the game, including feedback and final score.
     */
    private void GameEnd() {
        string stringVariable = (_player.SustainabilityScore).ToString();
        stringVariable += "\n";

        switch (_player.SustainabilityScore) {
            case >= 85:
                stringVariable += "Congratulations! You have achieved a high sustainability score.";
                break;
            case >= 50:
                stringVariable += "You have achieved a moderate sustainability score.";
                break;
            default:
                stringVariable +=
                    "Your sustainability score is low. Consider playing again and revist the locations to improve it.";
                break;
        }

        PrintMessage("game_end", stringVariable);

        stringVariable = _player.GenerateEndGameFeedback();
        PrintMessage("feedback", stringVariable);

        PrintMessage("exit_game");
    }
}
