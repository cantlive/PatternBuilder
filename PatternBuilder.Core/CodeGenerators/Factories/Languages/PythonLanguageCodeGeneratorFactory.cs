using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories.Languages
{
    internal class PythonLanguageCodeGeneratorFactory : ILanguageCodeGeneratorFactory
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
