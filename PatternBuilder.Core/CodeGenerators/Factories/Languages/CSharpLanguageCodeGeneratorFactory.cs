using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;
using PatternBuilder.Core.CodeGenerators.Languages.CSharp;

namespace PatternBuilder.Core.CodeGenerators.Factories.Languages
{
    internal class CSharpLanguageCodeGeneratorFactory : ILanguageCodeGeneratorFactory
    {
        public BaseClassCodeGenerator CreateClassCodeGenerator() => new CSharpClassCodeGenerator();

        public BaseInterfaceCodeGenerator CreateInterfaceCodeGenerator() => new CSharpInterfaceCodeGenerator();
    }
}
