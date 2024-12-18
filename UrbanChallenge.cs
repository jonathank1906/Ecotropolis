using System.Text.Json.Serialization;
using EcoTropolis;

namespace Ecotropolis;
using static EcoTropolis.Messages;
public class UrbanChallenge {
    public string Name { get; private set; }

    [JsonPropertyName("options")]
    public List<ChallengeOption> Options { get; private set; }

    [JsonConstructor]
    public UrbanChallenge(string name, List<ChallengeOption> options)
    {
        Name = name;
        Options = options;
    }

    public void Execute(Player player) {
        Console.WriteLine($"\nChallenge: {Name}"); // Display the challenge description
        for (int i = 0; i < Options.Count; i++) // Display available options
        {
            Console.WriteLine(WordWrap($"{i + 1}. {Options[i].Description}",60,"   "));
        }

        while (true) { // Loop until the user selects a valid option 
            Console.WriteLine("Please select an option (1 to {0}):", Options.Count);
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Adjust choice for zero-indexed list
                    if (choice >= 0 && choice < Options.Count) { // Check if choice is within valid range
                        player.IncreaseScore(Options[choice].ScoreImpact);
                        break;
                    }
                    else { // Invalid option number
                        DisplayMessage("invalid option");
                    }
                }
                catch (FormatException) { // Invalid input format
                    DisplayMessage("invalid command");
                }
            }  
            else { // Empty input
                DisplayMessage("empty input");
            }  
        }
    }
}