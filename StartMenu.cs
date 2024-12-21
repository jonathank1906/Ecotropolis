namespace Ecotropolis;
using static Ecotropolis.Messager;


public class StartMenu {
    public StartMenu() {
        PrintMessage("welcome");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}