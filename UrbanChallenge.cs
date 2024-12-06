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

        bool validChoice = false;
        int choice = -1;

        while (!validChoice) { // Loop until the user selects a valid option 
            Console.WriteLine("Please select an option (1 to {0}):", options.Count);
            Console.Write("> ");
            
            string? input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= options.Count) { // Read input and check if it's a valid choice
                validChoice = true;
                choice--; // Adjust choice for zero-indexed list
                player.IncreaseScore(options[choice].ScoreImpact);
            }
            else {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    public void AddOption(ChallengeOption option) {
        options.Add(option);  // Add the option to the list
    }
}