using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.CodeGeneration.CodeGenerators.Languages.CSharp
{
    internal sealed class CSharpMethodCodeGenerator : MethodCodeGeneratorBase
    {
        protected override void AddSignature(PatternMethod patternMethod)
        {
            AddTab();
            string abstractMethodDefinition = patternMethod.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractMethodDefinition} {patternMethod.ReturnType} {patternMethod.Name}");
        }

        protected override void AddParameters(PatternMethod patternMethod)
        {
            AddString("(");
            AddString(string.Join(", ", patternMethod.Parameters.Select(p => $"{p.Type} {p.Name}")));
            AddString(")");
        }

        protected override void AddBody(PatternMethod patternMethod)
        {
            if (!patternMethod.HasImplementation)
            {
                AddString(";");
                return;
            }

            AddLine();
            AddTab();
            AddLine("{");
            AddBodyContent(patternMethod);
            AddTab();
            AddLine("}");
        }

        private void AddBodyContent(PatternMethod patternMethod)
        {
            if (string.IsNullOrWhiteSpace(patternMethod.Body))
                return;

            foreach (string row in patternMethod.Body.Split(Environment.NewLine))
            {
                AddTab();
                AddTab();
                AddLine(row);
            }
        }
    }
}
