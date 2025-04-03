using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    internal abstract class BaseInterfaceCodeGenerator : BasePatternCodeGenerator
    {
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
