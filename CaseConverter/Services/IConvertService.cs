using System.Globalization;

namespace Slugify.Services;

public interface IConvertService
{
    public Task<string> ConvertSlugify(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls);
    public Task<string> ConvertUpperCase(string name,CultureInfo culture);
    public Task<string> ConvertLowerCase(string name,CultureInfo culture);
    public Task<string> ConvertCapitalizedCase(string name,CultureInfo culture);
}