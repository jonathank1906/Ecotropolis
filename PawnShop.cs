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
        while (true) {
            string stringVariable = "\n";
            
            for (int i = 0; i < uniqueItems.Count; i++) {
                stringVariable += $"{i + 1}. {uniqueItems[i].Name} (Cost: {uniqueItems[i].Value} tokens) \n";
            }
            stringVariable += $"\n You have {player.Tokens} tokens.";
            PrintMessage("pawn_shop", stringVariable);
            PrintMessage("pawn_shop_menu");
            
            switch (Console.ReadLine()) {
                case "0":
                    return;
                case "1":
                    PrintMessage("generic", "Which item would you like to buy?");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= uniqueItems.Count) {
                        PrintMessage("generic",$"You selected {uniqueItems[choice - 1].Name}.");
                        Item selectedItem = uniqueItems[choice - 1];
                        BuyItem(selectedItem);
                    }
                    break;
                case "2":
                    player.Inventory.Show();
                    continue;
                default:
                    PrintMessage("invalid_option");
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
            PrintMessage("generic","You don't have enough tokens to buy this item.");
        }
    }
}