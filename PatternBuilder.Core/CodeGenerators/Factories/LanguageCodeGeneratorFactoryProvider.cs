using PatternBuilder.Core.CodeGenerators.Factories.Languages;
using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;
using PatternBuilder.Core.Interfaces.Factories;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.Factories
{
    public class LanguageCodeGeneratorFactoryProvider : ILanguageCodeGeneratorFactoryProvider
    {
        public ILanguageCodeGeneratorFactory GetFactory(PatternLanguages language)
        {
            return language switch
            {
                PatternLanguages.CSharp => new CSharpLanguageCodeGeneratorFactory(),
                PatternLanguages.Python => new PythonLanguageCodeGeneratorFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, $"Unsupported language: {language}.")
            };
        }
    }
}
