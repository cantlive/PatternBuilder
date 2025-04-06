using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternInterface : IPatternInterface
    {
        internal Dictionary<string, PatternParameter> PropertiesByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsBySignature = new Dictionary<string, IPatternMethod>();

        internal PatternInterface()
        {
            
        }

        public string Name { get; private set; }

        public IEnumerable<IPatternMethod> Methods => MethodsBySignature.Values;

        public IEnumerable<PatternParameter> Properties => PropertiesByName.Values;

        public void AddProperty(PatternParameter property)
        {
            PatternValidator.ThrowIfNullArgument(property, nameof(property));
            PatternValidator.ValidateUniqueProperty(PropertiesByName, property);

            PropertiesByName.Add(property.Name, property);
        }

        public void RemoveProperty(string name) => PropertiesByName.Remove(name);

        public void AddMethod(IPatternMethod method)
        {
            PatternValidator.ThrowIfNullArgument(method, nameof(method));
            PatternValidator.ValidateUniqueMethod(MethodsBySignature, method, "interface");

            MethodsBySignature.Add(method.GetSignature(), method);
        }

        public void RemoveMethod(string signature) => MethodsBySignature.Remove(signature);

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }
}
