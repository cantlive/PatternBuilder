using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.CodeGenerators
{
    internal sealed class PatternPrimitiveCodeGenerator : PatternPrimitiveCodeGeneratorBase<Pattern>
    {
        private readonly CodeGeneratorRegistry _generatorRegistry;

        internal PatternPrimitiveCodeGenerator(CodeGeneratorRegistry generatorRegistry)
        {
            PatternValidator.ThrowIfNullArgument(generatorRegistry, nameof(generatorRegistry));
            _generatorRegistry = generatorRegistry;
        }

        internal override string InternalGenerate(Pattern pattern)
        {
            Clear();

            AddString(pattern.Name);
            if (pattern.Classes.Count() > 0 && pattern.Interfaces.Count() > 0)
                AddLine();

            foreach (var patternClass in pattern.Classes)
                AddLine(_generatorRegistry.GetGenerator<PatternClass>().Generate(patternClass));

            foreach (var patternInterface in pattern.Interfaces)
                AddLine(_generatorRegistry.GetGenerator<PatternInterface>().Generate(patternInterface));

            return GetResult();
        }
    }
}
