using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternInterface : IPatternPrimitive
    {
        internal ValidatingPatternPrimitiveContainer<PatternParameter> PropertyContainer = new ValidatingPatternPrimitiveContainer<PatternParameter>(SystemName, "property");

        internal ValidatingPatternPrimitiveContainer<PatternMethod> MethodContainer = new ValidatingPatternPrimitiveContainer<PatternMethod>(SystemName);

        internal PatternInterface() { }

        public static string SystemName => "interface";

        public string Name { get; private set; }

        public string UniqueKey => Name;

        public IEnumerable<PatternMethod> Methods => MethodContainer.Items;

        public IEnumerable<PatternParameter> Properties => PropertyContainer.Items;

        public void AddProperty(PatternParameter property) => PropertyContainer.Add(property);

        public void RemoveProperty(PatternParameter parameter) => PropertyContainer.Remove(parameter);

        public void AddMethod(PatternMethod method) => MethodContainer.Add(method);

        public void RemoveMethod(PatternMethod method) => MethodContainer.Remove(method);

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }
}
