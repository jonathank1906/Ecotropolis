namespace Ecotropolis;

public class Player
{
    public Inventory Inventory { get; set; }
    public int SustainabilityScore { get; set; }
    public int Tokens { get; set; }
    public Player() {
        Inventory = new Inventory();  
        Tokens = 0;
        SustainabilityScore = 0;
    }
    public void IncreaseScore(int amount) {
        SustainabilityScore += amount;
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