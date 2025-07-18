using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Calabonga.Commandex.Engine.Extensions;

/// <summary>
/// JsonSerializer Options helper for Cyrillic settings
/// </summary>
public static class JsonSerializerOptionsExt
{
    /// <summary>
    /// Returns JsonSerializer instance with special settings
    /// </summary>
    public static JsonSerializerOptions Cyrillic
    {
        get
        {
            return new() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true, PropertyNameCaseInsensitive = true };
        }
    }
}
