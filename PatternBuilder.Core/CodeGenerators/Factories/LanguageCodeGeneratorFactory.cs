using PatternBuilder.Core.CodeGenerators.Factories.LanguageCodeGeneratorFactories;
using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories
{
    public class LanguageCodeGeneratorFactory : BasePatternCodeGeneratorFactory<ILanguageCodeGeneratorFactory>
    {
        public override ILanguageCodeGeneratorFactory Create(CodeGeneratorLanguages language)
        {
            return language switch
            {
                CodeGeneratorLanguages.CSharp => new CSharpLanguageGeneratorFactory(),
                CodeGeneratorLanguages.Python => new PythonLanguageGeneratorFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, $"Unsupported language: {language}")
            };
        }
    }
}
