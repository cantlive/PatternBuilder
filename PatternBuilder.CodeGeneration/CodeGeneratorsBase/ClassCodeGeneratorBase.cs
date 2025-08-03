using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class ClassCodeGeneratorBase : PatternPrimitiveCodeGeneratorBase<PatternClass>
    {
        protected readonly CodeGeneratorRegistry _generatorRegistry;

        public ClassCodeGeneratorBase(CodeGeneratorRegistry generatorRegistry)
        {
            _generatorRegistry = generatorRegistry;
        }

        protected abstract void AddSignature(PatternClass patternClass);
        protected abstract void AddFields(PatternClass patternClass);
        protected abstract void AddMethods(PatternClass patternClass);

        internal override string InternalGenerate(PatternClass patternClass)
        {
            Clear();

            AddSignature(patternClass);
            AddFields(patternClass);
            AddMethods(patternClass);

            return GetResult();
        }
    }
}
