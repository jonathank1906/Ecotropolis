using System.Text.Json.Serialization;

namespace Ecotropolis;
public class Location
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("WelcomeMessage")]
    public string WelcomeMessage { get; set; }
    [JsonPropertyName("urbanChallenges")]
    public List<UrbanChallenge> UrbanChallenges { get; set; }

    [JsonPropertyName("rewardItems")]
    public List<Item> RewardItems { get; set; }

    [JsonConstructor]
    public Location() {
        Name = string.Empty;
        WelcomeMessage = string.Empty; 
        UrbanChallenges = new List<UrbanChallenge>();
        RewardItems = new List<Item>();
    }
    public void PlayLocation(Player player) {
        Console.WriteLine(WelcomeMessage);
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