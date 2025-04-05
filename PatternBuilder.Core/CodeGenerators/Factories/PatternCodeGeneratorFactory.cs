using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories
{
    public sealed class PatternCodeGeneratorFactory : BasePatternCodeGeneratorFactory<PatternCodeGenerator>
    {
        private readonly BasePatternCodeGeneratorFactory<ILanguageCodeGeneratorFactory> _languageCodeGeneratorFactory;

        public PatternCodeGeneratorFactory(BasePatternCodeGeneratorFactory<ILanguageCodeGeneratorFactory> languageCodeGeneratorFactory)
        {
            _languageCodeGeneratorFactory = languageCodeGeneratorFactory;
        }

        public override PatternCodeGenerator Create(CodeGeneratorLanguages language)
        {
            ILanguageCodeGeneratorFactory languageCodeGeneratorFactory = _languageCodeGeneratorFactory.Create(language);

            var classCodeGenerator = languageCodeGeneratorFactory.CreateClassCodeGenerator();
            var interfaceCodeGenerator = languageCodeGeneratorFactory.CreateInterfaceCodeGenerator();

            return new PatternCodeGenerator(classCodeGenerator, interfaceCodeGenerator);
        }
    }
}
