using System.Text;
using System.Threading.Channels;

namespace Ecotropolis;

public static class Messager
{
    public static Dictionary<string, string> Messages { get; private set; } = new Dictionary<string, string>(); 
    
    static Messager () {
        InstatiateMessages();
    }
    
    private static void InstatiateMessages()
    {
        string key = "generic";
        string message = " "; 
        AddMessage(key, message);
        
        key = "welcome";
        message = """
                         Welcome to Ecotropolis – the city-building adventure where your decisions shape the future!
                         As a visionary leader, you'll travel to different cities, taking on roles like mayor, corporate CEO, or urban planner.
                         Each city faces unique environmental and urban challenges that only you can solve.
                         Complete quests to earn rewards that you can use to design and build your own perfect, sustainable city.
                         Can you balance progress with preservation and create a thriving, green metropolis?
                         The fate of Ecotropolis is in your hands!
                         """; 
        AddMessage(key, message);
        
        key = "help";
        message = """
                  Help - Game Instructions:
                  Your task is to solve urban challenges across different cities.
                  Each city has unique problems. Travel to them to begin solving challenges.
                  After completing a challenge, you will receive a reward that impacts your city-building efforts.
                  Make strategic decisions to balance progress and sustainability.
                  Press any key to return to the game...
                  """; 
        AddMessage(key, message);
        
        key = "travel_menu";
        message = """
                  Travel Menu:
                  Select a location to visit:
                  TODO: WE NEED TO MAKE SOME SORT OF A DESCRIPTION HERE!!!!  
                  
                  Available locations:
                  """; //TODO: Travel menu description
        AddMessage(key, message);
        
        key = "invalid_option";
        message = "Invalid choice. Please select a valid option.";
        AddMessage(key, message);
        
        key = "invalid_command";
        message = "Invalid input. Please try again."; 
        AddMessage(key, message);
        
        key = "empty_input";
        message = "Null or empty input. Please try again.";
        AddMessage(key, message);
        
        key = "all_locations_visited";
        message = "nCongratulations! You have completed all the challenges in Ecotropolis.";
        AddMessage(key, message);
        
        key = "pawn_shop";
        message = "Welcome to the Pawn Shop! Here you can buy unique items to help you build your city.";
        AddMessage(key, message);
        
        key = "game_end";
        message =
            "You have reached the end of the game. Your own city is now yours. Here are some stats on your performance:";
        AddMessage(key, message);
        
        key = "exit_game";
        message = "Thank you for playing Ecotropolis!"; 
        AddMessage(key, message);

    }
    
    public static void AddMessage(string key, string message)
    {
        Messages.Add(key, message);
    }
    
    public static void PrintMessage(string key, string? variable = null) {
        Console.WriteLine("\n[SYSTEM MESSAGE START]");
        Console.WriteLine("---------------------------------");
        Messages.TryGetValue(key, out string? message);
        
        if (string.IsNullOrEmpty(message)) {
            Console.WriteLine("Message not found.");
        }
        else {
            if (string.IsNullOrEmpty(variable)) {
                Console.WriteLine(message);
            }
            else {
                Console.WriteLine(message);
                Console.WriteLine("");
                Console.WriteLine(variable);
            }
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("[SYSTEM MESSAGE END]");
        Console.Write("> ");
    }

    // public static void PrintMessage() {
        
    // }

    public static string WordWrap(string text, int lineWidth, string indent)
    {
        string[] words = text.Split(' ');
        string result = "";
        string currentLine = "";
        bool firstLine = true;

        foreach (var word in words)
        {
            if ((currentLine + word).Length > lineWidth)
            {
                // Add the current line to the result, applying indentation for subsequent lines
                if (firstLine)
                {
                    result += currentLine.TrimEnd() + Environment.NewLine;
                    firstLine = false;
                }
                else
                {
                    result += indent + currentLine.TrimEnd() + Environment.NewLine;
                }
                currentLine = "";
            }
            currentLine += word + " ";
        }

        // Add any remaining text, with indentation if it's not the first line
        if (!firstLine)
        {
            result += indent + currentLine.TrimEnd();
        }
        else
        {
            result += currentLine.TrimEnd();
        }
        return result;
    }
}