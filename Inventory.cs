namespace Ecotropolis;
using static Ecotropolis.Messager;

public class Inventory {
    public List<Item> inventory;
    public Inventory() {
        inventory = new();
    }
    public void AddToInventory(Item item) {
        inventory.Add(item);
        string stringVariable = $"{item.Name} added to inventory. \n {WordWrap(item.Description, 60, "")}"; 
        PrintMessage("generic", stringVariable);
    }
    public void Show() { 
        int i = 1;
        string stringVariable = "Inventory: \n";
        foreach (var item in inventory) {
            stringVariable += (i + ". " + item.Name + " " + item.Value);
            i++;
        }
        PrintMessage("generic", stringVariable);
    }
    public string GenerateEndGameFeedback() {
        string stringVariable = "";
        foreach (var item in inventory) {
            stringVariable += $"Item: {item.Name}, Value: {item.Value}\n";
            stringVariable += WordWrap($"Description: {item.Description}",100,"             ") + "\n";
            stringVariable += WordWrap($"Feedback: {item.EndGameFeedback}", 100, "          ") + "\n";
            stringVariable += "-------------------------------------------------------------------------------------------------------------\n";
        }

        return stringVariable;
    }
}