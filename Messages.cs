namespace EcoTropolis;

public static class Messages {
    public static void DisplayMessage(string messageType, string? cityName = null) {
        switch (messageType) {
            case "help":
                PrintHelpMessageMain();
                break;
            case "welcome":
                PrintWelcomeMessage(cityName);
                break;
            case "welcome to city":
                PrintCityWelcome(cityName);
                break;
            case "start":
                PrintStartMessage();
                break;
            case "invalid command":
                PrintInvalidCommandMessage();
                break;
            case "world map":
                PrintWorldMap();
                break;
            case "invalid option":
                PrintInvalidOption();
                break;
            case "empty input":
                PrintEmptyInput();
                break;
            case "All Locations Visited":
                PrintAllLocationsComplete();
                break;
            case "Exit Game":
                Console.WriteLine("\nExiting the game...");
                break;
            case "pawn shop":
                DisplayPawnShopItems();
                break;
            case "game_end":
                PrintEndMessage();
                break;
        }
    }


    private static void PrintHelpMessageMain() {
        Console.WriteLine("\nHelp - Game Instructions:");
        Console.WriteLine("Your task is to solve urban challenges across different cities.");
        Console.WriteLine("- Each city has unique problems. Travel to them to begin solving challenges.");
        Console.WriteLine("- After completing a challenge, you will receive a reward that impacts your city-building efforts.");
        Console.WriteLine("- Make strategic decisions to balance progress and sustainability.");
        Console.WriteLine("Press any key to return to the game...");
        Console.ReadKey();
    }

    private static void PrintWelcomeMessage(string? cityName) {
        Console.WriteLine($"\nWelcome to {cityName} Mr. newly elected mayor. \n" +
        "Thanks to our new programme called EcoTropolis you can help our city by helping others ;)\n");
    }

    private static void PrintCityWelcome(string? cityName) {
        Console.WriteLine($"You have arrived in {cityName}.");
    }

    private static void PrintStartMessage() { // start message
        Console.WriteLine("Welcome to Ecotropolis – the city-building adventure where your decisions shape the future!\n\n" +
        "As a visionary leader, you'll travel to different cities, taking on roles like mayor, corporate CEO, or urban planner.\n" +
        "Each city faces unique environmental and urban challenges that only you can solve.\n" +
        "Complete quests to earn rewards that you can use to design and build your own perfect, sustainable city.\n" +
        "Can you balance progress with preservation and create a thriving, green metropolis?\n" +
        "The fate of Ecotropolis is in your hands!\n");      
    }

    private static void PrintWorldMap() { // world map message
             Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣄⣤⣦⣶⣶⣖⣲⣦⣶⣼⣶⣿⣿⣿⣦⡤⠄⠀⠀⠀⢀⢀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣤⣿⣸⣷⣿⣿⣿⣿⠛⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠀⠀⠀⠀⠀⠘⢻⠻⠅⠀⠀⠀⠀⠀⠀⣀⣠⡀⠀⠀⠀⣈⣉⣻⣆⣤⠀⠀⠀⠀⢀⣠⡀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣽⡟⡯⡿⣿⣿⣧⣄⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⡋⠀⣀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⣾⡉⠀⣴⣦⣰⣾⣿⣿⣿⣿⣿⣷⣶⣴⣆⣀⣉⣧⣭⣀⣀⡀⠀⠀⠀⣠⠀⠀⠀⠀
⠀⢀⣤⣿⣿⣿⣿⣤⣄⣼⣧⣧⣼⣿⣿⣃⣿⣧⣜⡿⣿⢿⣟⡀⠀⣻⣿⣿⣿⣿⠿⠟⠀⠀⠛⠀⠀⠀⠀⢠⣧⣿⣿⣧⣄⢠⢀⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣄⡀⠀⠀
⠀⢺⣲⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠅⡷⢿⣿⠋⠀⢹⣿⡿⠉⠁⠀⠸⠿⠃⠀⠀⠀⢀⣠⣿⡿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⠙⠏⠀
⠀⠻⣿⡟⠟⠛⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⠀⠀⢸⣿⣷⣤⡀⠀⠀⠙⠁⠀⠀⠀⠀⠀⠀⢠⣴⠂⠹⣿⣿⠇⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠛⠛⢨⣿⡉⠃⠀⠀⠀⠀
⠰⠛⠁⠁⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⣾⣿⣿⣿⣷⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⡶⣿⣧⣠⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣄⠀⠘⠿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠹⠷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢩⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡿⠉⢾⢳⡿⣿⣻⣶⣦⣽⣿⡦⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡿⣟⠋⠀⢻⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣨⣿⣶⣿⣿⣀⢀⣈⡉⠙⣻⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡅⠹⢳⡶⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⠟⠛⠉⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⣿⣿⣀⣴⡄⠛⣶⣠⡄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡹⣿⣿⣿⣿⠃⠀⠙⣻⣿⣿⡟⠋⢿⣿⣿⣿⠟⠉⢘⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠻⣷⠀⢀⣠⣀⢁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣋⣍⠀⠀⠀⠀⠘⣿⡃⠀⠀⠈⢻⡿⣿⠆⠀⣸⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⣾⣿⣿⣿⣷⣤⡄⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⠿⠟⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠈⠟⠀⠀⠠⢌⣷⡍⠀⣰⡧⢙⢃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢴⣿⣿⣿⣿⣿⣿⣿⣦⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣤⠿⢿⢿⡝⠼⠆⣴⣤⣀⢀⣤⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠓⠃⠨⠾⠀⣀⣀⠻⡟⠿⠉⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⡿⢠⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣷⣿⣿⣼⣷⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⡿⠀⢺⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣾⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠛⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⠿⣿⣿⣿⣿⣿⠄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠀⠀⠈⢹⣿⣿⠃⠀⠀⠀⠀⢸⡄
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⠄⠀⠀⠀⣀⣴⠿⠉
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢧⠄⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
    }

    private static void PrintInvalidCommandMessage() { // invalid command message
        Console.WriteLine("\nInvalid input. Please try again.");
    }

    private static void PrintInvalidOption() { // invalid city name message
        Console.WriteLine("\nInvalid choice. Please select a valid option.");
    }

    private static void PrintEmptyInput() { // invalid city name message
        Console.WriteLine("\nInput cannot be empty. Please try again.");
    }

    private static void PrintMainCityDesc() { //main city message
        Console.WriteLine("Main City Message - please implement!!!!!!!!!!!!!!!!");
    }

    private static void PrintAllLocationsComplete() { //completed challenge message
        Console.WriteLine("\nCongratulations! You have completed all the challenges in Ecotropolis.");
    }

    public static void PrintEndMessage() { //end of game message
        Console.WriteLine("\nYou have reached the end of the game. Your own city is now yours. Here are some stats on your performance:");
    }

    public static void DisplayPawnShopItems() {
        Console.WriteLine(@" 
       Welcome to the Pawnshop!
--------------------------------------
        ");
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