using System.Threading.Channels;

namespace Ecotropolis;
using static EcoTropolis.Messages;
using System.Text.Json;

public class Game
{
    private Player player;
    private List<Location> locations;
    private PawnShop pawnShop;

    public Game() {
        player = new Player();
        pawnShop = new PawnShop(player);
        locations = new List<Location> {
            CreateLosAngeles(),
            CreateTokyo(),
            CreateAmsterdam(),
            LocationLoader.LoadLocationFromJson("C:\\Users\\valko\\Documents\\UNI_Laptop\\01_Semester\\RefactoredEcotropolis\\jsons\\Manila.json")
            // More locations...
        };
        StartMenu startMenu = new StartMenu();
        GamePlay();
    }
   
   
    public void GamePlay() {
        bool enterPawnShopSequence = false;
        while (true) {
            if (locations.Count == 0) { 
                DisplayMessage("All Locations Visited");
                enterPawnShopSequence = true;
                break;
            }
            DisplayTravelMenu(); // Display the travel menu to the player
            string? input = Console.ReadLine(); // Get the player's choice from the menu

            if (!string.IsNullOrEmpty(input)) { // Ensure input is not null or empty
                try {
                    int choice = int.Parse(input) - 1; // Parse input and adjust for zero-based index
                    if (choice >= 0 && choice < locations.Count) { // Valid location
                        Location selectedLocation = locations[choice];
                        selectedLocation.DisplayStartMessage();
                        selectedLocation.PlayLocation(player); // Play the challenges at the location
                        locations.RemoveAt(choice);
                        Console.WriteLine("Press any key to return to the travel menu...");
                        Console.ReadKey(true);
                    }
                    else if (choice == -1) { // Exit the game
                        DisplayMessage("Exit Game");
                        break;
                    }
                    else if (choice == locations.Count) { // Display help menu
                        DisplayMessage("help");
                    }
                    else { // Invalid choice
                        DisplayMessage("invalid option");
                    }
                }
                catch (FormatException) { // Handle invalid numeric input
                    DisplayMessage("invalid command");
                }
           }
           else { // Null or empty input
               DisplayMessage("empty input");
           }
        }
        if (enterPawnShopSequence) {
            pawnShop.Open();
        }
       
    }

    public void DisplayTravelMenu() {  // Display the travel menu
        Console.WriteLine("0. Exit Game"); // Exit the game
        for (int i = 0; i < locations.Count; i++) { // Display the available locations
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }
        Console.WriteLine($"{locations.Count + 1}. Help"); // Display the help option
        Console.Write("> ");
    }

    private Location CreateLosAngeles() {
        Item goodItem = new Item("Golden Surfboard", 100, "A luxurious surfboard symbolizing LA's sunny beaches.");
        Item mediumItem = new Item("Silver Keychain", 50, "A sleek keychain featuring the LA skyline.");
        Item badItem = new Item("Bronze Badge", 20, "A small badge commemorating your visit to LA.");
        // Create a new Location for Los Angeles
        Location la = new Location("Los Angeles");
        la.AddRewardItem(goodItem);
        la.AddRewardItem(mediumItem);
        la.AddRewardItem(badItem);
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

    private Location CreateTokyo() {
        Item goodItem = new Item("Golden Fan", 100, "A traditional Japanese fan made with gold.");
        Item mediumItem = new Item("Silver Sushi Plate", 50, "A decorative sushi plate made of silver.");
        Item badItem = new Item("Bronze Origami Crane", 20, "A simple origami crane in bronze.");
        // Create a new Location for Tokyo
        Location tokyo = new Location("Tokyo");
        tokyo.AddRewardItem(goodItem);
        tokyo.AddRewardItem(mediumItem);
        tokyo.AddRewardItem(badItem);

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

    private Location CreateAmsterdam() {
        Item goodItem = new Item("Golden Tulip", 100, "A rare tulip dipped in gold, symbolizing Amsterdam's heritage.");
        Item mediumItem = new Item("Silver Bicycle Bell", 50, "A decorative bell for bicycles, Amsterdam's favorite transport.");
        Item badItem = new Item("Bronze Windmill Replica", 20, "A small windmill replica made of bronze.");
        // Create a new Location for Amsterdam
        Location amsterdam = new Location("Amsterdam");

        amsterdam.AddRewardItem(goodItem);
        amsterdam.AddRewardItem(mediumItem);
        amsterdam.AddRewardItem(badItem);
      
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
        spaces become underutilized in the future.", 4));   // Option 3

        // Add the challenges to the Amsterdam location
        amsterdam.AddUrbanChallenge(growth);
        amsterdam.AddUrbanChallenge(housing);

        return amsterdam;  // Return the populated location
    }

    private Location CreateManilla() {
        Item goodItem = new Item("Golden Jeepney", 100, "A golden miniature of Manila's iconic Jeepney.");
        Item mediumItem = new Item("Silver Coconut", 50, "A silver coconut symbolizing the Philippines' tropical beauty.");
        Item badItem = new Item("Bronze Sun Pin", 20, "A bronze pin representing the sun from the Philippine flag.");

        // Create a new Location for Manilla
        Location manilla = new Location("Manilla");

        manilla.AddRewardItem(goodItem);
        manilla.AddRewardItem(mediumItem);
        manilla.AddRewardItem(badItem);
      
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

    private Location createManila(string filePath) {
        return LoadLocationFromJson(filePath); 
    }
    
    public static Location LoadLocationFromJson(string filePath) {
        string json = File.ReadAllText(filePath);
        Console.WriteLine(json);
        return JsonSerializer.Deserialize<Location>(json);
    }
}