using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public class PatternCodeGenerator : IPatternCodeGenerator
    {
        private readonly PatternMethodCodeGenerator _methodConverter;
        private readonly PatternClassCodeGenerator _classConverter;
        private readonly PatternInterfaceCodeGenerator _interfaceConverter;

        public PatternCodeGenerator()
        {
            _methodConverter = new PatternMethodCodeGenerator();
            _classConverter = new PatternClassCodeGenerator(_methodConverter);
            _interfaceConverter = new PatternInterfaceCodeGenerator(_methodConverter);
        }

        public string Generate(IPatternMethod patternMethod)
        {
            return _methodConverter.Generate(patternMethod);
        }

        public string Generate(IPatternClass patternClass)
        {
            return _classConverter.ConvertToString(patternClass);
        }

        public string Generate(IPatternInterface patternInterface)
        {
            return _interfaceConverter.ConvertToString(patternInterface);
        }
    }
}
