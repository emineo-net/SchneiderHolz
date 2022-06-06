namespace Localization;

public interface ILocalizationProvider
{
    List<Localize> GetData(string locale, string sourcePath);
}