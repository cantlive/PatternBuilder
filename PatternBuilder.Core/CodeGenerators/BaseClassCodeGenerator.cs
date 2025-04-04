using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseClassCodeGenerator : BaseCodeGenerator
    {
        protected readonly BaseMethodCodeGenerator _methodGenerator;

        public BaseClassCodeGenerator(BaseMethodCodeGenerator methodGenerator)
        {
            _methodGenerator = methodGenerator;
        }

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
