using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternClass : IPatternClass
    {
        internal const string CONTAINER_NAME = "class";

        internal ValidatingParameterContainer FieldContainer = new ValidatingParameterContainer("field", CONTAINER_NAME);

        internal ValidatingMethodContainer MethodContainer = new ValidatingMethodContainer(CONTAINER_NAME);

        internal PatternClass() { }

        public string Name { get; private set; }

        public IEnumerable<PatternParameter> Fields => FieldContainer.Items;

        public IEnumerable<IPatternMethod> Methods => MethodContainer.Items;

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

        public void RemoveField(string name) => FieldContainer.Remove(name);

        public void AddMethod(IPatternMethod method) => MethodContainer.Add(method);

        public void RemoveMethod(string signature) => MethodContainer.Remove(signature);
    }
}
