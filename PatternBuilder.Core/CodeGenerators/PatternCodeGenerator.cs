using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public class PatternCodeGenerator : BaseCodeGenerator, IPatternCodeGenerator
    {
        private readonly BaseClassCodeGenerator _classGenerator;
        private readonly BaseInterfaceCodeGenerator _interfaceGenerator;

        internal PatternCodeGenerator(BaseClassCodeGenerator classCodeGenerator, 
            BaseInterfaceCodeGenerator interfaceCodeGenerator)
        {
            _classGenerator = classCodeGenerator;
            _interfaceGenerator = interfaceCodeGenerator;
        }

        public string Generate(IPattern pattern)
        {
            Clear();

            foreach (var patternClass in pattern.Classes)
            {
                AddLine(_classGenerator.Generate(patternClass));
            }

            foreach (var patternInterface in pattern.Interfaces)
            {
                AddLine(_interfaceGenerator.Generate(patternInterface));
            }

            return GetResult();
        }
    }
}
