namespace Ecotropolis;
using System.Text.Json.Serialization;

public class Item
{
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
    public Item(string name, int value, string description, string endGameFeedback) { // Constructor for the other items
        Name = name;
        Value = value;
        Description = description;
        EndGameFeedback = endGameFeedback;
    }
}