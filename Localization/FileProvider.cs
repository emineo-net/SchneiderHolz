using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Localization
{
    public class FileProvider : ILocalizationProvider
    {

        public FileProvider()
        {

        }

        public Dictionary<string, string> GetData(string locale, string sourcePath)
        {
            try
            {
                var file = Path.Combine(".", "wwwroot", "local", $"locale_{locale}.json");
                var jsonCode = File.ReadAllText(file);
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonCode);
                return dict;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Dictionary<string, string>();
            }
        }

    
    }
}
