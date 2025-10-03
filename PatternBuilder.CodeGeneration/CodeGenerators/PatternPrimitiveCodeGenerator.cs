using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    internal sealed class PatternPrimitiveCodeGenerator : PatternPrimitiveCodeGeneratorBase<Pattern>
    {
        private readonly PatternLanguages _language;

        internal PatternPrimitiveCodeGenerator(PatternLanguages language)
        {
            _language = language;
        }

        internal override PatternLanguages Language => _language;

        internal override string InternalGenerate(Pattern pattern)
        {
            Clear();

            AddString(pattern.Name);
            if (pattern.Classes.Count() > 0 || pattern.Interfaces.Count() > 0)
            {
                AddLine();
                AddLine();
            }

            foreach (var patternClass in pattern.Classes)
                AddLine(PatternCodeGenerator.Generate(patternClass, _language));

            foreach (var patternInterface in pattern.Interfaces)
                AddLine(PatternCodeGenerator.Generate(patternInterface, _language));

            return GetResult();
        }
    }
}
