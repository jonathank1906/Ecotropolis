namespace Ecotropolis;
using static EcoTropolis.Messages;
public class Game
{
    private Player player;
    private List<Location> locations;

    public Game()
    {
        player = new Player();
        locations = new List<Location>
        {
            CreateLosAngeles(),
            CreateTokyo(),
            CreateAmsterdam(),
            CreateManilla(),
            // More locations...
        };
    }

    public void DisplayStartMenu()
    {
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


        Console.WriteLine("Welcome to Ecotropolis – the city-building adventure where your decisions shape the future!\n\n" +
        "As a visionary leader, you'll travel to different cities, taking on roles like mayor, corporate CEO, or urban planner.\n" +
        "Each city faces unique environmental and urban challenges that only you can solve.\n" +
        "Complete quests to earn rewards that you can use to design and build your own perfect, sustainable city.\n" +
        "Can you balance progress with preservation and create a thriving, green metropolis?\n" +
        "The fate of Ecotropolis is in your hands!\n");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.WriteLine("\nPlease name your city and press enter:");
        Console.Write("> ");

        string? cityName = Console.ReadLine();
        Console.WriteLine($"\nWelcome to {cityName} Mr. newly elected mayor. \n" +
        "Thanks to our new programme called EcoTropolis you can help our city by helping others ;)\n");
        
        GamePlay(); // Go to main game loop
    }


    public void GamePlay()
    {
        while (true) 
        {
            if (locations.Count == 0)
            {
                DisplayMessage("All Locations Visited");
                PawnShopSequence();
                break;
            }
            DisplayTravelMenu(); // Display the travel menu to the player
            string? input = Console.ReadLine(); // Get the player's choice from the menu

            if (!string.IsNullOrEmpty(input)) // Ensure input is not null or empty
            {
                try
                {
                    int choice = int.Parse(input) - 1; // Parse input and adjust for zero-based index

                    if (choice >= 0 && choice < locations.Count) // Valid location
                    {
                        Location selectedLocation = locations[choice];
                        selectedLocation.DisplayStartMessage();
                        selectedLocation.PlayLocation(player);
                        locations.RemoveAt(choice);
                        Console.WriteLine("Press any key to return to the travel menu...");
                        Console.ReadKey(true);
                    }
                    else if (choice == -1) // Exit the game
                    {
                        DisplayMessage("Exit Game");
                        break;
                    }
                    else if (choice == locations.Count) // Display help menu
                    {
                        DisplayMessage("help");
                    }
                    else // Invalid choice
                    {
                        Console.WriteLine("\nInvalid choice. Please select a valid location.");
                    }
                }
                catch (FormatException) // Handle invalid numeric input
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number.");
                }
           }
           else // Null or empty input
           {
               Console.WriteLine("Input cannot be empty. Please enter a valid number.");
           }
        }
    }

    // Display the travel menu
    public void DisplayTravelMenu()
    {
        Console.WriteLine("0. Exit Game"); // Exit the game
        for (int i = 0; i < locations.Count; i++) // Display the available locations
        {
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }
        Console.WriteLine($"{locations.Count + 1}. Help"); // Display the help option
        Console.Write("> ");
    }


    // Travel to a specific location
    public void Travel(Location location)
    {
        Console.WriteLine($"Traveling to {location.Name}...");
        location.DisplayStartMessage(); // Display "You have arrived at {Location Name}"
        location.PlayLocation(player); // Play the challenges at the location
    }

    private Location CreateLosAngeles()
    {
        // Create a new Location for Los Angeles
        Location la = new Location("Los Angeles");
        la.WelcomeMessage = "Welcome to Los Angeles, the City of Angels!";
        // Create Urban Challenges for Los Angeles
        UrbanChallenge airPollution = new UrbanChallenge("Air Pollution in LA");
        airPollution.AddOption(new ChallengeOption("Implement new traffic laws", 10));  // Option 1
        airPollution.AddOption(new ChallengeOption("Reduce industrial emissions", 5));  // Option 2
        
        UrbanChallenge homelessness = new UrbanChallenge("Homelessness in LA");
        homelessness.AddOption(new ChallengeOption("Create affordable housing", 15));  // Option 1
        homelessness.AddOption(new ChallengeOption("Increase social programs", 10));   // Option 2

        // Add the challenges to the Los Angeles location
        la.AddUrbanChallenge(airPollution);
        la.AddUrbanChallenge(homelessness);

        return la;  // Return the populated location
    }

    private Location CreateTokyo()
    {
        // Create a new Location for Tokyo
        Location tokyo = new Location("Tokyo");

        // Create Urban Challenges for Tokyo
        UrbanChallenge airPollution = new UrbanChallenge("Air Pollution in Tokyo");
        airPollution.AddOption(new ChallengeOption("Implement new traffic laws", 10));  // Option 1
        airPollution.AddOption(new ChallengeOption("Reduce industrial emissions", 5));  // Option 2
        
        UrbanChallenge homelessness = new UrbanChallenge("Homelessness in Tokyo");
        homelessness.AddOption(new ChallengeOption("Create affordable housing", 15));  // Option 1
        homelessness.AddOption(new ChallengeOption("Increase social programs", 10));   // Option 2

        // Add the challenges to the Tokyo location
        tokyo.AddUrbanChallenge(airPollution);
        tokyo.AddUrbanChallenge(homelessness);

        return tokyo;  // Return the populated location
    }

    private Location CreateAmsterdam()
    {
        // Create a new Location for Amsterdam
        Location amsterdam = new Location("Amsterdam");
      
        // Create Urban Challenges for Amsterdam
        UrbanChallenge growth = new UrbanChallenge("Balancing Growth with Heritage");
        growth.AddOption(new ChallengeOption(@"Skyward Expansion.
        Amsterdam is considering new high-rise, eco-friendly buildings to fit more homes into
        limited space. This approach would allow more housing without sprawling outward, but it
        risks changing Amsterdam's historic skyline. If successful, your city could adopt a
        similar model, preserving space while maximizing housing options.", 3));  // Option 1
        growth.AddOption(new ChallengeOption(@"Historical Revitalization.
        Alternatively, Amsterdam could convert its old, vacant buildings into affordable apartments.
        While this solution could fit Amsterdam's character, it may limit housing capacity. Your city
        could use this approach to protect cultural areas while meeting housing demands.", 1));  // Option 2
        growth.AddOption(new ChallengeOption(@"Floating Neighborhoods.
        Amsterdam could create floating homes and neighbourhoods along its canals, a concept that
        aligns with its strong maritime heritage. These eco-friendly, water-based residences could
        expand housing without crowding the city center or altering the skyline. For your city, adopting
        floating neighbourhoods could help manage growth sustainably while adding a unique, attractive
        element to the cityscape.", 5));  // Option 3

        UrbanChallenge housing = new UrbanChallenge("Innovative Housing Models");
        housing.AddOption(new ChallengeOption(@"Government Partnerships for Affordable Housing.
        Amsterdam is exploring partnerships where developers receive government incentives to build
        affordable housing. This would demand substantial funding but could attract new housing projects
        quickly. Your city, with a growing population, might consider similar incentives to ensure housing
        is available for all income levels.", 2));  // Option 1
        housing.AddOption(new ChallengeOption(@"Co-living Spaces.
        Amsterdam is testing co-living spaces that allow residents to share amenities and reduce costs. 
        This model fosters a sense of community but may not appeal to all citizens. If it proves successful, 
        your city could adapt this approach to strengthen community ties and offer affordable options in dense areas.", 4));   // Option 2
        housing.AddOption(new ChallengeOption(@"Repurposing Vacant Commercial Spaces.
        With the rise of remote work, many commercial spaces in Amsterdam are left vacant. The city could incentivize
        the repurposing of office buildings and unused commercial spaces into affordable housing units. This adaptive
        reuse would create housing quickly, and it could serve as a model for your city, especially if commercial
        spaces become underutilized in the future.", 4));   // Option 2

        // Add the challenges to the Amsterdam location
        amsterdam.AddUrbanChallenge(growth);
        amsterdam.AddUrbanChallenge(housing);

        return amsterdam;  // Return the populated location
    }

    private Location CreateManilla()
    {
        // Create a new Location for Manilla
        Location manilla = new Location("Manilla");
      
        // Create Urban Challenges for Tokyo
        UrbanChallenge airPollution = new UrbanChallenge("Air Pollution in Manilla");
        airPollution.AddOption(new ChallengeOption("Implement new traffic laws", 10));  // Option 1
        airPollution.AddOption(new ChallengeOption("Reduce industrial emissions", 5));  // Option 2
        
        UrbanChallenge homelessness = new UrbanChallenge("Homelessness in Manilla");
        homelessness.AddOption(new ChallengeOption("Create affordable housing", 15));  // Option 1
        homelessness.AddOption(new ChallengeOption("Increase social programs", 10));   // Option 2

        // Add the challenges to the Manilla location
        manilla.AddUrbanChallenge(airPollution);
        manilla.AddUrbanChallenge(homelessness);

        return manilla;  // Return the populated location
    }

    public void PawnShopSequence()
    {
        Console.WriteLine("Welcome to the Pawn Shop! Here you can sell your items.");
        if (player.inventory.Count == 0)
        {
            Console.WriteLine("You have no items to sell.");
        }
        else
        {
            while (true)
            {
                Console.WriteLine("Your inventory:");
                for (int i = 0; i < player.inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.inventory[i].Name} (Value: {player.inventory[i].Value})");
                }

                Console.WriteLine("Enter the number of the item you want to sell, or type 'exit' to leave the Pawn Shop.");
                string? input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= player.inventory.Count)
                {
                    Item itemToSell = player.inventory[choice - 1];
                    player.SellItem(itemToSell);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }

        Console.WriteLine("Thank you for visiting the Pawn Shop. Your adventure ends here.");
    }
}