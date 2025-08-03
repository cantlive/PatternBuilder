using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class PatternPrimitiveCodeGeneratorBase<T> : CodeGeneratorBase
        where T : IPatternPrimitive
    {
        internal abstract string InternalGenerate(T patternPrimitive);

        internal string Generate(T patternPrimitive)
        {
            PatternValidator.ThrowIfNullArgument(patternPrimitive, T.SystemName);
            return InternalGenerate(patternPrimitive);
        }
    }
}
