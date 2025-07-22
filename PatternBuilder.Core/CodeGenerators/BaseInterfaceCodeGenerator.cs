using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseInterfaceCodeGenerator : BaseCodeGenerator
    {
        protected readonly BaseMethodCodeGenerator _methodGenerator;

        public BaseInterfaceCodeGenerator(BaseMethodCodeGenerator methodGenerator)
        {
            _methodGenerator = methodGenerator;
        }

        protected abstract void AddSignature(PatternInterface patterninterface);
        protected abstract void AddProperties(PatternInterface patterninterface);
        protected abstract void AddMethods(PatternInterface patterninterface);

        public string Generate(PatternInterface patterninterface)
        {
            Clear();

            AddSignature(patterninterface);
            AddProperties(patterninterface);
            AddMethods(patterninterface);

            return GetResult();
        }
    }
}
