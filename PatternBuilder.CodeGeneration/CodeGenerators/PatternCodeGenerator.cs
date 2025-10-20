using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGenerators
{
    internal static class PatternCodeGenerator
    {
        internal static string Generate<T>(T primitive, PatternLanguages language)
            where T : IPatternPrimitive
        {
            var generator = GetGenerator<T>(language);
            return generator.Generate(primitive);
        }

        private static PatternPrimitiveCodeGeneratorBase<T> GetGenerator<T>(PatternLanguages language) 
            where T : IPatternPrimitive 
        {
            return CodeGeneratorRegistry.GetGenerator<T>(language);
        }
    }
}
