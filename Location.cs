using System.Text.Json.Serialization;

namespace Ecotropolis;
public class Location
{
    public string Name { get; set; }
    public string WelcomeMessage { get; set; }
    [JsonPropertyName("urbanChallenges")]
    public List<UrbanChallenge> UrbanChallenges { get; set; }

    [JsonPropertyName("rewardItems")]
    public List<Item> RewardItems { get; set; }

    
    //Default deserialization constructor
    public Location() { }
    [JsonConstructor]
    public Location(string name) {
        Name = name;
        WelcomeMessage = $"Welcome to {Name}."; 
        UrbanChallenges = new List<UrbanChallenge>();
        RewardItems = new List<Item>();
    }

    public void DisplayStartMessage() { 
        Console.WriteLine(WelcomeMessage);
    }

    public void PlayLocation(Player player) {
        foreach (var challenge in UrbanChallenges)
        {
            challenge.Execute(player);
        }
        // Challenges completed, reward the player with an item
        Item reward = RewardItem(player.Score);
        Console.WriteLine($"\nYou earned: {reward.Name}!");
        player.Inventory.AddToInventory(reward);
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