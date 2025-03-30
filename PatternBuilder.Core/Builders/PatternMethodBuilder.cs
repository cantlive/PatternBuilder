using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternMethodBuilder : IPatternMethodBuilder
    {
        private PatternMethod _patternMethod;

        private string _returnType;
        private string _name;
        private readonly Dictionary<string, PatternParameter> _parametersByName = new Dictionary<string, PatternParameter>();
        private string _body;

        public PatternMethodBuilder(string returnType, string name)
        {
            SetReturnType(returnType);
            SetName(name);
        }

        public PatternMethodBuilder(IPatternMethod patternMethod)
        {
            SetMethod(patternMethod);
        }

        public IPatternMethodBuilder AddParameter(string parameterType, string parameterName)
        {
            _parametersByName.Add(parameterName, new PatternParameter(parameterType, parameterName));

            return this;
        }

        public IPatternMethod Build()
        {
            if (string.IsNullOrWhiteSpace(_returnType) || string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("The method was not initialized.");

            if (_patternMethod == null)
                _patternMethod = new PatternMethod();

            _patternMethod.ReturnType = _returnType;
            _patternMethod.Name = _name;
            _patternMethod.ParametersByName = new Dictionary<string, PatternParameter>(_parametersByName);
            _patternMethod.Body = _body;

            return _patternMethod;
        }

        public void Clear()
        {
            _patternMethod = null;
            _returnType = string.Empty;
            _name = string.Empty;
            _body = string.Empty;
            _parametersByName.Clear();
        }

        public IPatternMethodBuilder SetVoidMethod(string name) => SetMethod("void", name);

        public IPatternMethodBuilder SetMethod(string returnType, string name)
        {
            _returnType = returnType;
            _name = name;

            return this;
        }

        public IPatternMethodBuilder SetMethod(IPatternMethod patternMethod)
        {
            if (patternMethod == null)
                throw new ArgumentNullException(nameof(patternMethod));

            _patternMethod = (PatternMethod)patternMethod;
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
            if (_patternMethod == null)
                _parametersByName.Remove(name);
            else
                _patternMethod.RemoveParameter(name);

            return this;
        }
    }
}
