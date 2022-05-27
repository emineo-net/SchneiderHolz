using System.Collections.Generic;
using System.Threading.Tasks;

namespace Localization
{
    public interface ILocalizationProvider
    {
        Dictionary<string, string> GetData(string locale, string sourcePath);
    }
}
