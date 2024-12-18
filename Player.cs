namespace Ecotropolis;

public class Player
{
    public Inventory Inventory { get; set; }
    public int Score { get; set; }
    public int SustainabilityScore { get; set; }
    public int Tokens { get; set; }
    public Player() {
        Inventory = new Inventory();  
        Score = 0;
        Tokens = 0;
    }
    public void IncreaseScore(int amount) {
        Score += amount;
        SustainabilityScore += Score;
    }
    public void AddToken()
    {
        Tokens++;
        Console.WriteLine($"You earned a token! Total tokens: {Tokens}");
    }
    public bool SpendTokens(int amount)
    {
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
}