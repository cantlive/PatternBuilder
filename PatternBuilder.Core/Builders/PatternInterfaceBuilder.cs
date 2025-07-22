using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternInterfaceBuilder
    {
        private PatternInterface _patternInterface = new PatternInterface();

        public PatternInterfaceBuilder AddProperty(string parameterType, string parameterName)
        {
            return AddProperty(new PatternParameter(parameterType, parameterName));
        }
        public PatternInterfaceBuilder AddProperty(PatternParameter property)
        {
            _patternInterface.AddProperty(property);
            return this;
        }

        public PatternInterfaceBuilder AddMethod(PatternMethod method)
        {
            _patternInterface.AddMethod(method);
            return this;
        }

        public PatternInterface Build()
        {
            return _patternInterface;
        }

        public void Clear()
        {
            _patternInterface = new PatternInterface();
        }

        public PatternInterfaceBuilder RemoveProperty(PatternParameter property)
        {
            _patternInterface.RemoveProperty(property);
            return this;
        }

        public PatternInterfaceBuilder RemoveMethod(PatternMethod method)
        {
            _patternInterface.RemoveMethod(method);
            return this;
        }

        public PatternInterfaceBuilder SetName(string name)
        {
            _patternInterface.SetName(name);
            return this;
        }
    }
}
