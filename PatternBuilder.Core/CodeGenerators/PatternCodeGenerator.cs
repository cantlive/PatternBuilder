using PatternBuilder.Core.CodeGenerators.CSharpGenerators;
using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    public class PatternCodeGenerator : IPatternCodeGenerator
    {
        private readonly CSharpMethodCodeGenerator _methodGenerator;
        private readonly CSharpClassCodeGenerator _classGenerator;
        private readonly CSharpInterfaceCodeGenerator _interfaceConverter;

        public PatternCodeGenerator()
        {
            _methodGenerator = new CSharpMethodCodeGenerator();
            _classGenerator = new CSharpClassCodeGenerator(_methodGenerator);
            _interfaceConverter = new CSharpInterfaceCodeGenerator(_methodGenerator);
        }

        public string Generate(IPatternMethod patternMethod)
        {
            return _methodGenerator.Generate(patternMethod);
        }

        public string Generate(IPatternClass patternClass)
        {
            return _classGenerator.Generate(patternClass);
        }

        public string Generate(IPatternInterface patternInterface)
        {
            return _interfaceConverter.Generate(patternInterface);
        }
    }
}
