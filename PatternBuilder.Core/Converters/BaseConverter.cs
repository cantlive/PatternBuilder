using System.Text;

namespace PatternBuilder.Core.Converters
{
    internal class BaseConverter
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
    }
}
