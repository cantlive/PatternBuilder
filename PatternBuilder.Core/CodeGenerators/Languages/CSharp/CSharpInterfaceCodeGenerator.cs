using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.Languages.CSharp
{
    internal sealed class CSharpInterfaceCodeGenerator : BaseInterfaceCodeGenerator
    {
        public CSharpInterfaceCodeGenerator() : base(new CSharpMethodCodeGenerator()) { }

        protected override void AddSignature(PatternInterface patternInterface)
        {
            AddString($"public interface {patternInterface.Name}");
            AddLine();
            AddLine("{");
        }

        protected override void AddProperties(PatternInterface patternInterface)
        {
            foreach (PatternParameter property in patternInterface.Properties)
            {
                AddLine($"\t{property.Type} {property.Name} {{ get; set; }}");
            }
        }

        protected override void AddMethods(PatternInterface patternInterface)
        {
            foreach (PatternMethod method in patternInterface.Methods)
            {
                AddLine(_methodGenerator.Generate(method));
                AddLine();
            }

            RemoveLastEmptyLine();
            AddLine("}");
        }
    }
}
