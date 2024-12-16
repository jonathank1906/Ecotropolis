namespace Ecotropolis;

public class Inventory {
    private List<Item> inventory;
   
    public Inventory() {
        inventory = new();
    }

    // Method to get the count of items
    public int GetInventoryCount() {
        return inventory.Count;
    }

    // Method to get an item at a specific index
    public Item GetItemAtIndex(int index) {
        if (index >= 0 && index < inventory.Count) {
            return inventory[index];  // Return the item if the index is valid
        }
        return null;  // Return null if the index is invalid
    }

    public void AddToInventory(Item item) {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void Show() {
        int i = 1;
        foreach (var item in inventory) {
            Console.WriteLine(i + ". " + item.Name + " " + item.Value);
            i++;
        }
    }
}
