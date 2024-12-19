namespace Ecotropolis;

public class Inventory {
    private List<Item> inventory;
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
}