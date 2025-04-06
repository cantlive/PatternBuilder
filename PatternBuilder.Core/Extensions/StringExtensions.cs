namespace PatternBuilder.Core.Extensions
{
    internal static class StringExtensions
    {
        public static string ToUpperFirst(this string input) => string.IsNullOrEmpty(input) 
            ? input 
            : char.ToUpper(input[0]) + input.Substring(1);
    }
}
