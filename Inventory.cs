namespace Ecotropolis;

public class Inventory {
    public List<Item> inventory;
    public Inventory() {
        inventory = new();
    }
    public void AddToInventory(Item item) {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
        Console.WriteLine(item.Description);
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
            Console.WriteLine($"\nItem: {item.Name}");
            Console.WriteLine($"Description: {item.Description}");
            Console.WriteLine($"Feedback: {item.EndGameFeedback}");
        }
    }
}