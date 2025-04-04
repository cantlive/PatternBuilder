using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseMethodCodeGenerator : BaseCodeGenerator
    {
        protected abstract void AddSignature(IPatternMethod method);
        protected abstract void AddParameters(IPatternMethod method);
        protected abstract void AddBody(IPatternMethod method);

        public string Generate(IPatternMethod method)
        {
            Clear();

            AddSignature(method);
            AddParameters(method);
            AddBody(method);

            return GetResult();
        }
    }
}
