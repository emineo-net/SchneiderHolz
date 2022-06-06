using System.Globalization;

namespace Localization;

public class Localizer : ILocalizer
{
    private readonly ILocalizationProvider _localizationProvider;


    private List<Localize> _data;
    private string _loadedLocale = string.Empty;
    private string _requestetLocale = "de";

    public Localizer()
    {
        //_localizationProvider = new RestProvider();
        _localizationProvider = new FileProvider();
    }

    public Localizer(ILocalizationProvider provider)
    {
        _localizationProvider = provider;
    }

    public string this[string idx] => GetString(idx);


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
        return _data.Where(i => i.Key == idx).Select(v => v.Value).FirstOrDefault() ?? $"#{idx}";
    }

    public void SetLocale(string locale)
    {
        _requestetLocale = locale;
        _data = _localizationProvider.GetData(locale, null);
    }

    public List<Localize> GetAll(string locale)
    {
        if (string.IsNullOrEmpty(locale))
            return null;

        var name = locale.Split('-')[0];
        var data = Task.Run(() => _localizationProvider.GetData(name, null)).Result;
        return data;
    }
}