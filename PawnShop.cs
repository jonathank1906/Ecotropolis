namespace Ecotropolis;
using static Ecotropolis.Messager;
/*
 * ========================================================================================================
 * internal class PawnShop:
 *
 * This class represents the pawn shop where the player can buy unique items using tokens.
 * It is the end game location, that is triggered when the player has visited all locations.
 * Visiting the PawnShop allows the player to spend their tokens on unique items that can help improve their ending.
 * ========================================================================================================
 */

internal class PawnShop { 
    /*
    * ========================================================================================================
    * Fields: private Player player: holds the player object
    *         private List<Item> uniqueItems: holds the list of unique items available in the pawn shop.
    * ========================================================================================================
    */
    private Player player;
    private List<Item> uniqueItems;
    
    /*
     * ========================================================================================================
     * Constructor: internal PawnShop(Player player):
     * Initializes the player and the list of unique items available in the pawn shop.
     * ========================================================================================================
     */
    internal PawnShop(Player player) {
        this.player = player;
        uniqueItems = new List<Item> {
            new Item("Recyclatron Core", 2, "A compact device that turns waste into valuable resources, improving urban cleanliness.", "You unlocked the Recyclatron Core!"),
            new Item("Skyline Blueprint", 3, "A magical design that transforms cities into smart, sustainable havens.", "You unlocked the Skyline Blueprint!"), 
            new Item("Transit Key", 4, "A master key to unlock advanced, eco-friendly public transport systems.", "You unlocked the Transit System!"),
        };
    }
    
    /*
     * ========================================================================================================
     * Methods: internal void Open(): opens the pawn shop menu and processes player input
     *          private void BuyItem(Item item): buys the selected item if the player has enough tokens
     * ========================================================================================================
     */
    
    /*
     * Open():
     * Opens the pawn shop menu and processes player input.
     * The player can buy items, view their inventory, or exit the shop.
     * If the player buys an item, it is added to their inventory and removed from the shop.
     * If the player doesn't have enough tokens, a message is displayed.
     * If the player exits the shop, the method returns.
     */
    internal void Open() {
        while (true) {
            string uniqueItemsString = "";
            
            for (int i = 0; i < uniqueItems.Count; i++) {
                uniqueItemsString += $"{i + 1}. {uniqueItems[i].Name} (Cost: {uniqueItems[i].Value} tokens) \n";
            }
            string stringVariable = uniqueItemsString + $"\nYou have {player.Tokens} tokens.";
            string input = InteractiveMessage("pawn_shop", stringVariable);
            
            switch (input) {
                case "0":
                    return;
                case "1":
                    input = InteractiveMessage("buy_items", uniqueItemsString);
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= uniqueItems.Count) {
                        PrintMessage("generic",$"You selected {uniqueItems[choice - 1].Name}.");
                        Item selectedItem = uniqueItems[choice - 1];
                        BuyItem(selectedItem);
                    } 
                    break;
                case "2":
                    player.ShowInventory();
                    break;
                default:
                    PrintMessage("invalid_option");
                    break;
            }
        }
    }
    
    /*
     * BuyItem(Item item):
     * Buys the selected item if the player has enough tokens.
     * If the player has enough tokens, the item is added to their inventory and removed from the shop.
     * If the player doesn't have enough tokens, a message is displayed.
     */
    private void BuyItem(Item item) {
        if (player.Tokens >= item.Value) {
            player.Tokens -= item.Value;
            player.AddToInventory(item);
            uniqueItems.Remove(item);
        }
        else {
            PrintMessage("generic","You don't have enough tokens to buy this item.");
        }
    }
}
