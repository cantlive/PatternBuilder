using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Converters
{
    internal class MethodConverter  :BaseConverter
    {
        public string ConvertToString(IPatternMethod patternMethod)
        {
            Clear();

            AddTab();
            AddSignature(patternMethod);
            AddParameters(patternMethod);
            AddClassMethodBody(patternMethod);
            AddSemicolon(patternMethod);

            return GetResult();
        }

        private void AddSignature(IPatternMethod patternMethod)
        {
            string abstractMethodDefinition = patternMethod.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractMethodDefinition} {patternMethod.ReturnType} {patternMethod.Name}");
        }

        private void AddParameters(IPatternMethod patternMethod)
        {
            AddString("(");
            AddString(string.Join(", ", patternMethod.Parameters.Select(p => $"{p.Type} {p.Name}")));
            AddString(")");
        }

        private void AddClassMethodBody(IPatternMethod patternMethod)
        {
            if (!patternMethod.HasImplementation)
                return;

            AddLine();
            AddTab();
            AddLine("{");
            AddMethodBody(patternMethod);
            AddTab();
            AddLine("}");
        }

        private void AddMethodBody(IPatternMethod patternMethod)
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

        private void AddSemicolon(IPatternMethod patternMethod)
        {
            if (!patternMethod.HasImplementation)
                AddString(";");
        }

        private void AddTab()
        {
            AddString("\t");
        }
    }
}
