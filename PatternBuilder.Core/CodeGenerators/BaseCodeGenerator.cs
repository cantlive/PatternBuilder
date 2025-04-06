using System.Text;

namespace PatternBuilder.Core.CodeGenerators
{
    public class BaseCodeGenerator
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

        protected void Clear()
        {
            _stringBuilder.Clear();
        }

        protected string GetResult()
        {
            return _stringBuilder.ToString();
        }

        protected void RemoveLastLine()
        {
            int lastIndex = _stringBuilder.ToString().LastIndexOf('\n');
            if (lastIndex >= 0)
                _stringBuilder.Remove(lastIndex, _stringBuilder.Length - lastIndex);
        }
    }
}
