using System.Text.Json.Serialization;

namespace Ecotropolis;

public class Item
{
    public string Name { get; private set; }
    public int Value { get; private set; }
    public string Description { get; private set; }
    
    
    [JsonConstructor]
    public Item(string name, int value, string description)
    {
        Name = name;
        Value = value;
        Description = description;
    }
}
