using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class LanguageCodeGeneratorBase
    {
        public abstract PatternLanguages Language { get; }

        protected LanguageCodeGeneratorBase()
        {
            RegisterGenerators();
        }

        protected abstract void RegisterGenerators();

        public string Generate<T>(T primitive) where T : IPatternPrimitive
        {
            return PatternCodeGenerator.Generate(primitive, Language);
        }
    }
}
