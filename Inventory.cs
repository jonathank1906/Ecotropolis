namespace Ecotropolis;

public class Inventory {
    private List<Item> inventory;
    private Player player;
    public Inventory(Player player) {
        inventory = new List<Item>();
        this.player = player;
    }
    public int Count => inventory.Count;
    public Item this[int index] => inventory[index];
    public void AddToInventory(Item item) {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void SellItem(Item item) {
        if (inventory.Remove(item)) {
            Console.WriteLine($"{item.Name} sold for {item.Value} points.");
        }
        else {
            Console.WriteLine("Item not found in inventory.");
        }
    }

    public void Show() {
        int i = 1;
        foreach (var item in inventory) {
            Console.WriteLine(i + ". " + item.Name + " " + item.Value);
            i++;
        }
    }
}
