using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGenerators.Languages.CSharp
{
    [PatternLanguage(PatternLanguages.CSharp)]
    internal sealed class CSharpInterfaceCodeGenerator : InterfaceCodeGeneratorBase
    {
        protected override void AddSignature(PatternInterface patternInterface)
        {
            AddString($"public interface {patternInterface.Name}");
            AddLine();
            AddLine("{");
        }

        protected override void AddProperties(PatternInterface patternInterface)
        {
            foreach (PatternParameter property in patternInterface.Properties)
                AddLine($"\t{property.Type} {property.Name} {{ get; set; }}");
        }

        protected override void AddMethods(PatternInterface patternInterface)
        {
            foreach (PatternMethod method in patternInterface.Methods)
            {
                AddLine(PatternCodeGenerator.Generate(method, Language));
                AddLine();
            }

            RemoveLastEmptyLine();
            AddLine("}");
        }
    }
}
