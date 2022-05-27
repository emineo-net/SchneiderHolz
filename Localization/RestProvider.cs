using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Localization
{

    public class RestProvider : ILocalizationProvider
    {

        private static string LocalizerUrl = "https://localize.xenia-pos.net/api/LocalizeText";

        public RestProvider()
        {

        }

        public Dictionary<string, string> GetData(string locale, string sourcePath)
        {
            try
            {
                //var httpClient = new HttpClient();               
                //var response = httpClient.GetStringAsync(new Uri($"{LocalizerUrl}/{locale}")).Result;
                //return JsonSerializer.Deserialize<Dictionary<string, string>>(response);



                return new Dictionary<string, string>();
            }
            catch(Exception ex)
            {
                return new Dictionary<string, string>();
            }
        }

    }
}
