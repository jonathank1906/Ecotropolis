namespace Ecotropolis;
using static Ecotropolis.Messager;

 


/*
 * ========================================================================================================
 * This class represents the player in the game. It keeps track of the player's inventory, sustainability score, and tokens.
 * The player can increase their score, add tokens, spend tokens, view their inventory, add items to their inventory,
 * and generate end game feedback.
 *
 * Class Constructor is default, therefore not included. We resort to defaulting values of the fields instead. 
 * ========================================================================================================
 */
internal class Player {
    /*
     * ===============================================================================================
     * Fields: private readonly Inventory _inventory: holds the player's inventory
     *      internal int SustainabilityScore: holds the player's sustainability score
     *     internal int Tokens: holds the player's tokens
     *
     * All the fields are initialized with default values. No constructor is defined.
     * ===============================================================================================
     */
    private readonly Inventory _inventory = new Inventory();
    internal int SustainabilityScore { get; set; } = 0;
    internal int Tokens { get; set; } = 0;

    /*
     * ===============================================================================================
     * Methods: internal void IncreaseScore(int amount): increases the player's sustainability score by the given amount
     *         internal void AddToken(): adds a token to the player's tokens
     *        internal bool SpendTokens(int amount): spends the given amount of tokens if the player has enough
     *       internal void ShowInventory(): displays the player's inventory
     *     internal void AddToInventory(Item item): adds the given item to the player's inventory
     *   internal string GenerateEndGameFeedback(): generates the end game feedback based on the player's inventory
     * ===============================================================================================
     */
    
    // Increase the player's sustainability score by the given amount
    internal void IncreaseScore(int amount) {
        SustainabilityScore += amount;
    }
    
    
    // Add a token to the player's tokens
    internal void AddToken() {
        Tokens++;
        Console.WriteLine($"You earned a token! Total tokens: {Tokens}");
    }
    
    // Spend the given amount of tokens if the player has enough
    internal bool SpendTokens(int amount) {
        if (Tokens >= amount)
        {
            Tokens -= amount;
            Console.WriteLine($"You spent {amount} tokens. Remaining tokens: {Tokens}");
            return true;
        }
        else
        {
            Console.WriteLine("Not enough tokens!");
            return false;
        }
    }
    
    // Call the Show method of the Inventory class to display the player's inventory
    internal void ShowInventory() {
        _inventory.Show();
    }

    // Call the Add method of the Inventory class to add the given item to the player's inventory  
    internal void AddToInventory(Item item) {
        _inventory.Add(item);
    }

    // Generate the end game feedback based on the player's inventory
    internal string GenerateEndGameFeedback() {
        string stringVariable = "";
        foreach (var item in _inventory.GetItems()) {

            stringVariable += $"Item: {item.Name}, Value: {item.Value}\n";
            stringVariable += WordWrap($"Description: {item.Description}", 100, "             ") + "\n";
            stringVariable += WordWrap($"Feedback: {item.EndGameFeedback}", 100, "          ") + "\n";
            stringVariable +=
                "-------------------------------------------------------------------------------------------------------------\n";
        }

        return stringVariable;
    }

   /*
    * ===============================================================================================
    * Inner Class: private class Inventory: represents the player's inventory
    *             Fields: private readonly List<Item> _inventory: holds the items in the player's inventory
    *             Methods: internal void Add(Item item): adds the given item to the inventory
    *                    internal void Show(): displays the inventory
    *                  internal List<Item> GetItems(): returns the items in the inventory (traditional getter, could be
    *                 replaced with a property in C#)
    * ===============================================================================================
    */
    private class Inventory {
        private readonly List<Item> _inventory = new List<Item>();

        internal void Add(Item item) {
            _inventory.Add(item);
            string stringVariable = $"{item.Name} added to inventory. \n {WordWrap(item.Description, 60, "")}";
        }

        internal void Show() {
            int i = 1;
            string stringVariable = "Inventory: \n";
            foreach (var item in _inventory) {
                stringVariable += (i + ". " + item.Name + " " + item.Value + "\n");
                i++;
            }

            PrintMessage("generic", stringVariable);
        }

        internal List<Item> GetItems() {
            return _inventory;
        }
    }
}