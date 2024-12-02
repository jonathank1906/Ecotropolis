namespace Ecotropolis;
public class Location
{
    public string Name { get; private set; }
    private List<UrbanChallenge> urbanChallenges;

    public Location(string name)
    {
        Name = name;
        urbanChallenges = new List<UrbanChallenge>();
    }

    public void AddUrbanChallenge(UrbanChallenge challenge)
    {  
        urbanChallenges.Add(challenge);  // Add the challenge to the list
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"You have arrived at {Name}.");
    }

    public void PlayLocation(Player player)
    {
        foreach (var challenge in urbanChallenges)
        {
            challenge.Execute(player);
        }
        // Challenges completed, go back to the travel menu
        //TODO: delete a location after it was finished 
    }
}

