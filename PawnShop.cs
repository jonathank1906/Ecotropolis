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
    private Player _player;

    private Dictionary<int,Item> _uniqueItems = new Dictionary<int,Item> {
        {2, new Item("Recyclatron Core", 20, "A compact device that turns waste into valuable resources, improving urban cleanliness.", "You unlocked the Recyclatron Core!")},
        {3, new Item("Skyline Blueprint", 30, "A magical design that transforms cities into smart, sustainable havens.", "You unlocked the Skyline Blueprint!")}, 
        {4, new Item("Transit Key", 50, "A master key to unlock advanced, eco-friendly public transport systems.", "You unlocked the Transit System!")},
    };
    
    /*
     * ========================================================================================================
     * Constructor: internal PawnShop(Player player):
     * Initializes the player and the list of unique items available in the pawn shop.
     * ========================================================================================================
     */
    internal PawnShop(Player player) {
        this._player = player;
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
            int i = 0;
            foreach (KeyValuePair<int,Item> entry in _uniqueItems) {
                uniqueItemsString += $"{++i}. {entry.Value.Name} (Cost: {entry.Key} tokens) \n";
            }
            string stringVariable = uniqueItemsString + $"\nYou have {_player.Tokens} tokens.";
            string input = InteractiveMessage("pawn_shop", stringVariable);
            
            switch (input) {
                case "0":
                    return;
                case "1":
                    input = InteractiveMessage("buy_items", uniqueItemsString);
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= _uniqueItems.Count) {
                        PrintMessage("generic",$"You selected {_uniqueItems.ElementAt(choice - 1).Value.Name}."); // Access the dictionary by index
                        BuyItem(_uniqueItems.ElementAt(choice - 1));
                    } 
                    break;
                case "2":
                    _player.ShowInventory();
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
    private void BuyItem(KeyValuePair<int,Item> option) {
        Item item = option.Value;
        int costs = option.Key;
        if (_player.Tokens >= costs) {
            _player.Tokens -= costs;
            _player.AddToInventory(item);
            // Add to the sustainability score
            _player.IncreaseScore(item.Value);
            _uniqueItems.Remove(costs);
        }
        else {
            PrintMessage("generic","You don't have enough tokens to buy this item.");
        }
    }
}
