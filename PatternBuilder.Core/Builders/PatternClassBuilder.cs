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
            ThrowIfClassWasNotInitialized();
            if (method == null)
                throw new ArgumentNullException("method");

            _patternClass.AddMethod(method);

            return this;
        }

        public IPatternClass Build()
        {
            ThrowIfClassWasNotInitialized();

            return _patternClass;
        }

        public void Clear()
        {
            _patternClass = null;
        }

        public IPatternClassBuilder SetAbstractClass()
        {
            ThrowIfClassWasNotInitialized();

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
            ThrowIfClassWasNotInitialized();

            _patternClass.SetParentClass(parentClass);

            return this;
        }

        private IPatternClassBuilder AddField(PatternParameter field)
        {
            ThrowIfClassWasNotInitialized();

            if (field == null)
                throw new ArgumentNullException("field");

            _patternClass.AddField(field);

            return this;
        }

        private void ThrowIfClassWasNotInitialized()
        {
            if (_patternClass == null)
                throw new InvalidOperationException("The class was not initialized.");
        }
    }
}
