namespace PatternBuilder.Core.Extensions
{
    internal static class StringExtensions
    {
        public static string ToUpperFirst(this string input) => string.IsNullOrWhiteSpace(input) 
            ? input 
            : char.ToUpper(input[0]) + input.Substring(1);

        public static string DefaultIfNullOrWhiteSpace(this string input, string defaultValue) => string.IsNullOrWhiteSpace(input) 
            ? defaultValue 
            : input;
    }
}
