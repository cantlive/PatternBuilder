namespace PatternBuilder.Core.CodeGenerators.Interfaces.Factories
{
    public interface ILanguageCodeGeneratorFactory
    {
        BaseClassCodeGenerator CreateClassCodeGenerator();
        BaseInterfaceCodeGenerator CreateInterfaceCodeGenerator();
    }
}
