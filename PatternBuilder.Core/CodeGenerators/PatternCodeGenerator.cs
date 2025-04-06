using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;
using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Factories;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public class PatternCodeGenerator : BaseCodeGenerator, IPatternCodeGenerator
    {
        private readonly ILanguageCodeGeneratorFactoryProvider _languageCodeGeneratorFactoryProvider;

        public PatternCodeGenerator(ILanguageCodeGeneratorFactoryProvider languageCodeGeneratorFactoryProvider)
        {
            _languageCodeGeneratorFactoryProvider = languageCodeGeneratorFactoryProvider;
        }

        public string Generate(IPattern pattern, CodeGeneratorLanguages language)
        {
            ILanguageCodeGeneratorFactory languageCodeGeneratorFactory = _languageCodeGeneratorFactoryProvider.GetFactory(language);

            var classCodeGenerator = languageCodeGeneratorFactory.CreateClassCodeGenerator();
            var interfaceCodeGenerator = languageCodeGeneratorFactory.CreateInterfaceCodeGenerator();

            Clear();

            foreach (var patternClass in pattern.Classes)
            {
                AddLine(classCodeGenerator.Generate(patternClass));
            }

            foreach (var patternInterface in pattern.Interfaces)
            {
                AddLine(interfaceCodeGenerator.Generate(patternInterface));
            }

            return GetResult();
        }
    }
}
