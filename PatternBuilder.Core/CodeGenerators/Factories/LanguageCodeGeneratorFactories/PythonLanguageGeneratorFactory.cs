using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories.LanguageCodeGeneratorFactories
{
    public class PythonLanguageGeneratorFactory : ILanguageCodeGeneratorFactory
    {
        public BaseClassCodeGenerator CreateClassCodeGenerator()
        {
            throw new NotImplementedException();
        }

        public BaseInterfaceCodeGenerator CreateInterfaceCodeGenerator()
        {
            throw new NotImplementedException();
        }
    }
}
