using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Converters
{
    public interface IPatternCodeGenerator
    {
        string Generate(IPattern pattern, CodeGeneratorLanguages language);
    }
}
