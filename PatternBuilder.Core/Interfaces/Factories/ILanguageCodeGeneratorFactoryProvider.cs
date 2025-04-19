using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Factories
{
    public interface ILanguageCodeGeneratorFactoryProvider
    {
        ILanguageCodeGeneratorFactory GetFactory(PatternLanguages language);
    }
}
