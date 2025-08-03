using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("PatternBuilder.Tests")]

namespace PatternBuilder.CodeGeneration.CodeGeneratorsBase
{
    internal class CodeGeneratorBase
    {
        protected StringBuilder _stringBuilder = new StringBuilder();

        internal void AddLine(string line = "")
        {
            _stringBuilder.AppendLine(line);
        }

        internal void AddString(string value)
        {
            _stringBuilder.Append(value);
        }

        internal void AddTab()
        {
            AddString("\t");
        }

        internal void Clear()
        {
            _stringBuilder.Clear();
        }

        internal string GetResult()
        {
            return _stringBuilder.ToString();
        }

        internal void RemoveLastEmptyLine()
        {
            string newLine = Environment.NewLine;
            string result = _stringBuilder.ToString();

            if (result.EndsWith(newLine))
                _stringBuilder.Remove(result.Length - newLine.Length, newLine.Length);
        }
    }
}
