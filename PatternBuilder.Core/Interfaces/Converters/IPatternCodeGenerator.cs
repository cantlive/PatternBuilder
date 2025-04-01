using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Converters
{
    public interface IPatternCodeGenerator
    {
        string Generate(IPatternClass patternClass);
        string Generate(IPatternInterface patternInterface);
        string Generate(IPatternMethod patternMethod);
    }
}
