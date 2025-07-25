using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternInterfaceBuilder : PatternPrimitiveBuilderBase<PatternInterfaceBuilder, PatternInterface>
    {
        public PatternInterfaceBuilder AddProperty(string parameterName, string parameterType = "")
        {
            return AddProperty(new PatternParameter(parameterName, parameterType));
        }
        public PatternInterfaceBuilder AddProperty(PatternParameter property)
        {
            _value.AddProperty(property);
            return this;
        }

        public PatternInterfaceBuilder AddMethod(PatternMethod method)
        {
            _value.AddMethod(method);
            return this;
        }

        public PatternInterfaceBuilder RemoveProperty(PatternParameter property)
        {
            _value.RemoveProperty(property);
            return this;
        }

        public PatternInterfaceBuilder RemoveMethod(PatternMethod method)
        {
            _value.RemoveMethod(method);
            return this;
        }
    }
}
