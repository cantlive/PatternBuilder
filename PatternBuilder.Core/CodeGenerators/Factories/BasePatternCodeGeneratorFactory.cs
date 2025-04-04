namespace PatternBuilder.Core.CodeGenerators.Factories
{
    public abstract class BasePatternCodeGeneratorFactory<T> where T : class
    {
        public abstract T Create(CodeGeneratorLanguages language);
    }
}
