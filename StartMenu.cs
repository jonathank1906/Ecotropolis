namespace Ecotropolis;
using static Ecotropolis.Messager;

internal class StartMenu {
    internal StartMenu() {
        PrintMessage("welcome");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}