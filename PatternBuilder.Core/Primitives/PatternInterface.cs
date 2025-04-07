using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternInterface : IPatternInterface
    {
        internal const string CONTAINER_NAME = "interface";

        internal ValidatingParameterContainer PropertyContainer = new ValidatingParameterContainer("property", CONTAINER_NAME);

        internal ValidatingMethodContainer MethodContainer = new ValidatingMethodContainer(CONTAINER_NAME);

        internal PatternInterface() { }

        public string Name { get; private set; }

        public IEnumerable<IPatternMethod> Methods => MethodContainer.Items;

        public IEnumerable<PatternParameter> Properties => PropertyContainer.Items;

        public void AddProperty(PatternParameter property) => PropertyContainer.Add(property);

        public void RemoveProperty(string name) => PropertyContainer.Remove(name);

        public void AddMethod(IPatternMethod method) => MethodContainer.Add(method);

        public void RemoveMethod(string signature) => MethodContainer.Remove(signature);

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }
}
