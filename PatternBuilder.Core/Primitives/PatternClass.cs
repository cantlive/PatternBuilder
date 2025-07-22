using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternClass : IPatternPrimitive
    {
        internal ValidatingPatternPrimitiveContainer<PatternParameter> FieldContainer = new ValidatingPatternPrimitiveContainer<PatternParameter>(SystemName, "field");

        internal ValidatingPatternPrimitiveContainer<PatternMethod> MethodContainer = new ValidatingPatternPrimitiveContainer<PatternMethod>(SystemName);

        internal PatternClass() { }

        public static string SystemName => "class";

        public string Name { get; private set; }

        public string UniqueKey => Name;

        public IEnumerable<PatternParameter> Fields => FieldContainer.Items;

        public IEnumerable<PatternMethod> Methods => MethodContainer.Items;

        public bool IsAbstract { get; private set; }

        public string ParentClass { get; private set; }

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public void SetParentClass(string parentClass)
        {
            ParentClass = parentClass;
        }

        public void SetAbstract()
        {
            IsAbstract = true;
        }

        public void SetNonAbstract()
        {
            IsAbstract = false;
        }

        public void AddField(PatternParameter field) => FieldContainer.Add(field);

        public void RemoveField(PatternParameter parameter) => FieldContainer.Remove(parameter);

        public void AddMethod(PatternMethod method) => MethodContainer.Add(method);

        public void RemoveMethod(PatternMethod method) => MethodContainer.Remove(method);
    }
}
