using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.Interfaces.CodeGeneration;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGenerators.Languages.CSharp
{
    public sealed class CSharpPatternCodeGenerator : IPatternCodeGenerator
    {
        private readonly LanguageCodeGeneratorBase _internalGenerator;

        public CSharpPatternCodeGenerator()
        {
            _internalGenerator = new InternalCSharpPatternCodeGenerator();
        }

        public PatternLanguages Language => _internalGenerator.Language;

        public string Generate<T>(T primitive) where T : IPatternPrimitive
        {
            return _internalGenerator.Generate(primitive);
        }

        private class InternalCSharpPatternCodeGenerator : LanguageCodeGeneratorBase
        {
            public override PatternLanguages Language => PatternLanguages.CSharp;

            protected override void RegisterGenerators()
            {
                GeneratorRegistry.RegisterGenerator(new CSharpMethodCodeGenerator());
                GeneratorRegistry.RegisterGenerator(new CSharpClassCodeGenerator(GeneratorRegistry));
                GeneratorRegistry.RegisterGenerator(new CSharpInterfaceCodeGenerator(GeneratorRegistry));
                GeneratorRegistry.RegisterGenerator(new PatternPrimitiveCodeGenerator(GeneratorRegistry));
            }
        }
    }
}
