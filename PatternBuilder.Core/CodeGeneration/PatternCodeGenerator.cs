using PatternBuilder.Core.Interfaces.CodeGeneration;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Reflection;

namespace PatternBuilder.Core.CodeGeneration
{
    public static class PatternCodeGenerator
    {
        internal static Dictionary<PatternLanguages, IPatternCodeGenerator> _generators;

        static PatternCodeGenerator()
        {
            LoadCodeGenerators();
        }

        internal static void LoadCodeGenerators()
        {
            var pluginPath = @"..\..\..\..\PatternBuilder.CodeGeneration\bin\Debug\net8.0\PatternBuilder.CodeGeneration.dll";
            var assembly = Assembly.LoadFrom(pluginPath);
            var interfaceType = typeof(IPatternCodeGenerator);

            _generators = assembly
                .GetTypes()
                .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .Select(t => (IPatternCodeGenerator)Activator.CreateInstance(t))
                .ToDictionary(key => key.Language, value => value);
        }

        public static string Generate<T>(T primitive, PatternLanguages language) where T : IPatternPrimitive
        {
            return GetGenerator(language).Generate(primitive);
        }

        internal static IPatternCodeGenerator GetGenerator(PatternLanguages language)
        {
            if (_generators.TryGetValue(language, out IPatternCodeGenerator generator))
                return generator;

            throw new NotSupportedException($"Code generation for language '{language}' is not supported.");
        }
    }
}
