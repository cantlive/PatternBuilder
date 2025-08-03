using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class MethodCodeGeneratorBase : PatternPrimitiveCodeGeneratorBase<PatternMethod>
    {
        protected abstract void AddSignature(PatternMethod method);
        protected abstract void AddParameters(PatternMethod method);
        protected abstract void AddBody(PatternMethod method);

        internal override string InternalGenerate(PatternMethod method)
        {
            Clear();

            AddSignature(method);
            AddParameters(method);
            AddBody(method);

            return GetResult();
        }
    }
}
