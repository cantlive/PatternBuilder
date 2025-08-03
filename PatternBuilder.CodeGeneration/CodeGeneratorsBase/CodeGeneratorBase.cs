using System.Text;

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal class CodeGeneratorBase
    {
        protected StringBuilder _stringBuilder = new StringBuilder();

        protected void AddLine(string line = "")
        {
            _stringBuilder.AppendLine(line);
        }

        protected void AddString(string value)
        {
            _stringBuilder.Append(value);
        }

        protected void AddTab()
        {
            AddString("\t");
        }

        protected void Clear()
        {
            _stringBuilder.Clear();
        }

        protected string GetResult()
        {
            return _stringBuilder.ToString();
        }

        protected void RemoveLastEmptyLine()
        {
            string newLine = Environment.NewLine;
            string result = _stringBuilder.ToString();

            if (result.EndsWith(newLine))
                _stringBuilder.Remove(result.Length - newLine.Length, newLine.Length);
        }
    }
}
