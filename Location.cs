namespace Ecotropolis;
public class Location
{
    public string Name { get; private set; }
    public string WelcomeMessage { get; set; }
    private List<UrbanChallenge> urbanChallenges;
    private List<Item> rewardItems;
    public Location(string name) {
        Name = name;
        WelcomeMessage = $"Welcome to {Name}."; // TODO move this.....................
        urbanChallenges = new List<UrbanChallenge>();
        rewardItems = new List<Item>();
    }

    public void AddUrbanChallenge(UrbanChallenge challenge)
    {  
        urbanChallenges.Add(challenge);  // Add the challenge to the list
    }

    public void AddRewardItem(Item item) {
        rewardItems.Add(item);
    }

    public void DisplayStartMessage() { // TODO move this.....................
        Console.WriteLine($"You have arrived at {Name}.");
        Console.WriteLine(WelcomeMessage);
    }

    public void PlayLocation(Player player) {
        foreach (var challenge in urbanChallenges)
        {
            challenge.Execute(player);
        }
        // Challenges completed, reward the player with an item
        Item reward = RewardItem(player.Score);
        player.Inventory.AddToInventory(reward);
        Console.WriteLine($"You earned: {reward.Name}!");
        player.Score = 0; // Reset the score
        // Go back to travel menu
    }

    public Item RewardItem(int totalScore) {
        if (totalScore >= 20) {
            return rewardItems[0]; // Good item
        }
        else if (totalScore >= 10) {
            return rewardItems[1]; // Medium item
        }
        else {
            return rewardItems[2]; // Basic item
        }
    }
}