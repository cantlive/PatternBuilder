using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternParameter : PatternPrimitiveBase, IPatternPrimitive
    {
        public static string SystemName => "parameter";

        public static string DefaultName => "param1";

        public string Type { get; private set; }

        public PatternParameter(string name) : base(name) { }

        public PatternParameter(string name, string type) : base(name)
        {
            Type = type;
        }

        public void SetType(string type)
        {
            Type = type;
        }
    }
}
