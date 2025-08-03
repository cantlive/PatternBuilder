using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class LanguageCodeGeneratorBase
    {
        protected readonly LanguageCodeGeneratorRegistry GeneratorRegistry;

        public abstract PatternLanguages Language { get; }

        protected LanguageCodeGeneratorBase(LanguageCodeGeneratorRegistry generatorRegistry = null)
        {
            GeneratorRegistry = generatorRegistry ?? new LanguageCodeGeneratorRegistry();
            RegisterGenerators();
        }

        protected abstract void RegisterGenerators();

        public string Generate<T>(T primitive) where T : IPatternPrimitive
        {
            var generator = GeneratorRegistry.GetGenerator<T>();
            return generator.Generate(primitive);
        }
    }
}
