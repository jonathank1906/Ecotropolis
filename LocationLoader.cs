using System.IO;
using System.Text.Json;

namespace Ecotropolis; 

public static class LocationLoader
{
    public static Location LoadLocationFromJson(string filePath) {
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Ignores case differences
        };
        
        try {
            string json = File.ReadAllText(filePath);
            Console.WriteLine(json);
            return JsonSerializer.Deserialize<Location>(json, options);
        } catch (FileNotFoundException ex) {
            Console.WriteLine($"File not found: {ex.Message}");
            return null;
        } catch (JsonException ex) {
            Console.WriteLine($"Invalid JSON format: {ex.Message}");
            return null;
        }
    }
}