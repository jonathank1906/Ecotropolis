namespace Ecotropolis;
using static Ecotropolis.Messager;

public class Inventory {
    public List<Item> inventory;
    public Inventory() {
        inventory = new();
    }
    public void AddToInventory(Item item) {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
        Console.WriteLine(WordWrap(item.Description, 60, ""));
    }
    public void Show() { 
        int i = 1;
        foreach (var item in inventory) {
            Console.WriteLine(i + ". " + item.Name + " " + item.Value);
            i++;
        }
    }
    public void ShowEndGameFeedback() {
        foreach (var item in inventory) {
            Console.WriteLine($"Item: {item.Name}, Value: {item.Value}");
            Console.WriteLine(WordWrap($"Description: {item.Description}",100,"             "));
            Console.WriteLine(WordWrap($"Feedback: {item.EndGameFeedback}", 100, "          "));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }
    }
}