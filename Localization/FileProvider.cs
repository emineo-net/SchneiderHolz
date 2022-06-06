using System.Text.Json;

namespace Localization;

public class FileProvider : ILocalizationProvider
{
    public List<Localize> GetData(string locale, string sourcePath)
    {
        try
        {
            var file = Path.Combine(".", "wwwroot", "local", $"locale.{locale}.json");
            var jsonCode = File.ReadAllText(file);
            var dict = JsonSerializer.Deserialize<List<Localize>>(jsonCode);
            return dict;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Localize>();
        }
    }
}