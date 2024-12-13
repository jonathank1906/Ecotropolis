using System.IO;
using System.Text.Json;

namespace Ecotropolis;

public static class LocationLoader
{
    public static Location? LoadLocationFromJson(string filePath) // Nullable return type
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Ignores case differences
        };

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Location>(json, options);
    }
}
