using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
namespace PatternBuilder.Core.Builders
{
    public sealed class PatternInterfaceBuilder : IPatternInterfaceBuilder
    {
        private string _name;
        private Dictionary<string, IPatternMethod> _methodsBySignature = new Dictionary<string, IPatternMethod>();
        private Dictionary<string, PatternParameter> _propertiesByName = new Dictionary<string, PatternParameter>();

        public IPatternInterfaceBuilder AddProperty(string parameterType, string parameterName)
        {
            return AddProperty(new PatternParameter(parameterType, parameterName));
        }

        public IPatternInterfaceBuilder AddMethod(IPatternMethod method)
        {
            ArgumentNullException.ThrowIfNull(method);

            if (_methodsBySignature.ContainsKey(method.GetSignature()))
                throw new InvalidOperationException($"Method '{method.Name}' already exists in the interface.");

            if (method.HasImplementation)
                throw new InvalidOperationException($"Method '{method.Name}' must be without implementation.");

            _methodsBySignature.Add(method.GetSignature(), method);

            return this;
        }

        public IPatternInterface Build()
        {
            var patternInterface = new PatternInterface();

            patternInterface.SetName(_name);
            patternInterface.PropertiesByName = new Dictionary<string, PatternParameter>(_propertiesByName);
            patternInterface.MethodsBySignature = new Dictionary<string, IPatternMethod>(_methodsBySignature);

            return patternInterface;
        }

        public void Clear()
        {
            _name = string.Empty;
            _methodsBySignature.Clear();
            _propertiesByName.Clear();
        }

        public IPatternInterfaceBuilder RemoveProperty(string name)
        {
            _propertiesByName.Remove(name);
            return this;
        }

        public IPatternInterfaceBuilder RemoveMethod(string signature)
        {
            _methodsBySignature.Remove(signature);
            return this;
        }

        public IPatternInterfaceBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        private PatternInterfaceBuilder AddProperty(PatternParameter field)
        {
            ArgumentNullException.ThrowIfNull(field);

            if (_propertiesByName.ContainsKey(field.Name))
                throw new InvalidOperationException($"Property '{field.Name}' already exists in the interface.");

            _propertiesByName.Add(field.Name, field);

            return this;
        }
    }
}
