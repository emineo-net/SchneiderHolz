namespace Localization;

public class RestProvider : ILocalizationProvider
{
    private static string LocalizerUrl = "https://xxx.de/api/LocalizeText";

    public Dictionary<string, string> GetData(string locale, string sourcePath)
    {
        try
        {
            //var httpClient = new HttpClient();               
            //var response = httpClient.GetStringAsync(new Uri($"{LocalizerUrl}/{locale}")).Result;
            //return JsonSerializer.Deserialize<Dictionary<string, string>>(response);


            return new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            return new Dictionary<string, string>();
        }
    }
}