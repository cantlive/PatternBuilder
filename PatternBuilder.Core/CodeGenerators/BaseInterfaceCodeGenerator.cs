using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseInterfaceCodeGenerator : BaseCodeGenerator
    {
        protected readonly BaseMethodCodeGenerator _methodGenerator;

        public BaseInterfaceCodeGenerator(BaseMethodCodeGenerator methodGenerator)
        {
            _methodGenerator = methodGenerator;
        }

        protected abstract void AddSignature(IPatternInterface patterninterface);
        protected abstract void AddProperties(IPatternInterface patterninterface);
        protected abstract void AddMethods(IPatternInterface patterninterface);

        public string Generate(IPatternInterface patterninterface)
        {
            Clear();

            AddSignature(patterninterface);
            AddProperties(patterninterface);
            AddMethods(patterninterface);

            return GetResult();
        }
    }
}
