using System.Text.Json.Serialization;

namespace Ecotropolis;
internal class ChallengeOption {
    internal string Description { get; private set; }
    internal int ScoreImpact { get; private set; }

    [JsonConstructor]
    internal ChallengeOption(string description, int scoreImpact) {
        Description = description;
        ScoreImpact = scoreImpact;
    }
}