using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Converters
{
    public interface IPatternCodeGenerator
    {
        string Generate(IPattern pattern, PatternLanguages language);
    }
}
