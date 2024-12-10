using System.Text.Json.Serialization;

namespace Ecotropolis;
public class Location
{
    public string Name { get; private set; }
    public string WelcomeMessage { get; set; }
    [JsonPropertyName("urbanChallenges")]
    public List<UrbanChallenge> UrbanChallenges { get; private set; }

    [JsonPropertyName("rewardItems")]
    public List<Item> RewardItems { get; private set; }

    
    //Default deserialization constructor
    public Location() { }
    
    [JsonConstructor]
    public Location(string name, List<Item> rewardItems, List<UrbanChallenge> urbanChallenges)
    {
        Name = name;
        RewardItems = rewardItems;
        UrbanChallenges = urbanChallenges;
        WelcomeMessage = $"Welcome to {Name}.";
    }
    

    public Location(string name) {
        Name = name;
        WelcomeMessage = $"Welcome to {Name}."; // TODO move this.....................
        UrbanChallenges = new List<UrbanChallenge>();
        RewardItems = new List<Item>();
    }

    public void AddUrbanChallenge(UrbanChallenge challenge)
    {  
        UrbanChallenges.Add(challenge);  // Add the challenge to the list
    }

    public void AddRewardItem(Item item) {
        RewardItems.Add(item);
    }

    public void DisplayStartMessage() { // TODO move this.....................
        Console.WriteLine($"You have arrived at {Name}.");
        Console.WriteLine(WelcomeMessage);
    }

    public void PlayLocation(Player player) {
        foreach (var challenge in UrbanChallenges)
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
        if (totalScore >= 20) {
            return RewardItems[0]; // Good item
        }
        else if (totalScore >= 10) {
            return RewardItems[1]; // Medium item
        }
        else {
            return RewardItems[2]; // Basic item
        }
    }
}