using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternClassBuilder
    {
        private PatternClass _patternClass = new PatternClass();

        public PatternClassBuilder AddField(string parameterType, string parameterName)
        {
            return AddField(new PatternParameter(parameterType, parameterName));
        }

        public PatternClassBuilder AddField(PatternParameter field)
        {
            _patternClass.AddField(field);
            return this;
        }

        public PatternClassBuilder AddMethod(PatternMethod method)
        {
            _patternClass.AddMethod(method);
            return this;
        }

        public PatternClass Build()
        {
            return _patternClass;
        }

        public void Clear()
        {
            _patternClass = new PatternClass();
        }

        public PatternClassBuilder RemoveField(PatternParameter field)
        {
            _patternClass.RemoveField(field);
            return this;
        }

        public PatternClassBuilder RemoveMethod(PatternMethod method)
        {
            _patternClass.RemoveMethod(method);
            return this;
        }

        public PatternClassBuilder RemoveParentClass()
        {
            _patternClass.SetParentClass(string.Empty);
            return this;
        }

        public PatternClassBuilder SetAbstract()
        {
            _patternClass.SetAbstract();
            return this;
        }

        public PatternClassBuilder SetNonAbstract()
        {
            _patternClass.SetNonAbstract();
            return this;
        }

        public PatternClassBuilder SetName(string name)
        {
            _patternClass.SetName(name);
            return this;
        }

        public PatternClassBuilder SetParentClass(string parentClass)
        {
            _patternClass.SetParentClass(parentClass);
            return this;
        }
    }
}
