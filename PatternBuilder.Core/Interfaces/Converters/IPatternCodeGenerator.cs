using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Converters
{
    public interface IPatternCodeGenerator
    {
        string Generate(Pattern pattern, PatternLanguages language);
    }
}
