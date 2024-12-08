namespace Ecotropolis;
using static EcoTropolis.Messages;

public class StartMenu {
    public string? CityName { get; private set; }   
    
    public StartMenu() {
        DisplayMessage("world map");
        DisplayMessage("start");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.WriteLine("\nPlease name your city and press enter:");
        Console.Write("> ");
        string? cityName = Console.ReadLine();
        DisplayMessage("welcome", cityName);
    }
}