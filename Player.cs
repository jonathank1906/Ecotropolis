namespace Ecotropolis;

public class Player
{
    public Inventory Inventory { get; private set; }
    private int score;

    public Player()
    {
        Inventory = new Inventory(this);
        score = 0;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        Console.WriteLine($"Score increased by {points}. Total score: {score}");
    }
}