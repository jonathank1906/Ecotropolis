namespace Ecotropolis;
public class UrbanChallenge {
    public string ChallengeDescription { get; private set; }
    private List<ChallengeOption> options;

    public UrbanChallenge(string description)
    {
        ChallengeDescription = description;
        options = new List<ChallengeOption>();
    }

    public void Execute(Player player) {
        Console.WriteLine($"Challenge: {ChallengeDescription}");
        // Display available options
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i].Description}");
        }

        
        while (true) { // Loop until the user selects a valid option 
            Console.WriteLine("Please select an option (1 to {0}):", options.Count);
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Adjust choice for zero-indexed list

                    if (choice >= 0 && choice < options.Count) {
                        player.IncreaseScore(options[choice].ScoreImpact);
                        break;
                    }
                    else {
                        Console.WriteLine("Invalid option number. Please try again.");
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
            }    
        }
    }

    public void AddOption(ChallengeOption option) {
        options.Add(option);  // Add the option to the list
    }
}