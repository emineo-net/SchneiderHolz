namespace Localization;

public interface ILocalizer
{
    string this[string idx] => GetString(idx);
    string GetString(string idx);
    void SetLocale(string locale);
    List<Localize> GetAll(string locale);
}