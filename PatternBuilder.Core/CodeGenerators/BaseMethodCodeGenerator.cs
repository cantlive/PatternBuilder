using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public abstract class BaseMethodCodeGenerator : BaseCodeGenerator
    {
        protected abstract void AddSignature(PatternMethod method);
        protected abstract void AddParameters(PatternMethod method);
        protected abstract void AddBody(PatternMethod method);

        public string Generate(PatternMethod method)
        {
            Clear();

            AddSignature(method);
            AddParameters(method);
            AddBody(method);

            return GetResult();
        }
    }
}
