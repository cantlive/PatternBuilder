using PatternBuilder.Core.CodeGenerators.Factories.Interfaces;
using PatternBuilder.Core.CodeGenerators.Factories.LanguageCodeGeneratorFactories;

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
