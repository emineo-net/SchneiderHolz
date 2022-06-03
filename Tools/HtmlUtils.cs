using System.Web;

namespace Tools;

public static class HtmlUtils
{
    public static string DecodeHtml(this string html)
    {
        return HttpUtility.HtmlDecode(html);
    }

    public static string EncodeHtml(this string sourceString)
    {
        return HttpUtility.HtmlEncode(sourceString);
    }
}
