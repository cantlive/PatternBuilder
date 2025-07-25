using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternClassBuilder : PatternPrimitiveBuilderBase<PatternClassBuilder, PatternClass>
    {
        public PatternClassBuilder AddField(string parameterName, string parameterType = "")
        {
            return AddField(new PatternParameter(parameterName, parameterType));
        }

        public PatternClassBuilder AddField(PatternParameter field)
        {
            _value.AddField(field);
            return this;
        }

        public PatternClassBuilder AddMethod(PatternMethod method)
        {
            _value.AddMethod(method);
            return this;
        }

        public PatternClassBuilder RemoveField(PatternParameter field)
        {
            _value.RemoveField(field);
            return this;
        }

        public PatternClassBuilder RemoveMethod(PatternMethod method)
        {
            _value.RemoveMethod(method);
            return this;
        }

        public PatternClassBuilder RemoveParentClass()
        {
            _value.SetParentClass(string.Empty);
            return this;
        }

        public PatternClassBuilder SetAbstract()
        {
            _value.SetAbstract();
            return this;
        }

        public PatternClassBuilder SetNonAbstract()
        {
            _value.SetNonAbstract();
            return this;
        }

        public PatternClassBuilder SetParentClass(string parentClass)
        {
            _value.SetParentClass(parentClass);
            return this;
        }
    }
}
