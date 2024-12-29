using System.IO;
using System.Text.Json;

namespace Ecotropolis;

/*
 * ========================================================================================================
 * internal static class LocationLoader:
 *
 * This class is responsible for loading location data from JSON files in a specified folder.
 * It uses System.IO and System.Text.Json to read and deserialize the JSON files.
 * ========================================================================================================
 */

internal static class LocationLoader {
    internal static List<Location> LoadLocationsFromFolder(string folderPath) {
        var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };

        var locations = new List<Location>();

        try {
            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");  // Get all JSON files in the folder

            foreach (string filePath in jsonFiles) {
                string json = File.ReadAllText(filePath);
                Location? location = JsonSerializer.Deserialize<Location>(json, options);
                if (location != null)
                {
                    locations.Add(location);
                }
                else
                {
                    Console.WriteLine($"Warning: Failed to deserialize {filePath}. Skipping.");
                }
            }
        }
        catch (DirectoryNotFoundException ex) {
            Console.WriteLine($"Error: Folder not found - {ex.Message}");
        }
        catch (Exception ex) {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        return locations;
    }
}
