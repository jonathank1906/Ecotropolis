namespace Ecotropolis;
public class ChallengeOption
{
    public string Description { get; private set; }
    public int ScoreImpact { get; private set; }

    public ChallengeOption(string description, int scoreImpact)
    {
        Description = description;
        ScoreImpact = scoreImpact;
    }
}

