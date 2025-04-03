using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    internal abstract class BaseClassCodeGenerator : BasePatternCodeGenerator
    {
        protected abstract void AddSignature(IPatternClass patternClass);
        protected abstract void AddFields(IPatternClass patternClass);
        protected abstract void AddMethods(IPatternClass patternClass);

        public string Generate(IPatternClass patternClass)
        {
            Clear();

            AddSignature(patternClass);
            AddFields(patternClass);
            AddMethods(patternClass);

            return GetResult();
        }
    }
}
