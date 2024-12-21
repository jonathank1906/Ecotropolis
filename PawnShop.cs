namespace Ecotropolis;
using static Ecotropolis.Messager;

public class PawnShop
{
    private Player player;
    private List<Item> uniqueItems;
    public PawnShop(Player player) {
        this.player = player;
        uniqueItems = new List<Item> {
            new Item("Recyclatron Core", 2, "A compact device that turns waste into valuable resources, improving urban cleanliness.", "You unlocked the Recyclatron Core!"),
            new Item("Skyline Blueprint", 3, "A magical design that transforms cities into smart, sustainable havens.", "You unlocked the Skyline Blueprint!"), 
            new Item("Transit Key", 4, "A master key to unlock advanced, eco-friendly public transport systems.", "You unlocked the Transit System!"),
        };
    }
    public void Open() {
       // DisplayMessage("pawn shop"); // this is the heading only
        while (true) {
            Console.WriteLine("Available unique items:");
            for (int i = 0; i < uniqueItems.Count; i++) {
                Console.WriteLine($"{i + 1}. {uniqueItems[i].Name} (Cost: {uniqueItems[i].Value} tokens)");
            }
            Console.WriteLine($"You have {player.Tokens} tokens.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("0. Exit the shop\n1. Buy an item\n2. View inventory"); 
            Console.Write("> ");
            switch (Console.ReadLine()) {
                case "0":
                    return;
                case "1":
                    Console.WriteLine("Which item would you like to buy?");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= uniqueItems.Count) {
                        Console.WriteLine($"You selected {uniqueItems[choice - 1].Name}.");
                        Item selectedItem = uniqueItems[choice - 1];
                        BuyItem(selectedItem);
                    }
                    break;
                case "2":
                    Console.WriteLine("Your inventory:");
                    player.Inventory.Show();
                    continue;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }
    public void BuyItem(Item item) {
        if (player.Tokens >= item.Value) {
            player.Tokens -= item.Value;
            player.Inventory.AddToInventory(item);
            uniqueItems.Remove(item);
        }
        else {
            Console.WriteLine("You don't have enough tokens to buy this item.");
        }
    }
}