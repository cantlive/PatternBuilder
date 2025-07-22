using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseClassCodeGenerator : BaseCodeGenerator
    {
        protected readonly BaseMethodCodeGenerator _methodGenerator;

        public BaseClassCodeGenerator(BaseMethodCodeGenerator methodGenerator)
        {
            _methodGenerator = methodGenerator;
        }

        protected abstract void AddSignature(PatternClass patternClass);
        protected abstract void AddFields(PatternClass patternClass);
        protected abstract void AddMethods(PatternClass patternClass);

        public string Generate(PatternClass patternClass)
        {
            Clear();

            AddSignature(patternClass);
            AddFields(patternClass);
            AddMethods(patternClass);

            return GetResult();
        }
    }
}
