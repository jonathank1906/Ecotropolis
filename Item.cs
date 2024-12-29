namespace Ecotropolis;
using System.Text.Json.Serialization;

/*
 * ========================================================================================================
 * internal class Item:
 *
 * This class represents an item in the game. It contains a name, a value, a description, and end game feedback.
 * ========================================================================================================
 */

internal class Item {
    /*
     * ===============================================================================================
     * Fields: internal string Name: holds the name of the item
     *     internal int Value: holds the value of the item TODO: What is the value of an item?
     * internal string Description: holds the item description. 
     * internal string EndGameFeedback: holds the end game feedback text that will be displayed at the end of the game. 
     * 
     */
    internal string Name { get; private set; }
    internal int Value { get; private set; }
    internal string Description { get; private set; }
    internal string EndGameFeedback {get; private set;}

    
    internal Item(string name, int value, string description) { // Constructor for the unique items
        Name = name;
        Value = value;
        Description = description;
        EndGameFeedback = string.Empty;
    }

    [JsonConstructor]
    internal Item(string name, int value, string description, string endGameFeedback) { // Constructor for the other items
        Name = name;
        Value = value;
        Description = description;
        EndGameFeedback = endGameFeedback;
    }
}