using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.Interfaces.Factories
{
    public interface ILanguageCodeGeneratorFactoryProvider
    {
        ILanguageCodeGeneratorFactory GetFactory(CodeGeneratorLanguages language);
    }
}
