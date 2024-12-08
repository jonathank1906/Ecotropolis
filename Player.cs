namespace Ecotropolis;

public class Player
{
    public Inventory Inventory { get; set; }
    public int score {get; set;}

    public Player() {
        Inventory = new Inventory();
        score = 0;
    }

    public void IncreaseScore(int points) {
        score += points;
        Console.WriteLine($"Score increased by {points}. Total score: {score}");
    }

    public void ShowInventory() {
        Inventory.Show(); 
    }
}