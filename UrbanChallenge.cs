namespace Ecotropolis;
using System.Text.Json.Serialization;
using static Ecotropolis.Messager;

/*
 * ========================================================================================================
 * internal class UrbanChallenge:
 *
 * This class represents an urban challenge in the game. It contains a description and a list of challenge options.
 * The class also has a method to execute the challenge, which displays the description and options to the player
 * and rewards the player based on their choice.
 * ========================================================================================================
 */

internal class UrbanChallenge {
     [JsonPropertyName("description")]
    private string Description { get;}

    [JsonPropertyName("options")]
    private List<ChallengeOption> Options { get; }

    
    /*
     * ========================================================================================================
     * Constructor: internal UrbanChallenge(string description, List<ChallengeOption> options):
     * Initializes the urban challenge with the given description and list of options.
     * It gets the description and options from the JSON file.
     * ========================================================================================================
     */
    [JsonConstructor]
    internal UrbanChallenge(string description, List<ChallengeOption> options) {
        Description = description;
        Options = options;
    }

    /*
     * ========================================================================================================
     * Methods: internal void Execute(Player player): Executes the urban challenge by displaying the description
     * and options to the player and rewarding the player based on their choice.
     * ========================================================================================================
     */
    internal void Execute(Player player) {  
        string stringVariable = WordWrap(Description, 100, "") + "\n"; // Display the challenge description
        for (int i = 0; i < Options.Count; i++) // Display the option descriptions
        {
            stringVariable += (WordWrap($"{i + 1}. {Options[i].Description}",60,"   ") + "\n");
        }

        PrintMessage("challenge", stringVariable);

        while (true) { // Loop until the user selects a valid option 
            PrintMessage(null, $"Please select an option (1 to {Options.Count}):", true);
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Adjust choice for zero-indexed list
                    if (choice >= 0 && choice < Options.Count) { // Check if choice is within valid range
                        player.IncreaseScore(Options[choice].ScoreImpact);
                        break;
                    }
                    else { // Invalid option number
                        PrintMessage("invalid_option");
                    }
                }
                catch (FormatException) { // Invalid input format
                    PrintMessage("invalid_command");
                }
            }  
            else { // Empty input
                PrintMessage("empty_input");
            }  
        }
    }
}