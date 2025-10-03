using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation;
using System.Reflection;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal abstract class PatternPrimitiveCodeGeneratorBase<T> : CodeGeneratorBase
        where T : IPatternPrimitive
    {
        private PatternLanguages? _language;
    
        internal virtual PatternLanguages Language
        {
            get
            {
                if (_language == null)
                {
                    var attribute = GetType().GetCustomAttribute<PatternLanguageAttribute>();
                    _language = attribute?.Language ?? throw new InvalidOperationException("PatternLanguage attribute not found");
                }

                return _language.Value;
            }
        }

        internal abstract string InternalGenerate(T patternPrimitive);

        internal string Generate(T patternPrimitive)
        {
            PatternValidator.ThrowIfNullArgument(patternPrimitive, T.SystemName);
            return InternalGenerate(patternPrimitive);
        }
    }
}
