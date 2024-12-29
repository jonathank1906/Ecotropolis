using System.Text;
using System.Threading.Channels;

namespace Ecotropolis;

/*
 * ========================================================================================================
 * static class Messager:
 *
 * This class is responsible for displaying messages to the user. It contains a dictionary of messages that
 * can be accessed by a key. The messages are stored as strings and can be printed to the console. The class
 * also provides a method for word wrapping messages to fit a specified line width.
 * ========================================================================================================
 */

static class Messager {
    
    /*
     * ===============================================================================================
     * Fields: private static readonly Dictionary<string, string> _messages: holds the messages
     * ===============================================================================================
     */
    private static readonly Dictionary<string, string> _messages = new Dictionary<string, string>(); 
    
    /*
     * ===============================================================================================
     * Static Constructor: Messager():
     * Initializes the messages in the dictionary.
     * ===============================================================================================
     */
    
    static Messager () {
        InitiateMessages();
    }
    
    /*
     * ===============================================================================================
     * Methods: private static void InitiateMessages(): initializes the messages in the dictionary
     *         private static void AddMessage(string key, string message): adds a message to the dictionary
     *        public static void PrintMessage(string key, string? variable = null, bool raw = false): prints a message to the console
     *       public static string WordWrap(string text, int lineWidth, string indent): wraps a message to fit a specified line width
     * ===============================================================================================
     */
    
    /*
     * InitiateMessages():
     * Initializes the messages in the dictionary. Each message is associated with a key for easy access.
     * The messages are stored as strings and can be printed to the console.
     * The messages include generic messages, game instructions, and feedback messages.
     */
    private static void InitiateMessages() {
        string key = "generic";
        string message = "{0}"; 
        AddMessage(key, message);
        
        key = "welcome";
        message = """
                         Welcome to Ecotropolis – the city-building adventure where your decisions shape the future!
                         As a visionary leader, you'll travel to different cities, taking on roles like mayor, corporate CEO, or urban planner.
                         Each city faces unique environmental and urban challenges that only you can solve.
                         Complete quests to earn rewards that you can use to design and build your own perfect, sustainable city.
                         Can you balance progress with preservation and create a thriving, green metropolis?
                         The fate of Ecotropolis is in your hands!
                         {0}
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
                   {0}
                   """; 
        AddMessage(key, message);
        
        key = "travel_menu";
        message = """
                   ---- Travel Menu ----
                   Explore vibrant cities across the globe, each with unique challenges to tackle.
                   Solve urban issues, earn rewards, and shape the future of Ecotropolis!
                   Select a location to visit:
                   0. Exit Game
                   {0}
                   """;
        AddMessage(key, message);

        
        key = "reward_earned";
        message = """
                  Congratulations!
                  You have successfully completed the challenge and earned a reward.
                  Your reward: {0}
                  """;
        AddMessage(key, message);
    
        key = "return_travel";
        message = "Press any key to return to the travel menu...{0}";
        AddMessage(key, message);
        
        key = "invalid_option";
        message = "Invalid choice. Please select a valid option.{0}";
        AddMessage(key, message);
        
        key = "invalid_command";
        message = "Invalid input. Please try again.{0}"; 
        AddMessage(key, message);
        
        key = "empty_input";
        message = "Null or empty input. Please try again.{0}";
        AddMessage(key, message);

        key = "challenge"; 
        message = "Challenge:{0}";
        AddMessage(key, message);
        
        key = "all_locations_visited";
        message = "Congratulations! You have completed all the challenges in Ecotropolis.{0}";
        AddMessage(key, message);
        
        key = "pawn_shop";
        message = """
                  Welcome to the Pawn Shop! Here you can buy unique items to help you build your city.
                  Available unique items:
                  {0}
                  What would you like to do?
                  0. Exit the shop
                  1. Buy an item
                  2. View inventory
                  """;
        AddMessage(key, message);
        
        key = "buy_items";
        message = """
                  Which item would you like to buy?
                  {0}
                  Please select the numbers 1-3. Press 0 to go back.
                  """;
        AddMessage(key, message);
        /*
        key = "pawn_shop_menu";
        message = """
                  What would you like to do?
                  0. Exit the shop
                  1. Buy an item
                  2. View inventory
                  """;
        AddMessage(key, message);
        
        */
        
        key = "game_end";
        message =
            """
            You have reached the end of the game. Your own city is now yours. Here are some stats on your performance:
            You have completed your journey with a sustainability score of... {0}
            """;
        AddMessage(key, message);
        
        key = "feedback";
        message = "Here is a summary of the items you obtained in each location along with some feedback:{0}";
        AddMessage(key, message);
        
        key = "exit_game";
        message = "Thank you for playing Ecotropolis!{0}"; 
        AddMessage(key, message);

    }
    
    /*
     * AddMessage(string key, string message):
     * Adds a message to the dictionary with the specified key.
     * This method is redundant, can be replaced with a standard dictionary method. 
     */
    private static void AddMessage(string key, string message) {
        _messages.Add(key, message);
    }
    
    /*
     * PrintMessage(string key, string? variable = null, bool raw = false):
     * Prints a message to the console based on the specified key.
     * If a variable is provided, it is included in the message.
     * If raw is true, the variable is printed directly without formatting.
     */
    private static string GenerateMessage(string key, string? variable, bool raw = false, bool interactive = false) {
        /*
        if (raw) {
            Console.WriteLine(variable);
            return;
        } */
            //Console.WriteLine("\n[SYSTEM MESSAGE START]");
        Console.Clear();
        Console.WriteLine("{---------------------------------}");
        _messages.TryGetValue(key, out string message);
        
        if (string.IsNullOrEmpty(message)) {
            Console.WriteLine("Message not found.");
        }
        else {
            if (string.IsNullOrEmpty(variable)) {
                Console.WriteLine(string.Format(message, string.Empty));
            }
            else {
                Console.WriteLine(string.Format(message, variable));
            }
        }

        Console.WriteLine("{---------------------------------}");
        
        if (interactive) {
            return Console.ReadKey().KeyChar.ToString();
        }
        else {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null; 
        }
        //Console.WriteLine("[SYSTEM MESSAGE END]");
    }

    public static void PrintMessage(string? key, string? variable = null, bool raw = false) {
        GenerateMessage(key, variable, raw);
    }
    public static string InteractiveMessage(string key, string? variable = null, bool raw = false) {
        return GenerateMessage(key, variable, raw,true); 
    }

    /*
     * WordWrap(string text, int lineWidth, string indent):
     * Wraps a message to fit a specified line width, applying indentation for subsequent lines.
     * This method is used to format long messages for display to the user.
     */
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