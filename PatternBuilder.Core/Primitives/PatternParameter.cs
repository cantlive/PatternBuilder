using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternParameter
    {
        public string Type { get; private set; }

        public string Name { get; private set; }

        public PatternParameter(string type, string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));

            Type = type;
            Name = name;
        }
    }
}
