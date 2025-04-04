namespace PatternBuilder.Core.CodeGenerators.Factories.Interfaces
{
    public interface ILanguageCodeGeneratorFactory
    {
        BaseClassCodeGenerator CreateClassCodeGenerator();
        BaseInterfaceCodeGenerator CreateInterfaceCodeGenerator();
    }
}
