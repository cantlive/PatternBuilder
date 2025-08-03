using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.CodeGeneration
{
    public interface IPatternCodeGenerator
    {
        string Generate<T>(T primitive) where T : IPatternPrimitive;

        PatternLanguages Language { get; }
    }
}
