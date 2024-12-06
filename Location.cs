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
        Item reward = RewardItem(player.score);
        player.Inventory.AddToInventory(reward);
        Console.WriteLine($"You earned: {reward.Name}!");
        // Go back to travel menu
    }

    public Item RewardItem(int totalScore) {
        if (totalScore >= 20) return rewardItems[0]; // Assuming the first item is the best
        if (totalScore >= 10) return rewardItems.Count > 1 ? rewardItems[1] : rewardItems[0]; // Second best or fallback to first
        return rewardItems.Count > 2 ? rewardItems[2] : rewardItems[0]; // Third best or fallback to first
    }
}