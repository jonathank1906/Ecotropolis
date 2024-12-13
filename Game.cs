namespace Ecotropolis;
using static EcoTropolis.Messages;
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
            CreateManilla(),
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
        // Create the different reward items
        Item goodItem = new Item("Golden Windmill Replica", 100, "A small windmill replica made of gold, symbolizing Amsterdam's heritage.");
        Item mediumItem = new Item("Silver Bicycle Bell", 50, "A decorative bell for bicycles, Amsterdam's favorite transport.");
        Item badItem = new Item("Bronze Tulip", 20, "A rare tulip dipped in bronze.");
        // Create a new Location for Amsterdam
        Location amsterdam = new Location("Amsterdam");

        amsterdam.AddRewardItem(goodItem);
        amsterdam.AddRewardItem(mediumItem);
        amsterdam.AddRewardItem(badItem);
      
        // Create Urban Challenges for Amsterdam
        UrbanChallenge growth = new UrbanChallenge(@"Balancing Growth with Heritage:
        Amsterdam's need for more housing is in direct tension with its commitment to preserving the
        city's unique cultural and historical identity. Decisions on how to expand housing must balance
        the urgency of the housing crisis with maintaining Amsterdam's character as a world-renowned
        cultural and historical hub.
        ");
        growth.AddOption(new ChallengeOption(@"Skyward Expansion.
        Amsterdam is considering new high-rise, eco-friendly buildings to fit more homes into
        limited space. This approach would allow more housing without sprawling outward, but it
        risks changing Amsterdam's historic skyline. If successful, your city could adopt a
        similar model, preserving space while maximizing housing options.", 3));  // Option 1
        growth.AddOption(new ChallengeOption(@"Historical Revitalization.
        Alternatively, Amsterdam could convert its old, vacant buildings into affordable apartments.
        While this solution could fit Amsterdam's character, it may limit housing capacity. Your city
        could use this approach to protect cultural areas while meeting housing demands.", 1));  // Option 2
        growth.AddOption(new ChallengeOption(@"Floating neighbourhoods.
        Amsterdam could create floating homes and neighbourhoods along its canals, a concept that
        aligns with its strong maritime heritage. These eco-friendly, water-based residences could
        expand housing without crowding the city center or altering the skyline. For your city, adopting
        floating neighbourhoods could help manage growth sustainably while adding a unique, attractive
        element to the cityscape.
        ", 5));  // Option 3


        UrbanChallenge housing = new UrbanChallenge(@"Innovative Housing Models:
        Amsterdam is exploring ways to address its housing shortage through creative models. The approaches
        vary in alignment with SDG 11, focusing on inclusivity, affordability, and sustainability. The challenge 
        lies in balancing quick fixes with long-term solutions that create resilient and inclusive urban environments.
        ");
        housing.AddOption(new ChallengeOption(@"Government Partnerships for Affordable Housing.
        Amsterdam is exploring partnerships where developers receive government incentives to build
        affordable housing. This would demand substantial funding but could attract new housing projects
        quickly. Your city, with a growing population, might consider similar incentives to ensure housing
        is available for all income levels.", 5));  // Option 1
        housing.AddOption(new ChallengeOption(@"Co-living Spaces.
        Amsterdam is testing co-living spaces that allow residents to share amenities and reduce costs. 
        This model fosters a sense of community but may not appeal to all citizens. If it proves successful, 
        your city could adapt this approach to strengthen community ties and offer affordable options in dense areas.", 1));   // Option 2
        housing.AddOption(new ChallengeOption(@"Repurposing Vacant Commercial Spaces.
        With the rise of remote work, many commercial spaces in Amsterdam are left vacant. The city could incentivize
        the repurposing of office buildings and unused commercial spaces into affordable housing units. This adaptive
        reuse would create housing quickly, and it could serve as a model for your city, especially if commercial
        spaces become underutilized in the future.
        ", 3));   // Option 3


        UrbanChallenge safety = new UrbanChallenge(@"Safety Disparities:
        Safety disparities are a pressing concern in Amsterdam, with certain neighbourhoods experiencing higher levels 
        of crime, fewer resources for community safety, and reduced perceptions of security compared to others. These 
        inequalities often align with socioeconomic factors, where marginalized communities face greater vulnerabilities. 
        This not only affects residents' quality of life but also undermines SDG 11's aim for inclusive, safe, and 
        resilient cities.
        ");
        safety.AddOption(new ChallengeOption(@"Increased Police Presence.
        Deploying more law enforcement officers in high-crime areas may reduce immediate incidents but can lead to
        over-policing, racial profiling, and distrust among communities. This approach treats symptoms rather than
        addressing root causes of safety disparities, further alienating marginalized groups and violating principles of inclusivity.", 1)); // Option 1
        safety.AddOption(new ChallengeOption(@"Community Safety Initiatives.
        Encouraging neighborhood watch programs and providing grants for community-led safety projects can empower residents.
        However, without addressing systemic inequalities, these initiatives risk becoming unsustainable or failing to address
        the broader structural causes of insecurity.", 3)); //Option 2
        safety.AddOption(new ChallengeOption(@"Holistic Urban Safety Program.
        Implement a comprehensive urban safety strategy combining affordable housing, quality education, employment opportunities, 
        and targeted social services in vulnerable neighbourhoods. Engaging residents and local organizations ensures solutions are
        culturally relevant and sustainable.
        ", 5)); // Option 3


        UrbanChallenge housingaccess = new UrbanChallenge(@"Social Inequalities in Housing Access:
        In Amsterdam, marginalized groups such as low-income families, immigrants, and students face systemic barriers to securing
        adequate housing. These challenges arise from the city's high housing costs, competition for limited space, and insufficient
        social housing availability. As a result, some communities are forced into substandard housing or face displacement.
        Addressing these inequalities is essential to creating inclusive cities and fulfilling SDG 11's vision of housing for all.
        ");
        housingaccess.AddOption(new ChallengeOption(@"Prioritize Market-Rate Housing Development.
        Focusing on market-rate housing construction might increase supply but often excludes low-income groups, exacerbating
        inequality and gentrification.", 1)); // Option 1
        housingaccess.AddOption(new ChallengeOption(@"Mixed-Income Urban Developments.
        Promote inclusive urban planning by requiring mixed-income housing in all new developments. This ensures that affordable,
        social, and market-rate units coexist, fostering socioeconomic diversity. Complement this with rent controls, tenant protections,
        and subsidies for vulnerable groups. ", 5)); //Option 2
        housingaccess.AddOption(new ChallengeOption(@"Expand Social Housing Stock.
        Increasing the number of social housing units can provide relief for low-income families. However, this solution is limited by funding
        constraints and risks creating segregated neighbourhoods if not properly integrated with other housing types.
        ", 3)); // Option 3


        UrbanChallenge greenspaces = new UrbanChallenge(@"Inequitable Access to Public Green Spaces:
        While Amsterdam is known for its green spaces, access to these areas is unevenly distributed across neighbourhoods. Communities in
        lower-income or densely populated areas often have fewer parks and recreational spaces, limiting opportunities for exercise, mental
        health benefits, and community interaction. This imbalance reinforces social inequality and reduces overall urban resilience, which
        is a critical focus of SDG 11.
        "); // Option 1
        greenspaces.AddOption(new ChallengeOption(@"Focus on Large Central Parks.
        Focus resources on enhancing and enlarging existing major parks, like Vondelpark or Westerpark, to attract more visitors and boost 
        tourism. While this approach highlights well-known landmarks, it fails to address green space disparities in underserved neighbourhoods 
        and may inadvertently worsen inequality.", 1)); // Option 2
        greenspaces.AddOption(new ChallengeOption(@"Develop Small Green Areas Locally.
        Add small, localized green areas in neighbourhoods lacking parks and community gardens, this 
        could provide immediate benefits and be an affordable option, making it pretty atractive to adress the problem in very few time", 3));
        greenspaces.AddOption(new ChallengeOption(@"Comprehensive Urban Greening Plan.
        Adopt a strategic urban greening initiative that integrates equitable access to green spaces citywide. This would include creating new 
        parks in neighbourhoods in demand of parks embedding green infrastructure into urban developments, and incentivizing rooftop gardens and 
        green facades.
        ", 5)); // Option 3


        // Add the challenges to the Amsterdam location
        amsterdam.AddUrbanChallenge(growth);
        amsterdam.AddUrbanChallenge(housing);
        amsterdam.AddUrbanChallenge(safety);
        amsterdam.AddUrbanChallenge(housingaccess);
        amsterdam.AddUrbanChallenge(greenspaces);

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
}