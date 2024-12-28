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
                  ---- Travel Menu ----
                  Explore vibrant cities across the globe, each with unique challenges to tackle.
                  Solve urban issues, earn rewards, and shape the future of Ecotropolis!
                  Select a location to visit:
                  """;
        AddMessage(key, message);

        key = "return_travel";
        message = "Press any key to return to the travel menu...";
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

        key = "challenge"; 
        message = "Challenge:";
        AddMessage(key, message);
        
        key = "all_locations_visited";
        message = "Congratulations! You have completed all the challenges in Ecotropolis.";
        AddMessage(key, message);
        
        key = "pawn_shop";
        message = """
                  Welcome to the Pawn Shop! Here you can buy unique items to help you build your city.
                  Available unique items:
                  """;
        AddMessage(key, message);
        
        key = "pawn_shop_menu";
        message = """
                  What would you like to do?
                  0. Exit the shop
                  1. Buy an item
                  2. View inventory
                  """;
        AddMessage(key, message);
        
        key = "game_end";
        message =
            """
            You have reached the end of the game. Your own city is now yours. Here are some stats on your performance:
            You have completed your journey with a sustainability score of...
            """;
        AddMessage(key, message);
        
        key = "feedback";
        message = "Here is a summary of the items you obtained in each location along with some feedback:";
        AddMessage(key, message);
        
        key = "exit_game";
        message = "Thank you for playing Ecotropolis!"; 
        AddMessage(key, message);

    }
    
    private static void AddMessage(string key, string message)
    {
        Messages.Add(key, message);
    }
    
    public static void PrintMessage(string key, string? variable = null, bool raw = false) {
        if (raw) {
            Console.WriteLine(variable);
            return;
        } 
            //Console.WriteLine("\n[SYSTEM MESSAGE START]");
        Console.WriteLine();
        Console.WriteLine("{---------------------------------}");
        Messages.TryGetValue(key, out string message);
        
        if (string.IsNullOrEmpty(message)) {
            Console.WriteLine("Message not found.");
        }
        else {
            if (string.IsNullOrEmpty(variable)) {
                Console.WriteLine(message);
            }
            else if (key == "generic") {
                Console.WriteLine(variable);
            }
            else {
                Console.WriteLine(message);
                Console.WriteLine("");
                Console.WriteLine(variable);
            }
        }

        Console.WriteLine("{---------------------------------}");
        //Console.WriteLine("[SYSTEM MESSAGE END]");
    }

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