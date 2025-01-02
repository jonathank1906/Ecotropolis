namespace Ecotropolis;
using System.Text.Json.Serialization;

/*
 * ========================================================================================================
 * public class Item:
 *
 * This class represents an item in the game. It contains a name, a value, a description, and end game feedback.
 * ========================================================================================================
 */

public class Item {
    /*
     * ===============================================================================================
     * Fields: string Name: holds the name of the item
     * int Value: holds the value of the item 
     * string Description: holds the item description. 
     * string EndGameFeedback: holds the end game feedback text that will be displayed at the end of the game. 
     */
    public string Name { get; private set; }
    public int Value { get; private set; }
    public string Description { get; private set; }
    public string EndGameFeedback {get; private set;}

    
    public Item(string name, int value, string description) { // Constructor for the unique items
        Name = name;
        Value = value;
        Description = description;
        EndGameFeedback = string.Empty;
    }

    [JsonConstructor]
    internal Item(string name, int value, string description, string endGameFeedback) { // Constructor for the location items
        Name = name;
        Value = value;
        Description = description;
        EndGameFeedback = endGameFeedback;
    }
}
