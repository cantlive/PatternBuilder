using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal sealed class CodeGeneratorRegistry
    {
        private readonly Dictionary<Type, object> _generators = new Dictionary<Type, object>();

        public void RegisterGenerator<T>(PatternPrimitiveCodeGeneratorBase<T> generator) where T : IPatternPrimitive
        {
            PatternValidator.ThrowIfNullArgument(generator, nameof(generator));
            _generators[typeof(T)] = generator;
        }

        public PatternPrimitiveCodeGeneratorBase<T> GetGenerator<T>() where T : IPatternPrimitive
        {
            if (_generators.TryGetValue(typeof(T), out var generator))
                return (PatternPrimitiveCodeGeneratorBase<T>)generator;

            throw new KeyNotFoundException($"No generator registered for type {typeof(T).Name}");
        }
    }
}
