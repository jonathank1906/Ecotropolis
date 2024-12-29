namespace Ecotropolis;
using System.Text.Json.Serialization;
using static Ecotropolis.Messager;

/*
 * ========================================================================================================
 * internal class Location:
 *
 * This class represents a location in the game. It contains a name, a welcome message, a list of urban challenges,
 * and a list of reward items. The class also has a method to play the location, which executes the urban challenges
 * and rewards the player with an item based on their sustainability score.
 * ========================================================================================================
 */

public class Location {
    /*
     * ========================================================================================================
     * Fields: internal string Name: holds the name of the location
     *      internal string WelcomeMessage: holds the welcome message for the location
     *    internal List<UrbanChallenge> UrbanChallenges: holds the list of urban challenges at the location
     *  private List<Item> RewardItems: holds the list of reward items for the location
     * ========================================================================================================
     */
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("WelcomeMessage")]
    public string WelcomeMessage { get; set; }
    
    [JsonPropertyName("urbanChallenges")]
    public List<UrbanChallenge> UrbanChallenges { get; set; }

    [JsonPropertyName("rewardItems")]
    public List<Item> RewardItems { get; set; }

    
    /*
     * ========================================================================================================
     * Constructor: internal Location():
     * Initializes the location with default values.
     * ========================================================================================================
     */
    [JsonConstructor]
    internal Location() {
        Name = string.Empty;
        WelcomeMessage = string.Empty; 
        UrbanChallenges = new List<UrbanChallenge>();
        RewardItems = new List<Item>();
    }
    
    /*
     * ========================================================================================================
     * Methods: internal void PlayLocation(Player player): Plays the location by executing the urban challenges and
     *  rewarding the player with an item based on their score.
     *      private Item RewardItem(int totalScore): determines the reward item based on the player's score
     * ========================================================================================================
     */
    internal void PlayLocation(Player player) {
        string textVariable = WordWrap(WelcomeMessage, 100, "");
        PrintMessage("generic", textVariable); 

        foreach (var challenge in UrbanChallenges)
        {
            challenge.Execute(player);
        }
        // Challenges completed, reward the player with an item
        Item reward = RewardItem(player.SustainabilityScore);
        textVariable = $"{reward.Name}\n{reward.Description}"; 
        
        PrintMessage("reward_earned", textVariable);
        player.AddToInventory(reward);
        // Go back to travel menu
    }
    
    
    private Item RewardItem(int totalScore) {
        switch (totalScore) {
            case >= 20:
                return RewardItems[0]; // Good item
            case >= 10:
                return RewardItems[1]; // Medium item
            default:
                return RewardItems[2]; // Basic item
        }
    }
}