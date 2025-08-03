using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class InterfaceCodeGeneratorBase : PatternPrimitiveCodeGeneratorBase<PatternInterface>
    {
        protected readonly LanguageCodeGeneratorRegistry _generatorRegistry;

        public InterfaceCodeGeneratorBase(LanguageCodeGeneratorRegistry generatorRegistry)
        {
            _generatorRegistry = generatorRegistry;
        }

        protected abstract void AddSignature(PatternInterface patterninterface);
        protected abstract void AddProperties(PatternInterface patterninterface);
        protected abstract void AddMethods(PatternInterface patterninterface);

        internal override string InternalGenerate(PatternInterface patterninterface)
        {
            Clear();

            AddSignature(patterninterface);
            AddProperties(patterninterface);
            AddMethods(patterninterface);

            return GetResult();
        }
    }
}
