namespace PatternBuilder.Core.Primitives
{
    public class PatternParameter(string type, string name)
    {
        public string Type { get; private set; } = type;

        public string Name { get; private set; } = name;
    }
}
