using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternMethodBuilder : IPatternMethodBuilder
    {
        private string _returnType;
        private string _name;
        private Dictionary<string, PatternParameter> _parametersByName = new Dictionary<string, PatternParameter>();
        private bool _isAbstract;
        private bool _hasImplementation = true;
        private string _body;

        public IPatternMethodBuilder AddParameter(string type, string name)
        {
            _parametersByName.Add(name, new PatternParameter(type, name));
            return this;
        }

        public IPatternMethod Build()
        {
            var patternMethod = new PatternMethod();

            patternMethod.SetReturnType(_returnType);
            patternMethod.SetName(_name);
            patternMethod.ParametersByName = new Dictionary<string, PatternParameter>(_parametersByName);
            patternMethod.HasImplementation = _hasImplementation;
            patternMethod.SetBody(_body);
            if (_isAbstract)
                patternMethod.SetAbstract();
            else if (_hasImplementation)
                patternMethod.SetNonAbstract();

            return patternMethod;
        }

        public void Clear()
        {
            _returnType = string.Empty;
            _name = string.Empty;
            _isAbstract = false;
            _hasImplementation = true;
            _body = string.Empty;
            _parametersByName.Clear();
        }

        public IPatternMethodBuilder SetVoidMethod(string name) => SetMethod("void", name);

        public IPatternMethodBuilder SetMethod(string returnType, string name, params PatternParameter[] parameters)
        {
            _returnType = returnType;
            _name = name;
            _parametersByName = parameters.ToDictionary(p => p.Name);

            return this;
        }

        public IPatternMethodBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPatternMethodBuilder SetReturnType(string returnType)
        {
            _returnType = returnType;
            return this;
        }

        public IPatternMethodBuilder SetBody(string body)
        {
            _body = body;
            return this;
        }

        public IPatternMethodBuilder RemoveParameter(string name)
        {
            _parametersByName.Remove(name);
            return this;
        }

        public IPatternMethodBuilder HasNoImplementation()
        {
            _hasImplementation = false;
            return this;
        }

        public IPatternMethodBuilder SetAbstarct()
        {
            _isAbstract = true;
            _hasImplementation = false;
            _body = string.Empty;

            return this;
        }

        public IPatternMethodBuilder SetNonAbstarct()
        {
            _isAbstract = false;
            _hasImplementation = true;

            return this;
        }
    }
}
