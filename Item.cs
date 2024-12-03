namespace Ecotropolis;
public class Item
{
    public string Name { get; private set; }
    public int Value { get; private set; }
    public string ItemDetails { get; private set; }

    public Item(string name, int value, string details)
    {
        Name = name;
        Value = value;
        ItemDetails = details;
    }

    public void Use()
    {
        Console.WriteLine($"{Name} used. {ItemDetails}");
    }
}