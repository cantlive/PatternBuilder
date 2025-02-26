using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternMethodBuilder : IPatternMethodBuilder
    {
        private string _returnType;
        private string _name;
        private readonly List<PatternParameter> _parameters;

        public PatternMethodBuilder()
        {
            _parameters = new List<PatternParameter>();
        }

        public IPatternMethodBuilder AddParameter(string parameterType, string parameterName)
        {
            _parameters.Add(new PatternParameter(parameterType, parameterName));

            return this;
        }

        public IPatternMethod Build()
        {
            if (string.IsNullOrWhiteSpace(_returnType) || string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("The method was not initialized.");

            return new PatternMethod(_returnType, _name, _parameters);
        }

        public void Clear()
        {
            _returnType = string.Empty;
            _name = string.Empty;
            _parameters.Clear();
        }

        public IPatternMethodBuilder SetMethod(string returnType, string name)
        {
            _returnType = returnType;
            _name = name;

            return this;
        }
    }
}
