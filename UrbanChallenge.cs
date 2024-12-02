using System;
using System.Collections.Generic;

namespace Ecotropolis
{
    public class UrbanChallenge
    {
        public string ChallengeDescription { get; private set; }
        private List<ChallengeOption> options;

        public UrbanChallenge(string description)
        {
            ChallengeDescription = description;
            options = new List<ChallengeOption>
            {
                new ChallengeOption("Option 1: Volunteer", 10),
                new ChallengeOption("Option 2: Donate", 5)
            };
        }

        public void Execute(Player player)
        {
            Console.WriteLine($"Challenge: {ChallengeDescription}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i].Description}");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < options.Count)
            {
                player.IncreaseScore(options[choice].ScoreImpact);
            }
            else
            {
                Console.WriteLine("Invalid choice. No impact.");
            }
        }
    }
}
