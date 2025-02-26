using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Converters
{
    public interface IPatternConverter
    {
        string ConvertToString(IPatternClass patternClass);
        string ConvertToString(IPatternInterface patternInterface);
        string ConvertToString(IPatternMethod patternMethod);
    }
}
