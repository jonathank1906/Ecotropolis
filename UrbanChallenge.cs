namespace Ecotropolis;
using System.Text.Json.Serialization;
using static EcoTropolis.Messages;
public class UrbanChallenge {
     [JsonPropertyName("description")]
    public string Description { get; private set; }

    [JsonPropertyName("options")]
    public List<ChallengeOption> Options { get; private set; }

    [JsonConstructor]
    public UrbanChallenge(string description, List<ChallengeOption> options)
    {
        Description = description;
        Options = options;
    }

    public void Execute(Player player) {
        Console.WriteLine($"\nChallenge: {Description}"); // Display the challenge description
        // Shuffle the options list randomly
        var random = new Random();
        var shuffledOptions = Options.OrderBy(x => random.Next()).ToList();

        // Display the shuffled options
        for (int i = 0; i < shuffledOptions.Count; i++) {
            Console.WriteLine(WordWrap($"{i + 1}. {shuffledOptions[i].Description}", 60, "   "));
        }
        while (true) { // Loop until the user selects a valid option 
            Console.WriteLine("Please select an option (1 to {0}):", shuffledOptions.Count);
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input)) 
            { 
                try 
                {
                    int choice = int.Parse(input) - 1; // Adjust choice for zero-indexed list
                    if (choice >= 0 && choice < shuffledOptions.Count) 
                    { 
                        player.IncreaseScore(shuffledOptions[choice].ScoreImpact); 
                        if (shuffledOptions[choice].ScoreImpact > 10) {
                            player.AddToken();
                        }
                        break; 
                    }
                    else { 
                        DisplayMessage("invalid option"); 
                    }
                } 
                catch (FormatException) { 
                    DisplayMessage("invalid command"); 
                }
            }  
            else { 
                DisplayMessage("empty input"); 
            }  
        }
    }
}