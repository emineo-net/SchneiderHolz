using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Localization
{

    public class Localizer : ILocalizer
    {


        private Dictionary<string, string> _data = null;
        private string _loadedLocale = string.Empty;
        private string _requestetLocale = "de";

        private readonly ILocalizationProvider _localizationProvider;

        public string this[string idx] => GetString(idx);

        public Localizer()
        {
            _localizationProvider = new RestProvider();
        }

        public Localizer(ILocalizationProvider provider)
        {
            _localizationProvider = provider;
        }


        public string GetString(string idx)
        {
            if (_data == null || _loadedLocale != CultureInfo.CurrentCulture.Name)
            {
                Console.WriteLine($"GetString: {CultureInfo.CurrentCulture.Name}");
                var cultureName = CultureInfo.CurrentCulture.Name;
                var name = cultureName.Split('-')[0];
                _data = _localizationProvider.GetData(name, null);
                _loadedLocale = CultureInfo.CurrentCulture.Name;
            }

            if (_data.TryGetValue(idx, out string result))
            {
                if(result == "")
                {
                    result = ">>" + idx;
                }
                return result;
            }
            return $">>{idx}";
        }

        public void SetLocale(string locale)
        {
            _requestetLocale = locale;
            _data = _localizationProvider.GetData(locale, null);
        }

        public Dictionary<string, string> GetAll(string locale)
        {
            if (string.IsNullOrEmpty(locale))
                return null;

            var name = locale.Split('-')[0];
            var data = Task.Run(() => _localizationProvider.GetData(name, null)).Result;
            return data;
        }
    }
}
