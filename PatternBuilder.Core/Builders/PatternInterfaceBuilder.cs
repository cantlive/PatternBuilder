using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
namespace PatternBuilder.Core.Builders
{
    public class PatternInterfaceBuilder : IPatternInterfaceBuilder
    {
        private PatternInterface _patternInterface;

        private string _name;
        private Dictionary<string, IPatternMethod> _methodsBySignature = new Dictionary<string, IPatternMethod>();
        private Dictionary<string, PatternParameter> _propertiesByName = new Dictionary<string, PatternParameter>();

        public PatternInterfaceBuilder(string name)
        {
            _name = name;
        }

        public PatternInterfaceBuilder(IPatternInterface patternInterface)
        {
            SetInterface(patternInterface);
        }

        public IPatternInterfaceBuilder AddField(string parameterType, string parameterName)
        {
            return AddProperty(new PatternParameter(parameterType, parameterName));
        }

        public IPatternInterfaceBuilder AddMethod(IPatternMethod method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            method.HasImplementation = false;
            _methodsBySignature.Add(method.GetSignature(), method);

            return this;
        }

        public IPatternInterface Build()
        {
            if (_patternInterface == null)
                _patternInterface = new PatternInterface();

            _patternInterface.Name = _name;
            _patternInterface.PropertiesByName = new Dictionary<string, PatternParameter>(_propertiesByName);
            _patternInterface.MethodsBySignature = new Dictionary<string, IPatternMethod>(_methodsBySignature);

            return _patternInterface;
        }

        public void Clear()
        {
            _patternInterface = null;
            _name = string.Empty;
            _methodsBySignature.Clear();
            _propertiesByName.Clear();
        }

        public IPatternInterfaceBuilder RemoveProperty(string name)
        {
            if (_patternInterface == null)
                _propertiesByName.Remove(name);
            else
                _patternInterface.RemoveProperty(name);

            return this;
        }

        public IPatternInterfaceBuilder RemoveMethod(string signature)
        {
            if (_patternInterface == null)
                _methodsBySignature.Remove(signature);
            else
                _patternInterface.RemoveMethod(signature);

            return this;
        }

        public IPatternInterfaceBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPatternInterfaceBuilder SetInterface(IPatternInterface patternInterface)
        {
            if (patternInterface == null)
                throw new ArgumentNullException(nameof(patternInterface));

            _patternInterface = (PatternInterface)patternInterface;

            return this;
        }

        private IPatternInterfaceBuilder AddProperty(PatternParameter field)
        {
            if (field == null)
                throw new ArgumentNullException("field");

            _propertiesByName.Add(field.Name, field);

            return this;
        }
    }
}
