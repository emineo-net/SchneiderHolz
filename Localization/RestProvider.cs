namespace Localization;

public class RestProvider : ILocalizationProvider
{
    private static string LocalizerUrl = "https://xxx.de/api/LocalizeText";

    public List<Localize> GetData(string locale, string sourcePath)
    {
        try
        {
            //var httpClient = new HttpClient();               
            //var response = httpClient.GetStringAsync(new Uri($"{LocalizerUrl}/{locale}")).Result;
            //return JsonSerializer.Deserialize<Dictionary<string, string>>(response);


            return new List<Localize>();
        }
        catch (Exception ex)
        {
            return new List<Localize>();
        }
    }
}