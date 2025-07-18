﻿using System.Text.RegularExpressions;

namespace Calabonga.Commandex.Engine.Extensions;

/// <summary>
/// Commandex Framework Engine extensions for <see cref="String"/>
/// </summary>
public static class StringExtensions
{
    private const string pascalPattern = "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])";

    public static string PascalToKebabCase(this string value)
    {
        return TransformWithDotNotation(value, PascalToKebabCaseInternal);
    }

    public static string PascalToSnakeCase(this string value)
    {
        return TransformWithDotNotation(value, PascalToSnakeCaseInternal);
    }

    private static string TransformWithDotNotation(string value, Func<string, string> transformer)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var substrings = value.Split(".").Select(transformer);

        return string.Join(".", substrings);
    }

    private static string PascalToKebabCaseInternal(string value)
    {
        return string.IsNullOrEmpty(value)
            ? value
            : Regex.Replace(value, pascalPattern, "-$1", RegexOptions.Compiled).Trim().ToLower();
    }

    private static string PascalToSnakeCaseInternal(string value)
    {
        return string.IsNullOrEmpty(value)
            ? value
            : Regex.Replace(value, pascalPattern, "_$1", RegexOptions.Compiled).Trim().ToLower();
    }

    public static string PascalToSnakeUpperCase(this string value)
    {
        return string.IsNullOrEmpty(value)
            ? value
            : Regex.Replace(value, pascalPattern, "_$1", RegexOptions.Compiled).Trim().ToUpper();
    }

    public static string PascalToKebabUpperCase(this string value)
    {
        return string.IsNullOrEmpty(value)
            ? value
            : Regex.Replace(value, pascalPattern, "-$1", RegexOptions.Compiled).Trim().ToUpper();
    }

    public static string ScreamingToPascalCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var substrings = value.ToLower()
            .Split('_')
            .Select(s => s[0].ToString().ToUpper() + s.Substring(1));

        return string.Join(null, substrings);
    }

    public static string SnakeToKebabCase(this string value)
    {
        return value.Replace("_", "-");
    }
}
