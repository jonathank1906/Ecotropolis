namespace Ecotropolis;
using static EcoTropolis.Messages;

public class StartMenu {
    public string? CityName { get; private set; }   
    
    public StartMenu() {
        DisplayMessage("world map");
        DisplayMessage("start");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}