namespace Ecotropolis;
using static EcoTropolis.Messages;

public class StartMenu {
    public StartMenu() {
        DisplayMessage("world map");
        DisplayMessage("start");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}