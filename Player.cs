using System;
using System.Collections.Generic;

namespace Ecotropolis;

public class Player
{
    private List<Item> inventory;
    private List<Location> visitedLocations;
    private int score;

    public Player()
    {
        inventory = new List<Item>();
        visitedLocations = new List<Location>();
        score = 0;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        Console.WriteLine($"Score increased by {points}. Total score: {score}");
    }

    public void AddToInventory(Item item)
    {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void SellItem(Item item)
    {
        if (inventory.Remove(item))
        {
            IncreaseScore(item.Value);
            Console.WriteLine($"{item.Name} sold for {item.Value} points.");
        }
        else
        {
            Console.WriteLine("Item not found in inventory.");
        }
    }
}

