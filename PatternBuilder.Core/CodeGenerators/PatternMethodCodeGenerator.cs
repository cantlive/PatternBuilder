using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    internal sealed class PatternMethodCodeGenerator : BaseMethodCodeGenerator
    {
        protected override void AddSignature(IPatternMethod patternMethod)
        {
            AddTab();
            string abstractMethodDefinition = patternMethod.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractMethodDefinition} {patternMethod.ReturnType} {patternMethod.Name}");
        }

        protected override void AddParameters(IPatternMethod patternMethod)
        {
            AddString("(");
            AddString(string.Join(", ", patternMethod.Parameters.Select(p => $"{p.Type} {p.Name}")));
            AddString(")");
        }

        protected override void AddBody(IPatternMethod patternMethod)
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

        private void AddBodyContent(IPatternMethod patternMethod)
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

        private void AddTab()
        {
            AddString("\t");
        }
    }
}
