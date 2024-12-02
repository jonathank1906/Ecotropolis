namespace Ecotropolis;
public class UrbanChallenge
{
    public string ChallengeDescription { get; private set; }
    private List<ChallengeOption> options;

    public UrbanChallenge(string description)
    {
        ChallengeDescription = description;
        options = new List<ChallengeOption>();
    }

    public void Execute(Player player)
    {
        Console.WriteLine($"Challenge: {ChallengeDescription}");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i].Description}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < options.Count)
        {
            player.IncreaseScore(options[choice].ScoreImpact);
        }
        else
        {
            Console.WriteLine("Invalid choice. No impact.");
        }
    }
    public void AddOption(ChallengeOption option)
    {
        options.Add(option);  // Add the option to the list
    }
}

