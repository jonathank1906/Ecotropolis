using System;
using System.Collections.Generic;

namespace Ecotropolis
{
    public class Location
    {
        public string Name { get; private set; }
        private List<UrbanChallenge> urbanChallenges;

        public Location(string name)
        {
            Name = name;
            urbanChallenges = new List<UrbanChallenge>
            {
                new UrbanChallenge("Clean up the park"),
                new UrbanChallenge("Improve public transportation")
            };
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
        }
    }
}
