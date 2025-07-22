using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternParameter : IPatternPrimitive
    {
        public static string SystemName => "parameter";

        public string Name { get; private set; }

        public string UniqueKey => Name;

        public string Type { get; private set; }

        public PatternParameter(string type, string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));

            Type = type;
            Name = name;
        }
    }
}
