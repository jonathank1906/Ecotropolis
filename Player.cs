namespace Ecotropolis;

public class Player
{
    public Inventory Inventory { get; set; }
    public int score { get; set; }

    public Player() {
        Inventory = new Inventory();  // Passes 'this' to Inventory constructor
        score = 0;
    }

    public void IncreaseScore(int points) {
        score += points;
        Console.WriteLine($"Score increased by {points}. Total score: {score}");
    }

    public void ShowInventory() {
        Inventory.Show();  // Uses Inventory's Show method to display items
    }
}
