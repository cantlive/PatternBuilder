using PatternBuilder.Core.CodeGenerators.Factories.Languages;
using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;
using PatternBuilder.Core.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories
{
    public class LanguageCodeGeneratorFactoryProvider : ILanguageCodeGeneratorFactoryProvider
    {
        public ILanguageCodeGeneratorFactory GetFactory(CodeGeneratorLanguages language)
        {
            return language switch
            {
                CodeGeneratorLanguages.CSharp => new CSharpLanguageCodeGeneratorFactory(),
                CodeGeneratorLanguages.Python => new PythonLanguageCodeGeneratorFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, $"Unsupported language: {language}")
            };
        }
    }
}
