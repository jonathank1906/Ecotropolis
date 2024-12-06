namespace Ecotropolis;
public class PawnShop
{
    private Player player;

    public PawnShop(Player player)
    {
        this.player = player;
    }

    public void Open()
    {
        Console.WriteLine("Welcome to the Pawn Shop! Here you can sell your items.");
        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("You have no items to sell.");
        }
        else
        {
            while (true)
            {
                Console.WriteLine("Your inventory:");
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.Inventory[i].Name} (Value: {player.Inventory[i].Value})");
                }

                Console.WriteLine("Enter the number of the item you want to sell, or type 'exit' to leave the Pawn Shop.");
                string? input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= player.Inventory.Count)
                {
                    Item itemToSell = player.Inventory[choice - 1];
                    player.Inventory.SellItem(itemToSell);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }
    }
}