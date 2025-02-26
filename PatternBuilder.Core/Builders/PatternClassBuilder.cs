using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternClassBuilder : IPatternClassBuilder
    {
        private PatternClass _patternClass;

        public IPatternClassBuilder AddField(string parameterType, string parameterName)
        {
            return AddField(new PatternParameter(parameterType, parameterName));
        }

        public IPatternClassBuilder AddMethod(IPatternMethod method)
        {
            _patternClass.AddMethod(method);

            return this;
        }

        public IPatternClass Build()
        {
            if (_patternClass == null)
                throw new InvalidOperationException("The class was not initialized.");

            return _patternClass;
        }

        public void Clear()
        {
            _patternClass = null;
        }

        public IPatternClassBuilder SetAbstractClass()
        {
            _patternClass.SetAbstract();

            return this;
        }

        public IPatternClassBuilder SetClass(string name)
        {
            _patternClass = new PatternClass(name);

            return this;
        }

        public IPatternClassBuilder SetParentClass(string parentClass)
        {
            _patternClass.SetParentClass(parentClass);

            return this;
        }

        private IPatternClassBuilder AddField(PatternParameter field)
        {
            _patternClass.AddField(field);

            return this;
        }
    }
}
