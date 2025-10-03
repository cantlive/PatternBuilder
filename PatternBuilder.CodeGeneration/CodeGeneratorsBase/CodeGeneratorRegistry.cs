using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation;
using System.Reflection;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal static class CodeGeneratorRegistry
    {
        private static readonly Dictionary<GeneratorKey, object> _generators = new Dictionary<GeneratorKey, object>();

        public static int Count => _generators.Count;

        public static void RegisterGenerator<T>(PatternPrimitiveCodeGeneratorBase<T> generator) where T : IPatternPrimitive
        {
            PatternValidator.ThrowIfNullArgument(generator, nameof(generator));
            _generators[new GeneratorKey(typeof(T), generator.Language)] = generator;
        }

        public static void RegisterGeneratorsFor(PatternLanguages language)
        {
            var generatorTypes = FindGeneratorsByLanguage(language);

            foreach (var type in generatorTypes)
            {
                object generator = null;
                Type primitiveType = GetPatternPrimitiveType(type);

                if (primitiveType == typeof(Pattern))
                    generator = Activator.CreateInstance(type, language);
                else
                    generator = Activator.CreateInstance(type);

                if (generator != null && primitiveType != null)
                    _generators[new GeneratorKey(primitiveType, language)] = generator;
            }
        }

        public static PatternPrimitiveCodeGeneratorBase<T> GetGenerator<T>(PatternLanguages language) where T : IPatternPrimitive
        {
            if (_generators.TryGetValue(new GeneratorKey(typeof(T), language), out var generator))
                return (PatternPrimitiveCodeGeneratorBase<T>)generator;

            throw new KeyNotFoundException($"No generator registered for type {T.SystemName}");
        }

        public static void Clear()
        {
            _generators.Clear();
        }

        private static IEnumerable<Type> FindGeneratorsByLanguage(PatternLanguages language)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(IsPatternPrimitiveGenerator)
                .Where(t => t.GetCustomAttribute<PatternLanguageAttribute>()?.Language == language ||
                            t.GetCustomAttribute<PatternLanguageAttribute>()?.Language == PatternLanguages.Any);
        }

        private static bool IsPatternPrimitiveGenerator(Type type)
        {
            return GetPatternPrimitiveType(type) != null;
        }

        private static Type GetPatternPrimitiveType(Type type)
        {
            var currentType = type;
            while (currentType != null && currentType != typeof(object))
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(PatternPrimitiveCodeGeneratorBase<>))
                    return currentType.GetGenericArguments()[0];

                currentType = currentType.BaseType;
            }

            return null;
        }

        private record GeneratorKey(Type PrimitiveType, PatternLanguages Language);
    }
}
