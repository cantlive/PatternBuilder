using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.CSharpGenerators
{
    internal sealed class CSharpInterfaceCodeGenerator : BaseInterfaceCodeGenerator
    {
        private readonly CSharpMethodCodeGenerator _methodConverter;

        public CSharpInterfaceCodeGenerator(CSharpMethodCodeGenerator methodConverter)
        {
            _methodConverter = methodConverter;
        }

        protected override void AddSignature(IPatternInterface patternInterface)
        {
            AddString($"public interface {patternInterface.Name}");
            AddLine();
            AddLine("{");
        }

        protected override void AddProperties(IPatternInterface patternInterface)
        {
            foreach (PatternParameter property in patternInterface.Properties)
            {
                AddLine($"\t{property.Type} {property.Name} {{ get; set; }}");
            }
        }

        protected override void AddMethods(IPatternInterface patternInterface)
        {
            foreach (IPatternMethod method in patternInterface.Methods)
            {
                AddLine(_methodConverter.Generate(method));
                AddLine();
            }

            AddLine("}");
        }
    }
}
