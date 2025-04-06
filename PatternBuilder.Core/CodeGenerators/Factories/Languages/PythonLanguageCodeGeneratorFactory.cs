using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories.Languages
{
    public class PythonLanguageCodeGeneratorFactory : ILanguageCodeGeneratorFactory
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
