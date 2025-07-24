using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternMethodBuilder : PatternBuilderBase<PatternMethod>
    {
        public PatternMethodBuilder AddParameter(string type, string name)
        {
            _value.AddParameter(type, name);
            return this;
        }

        public PatternMethodBuilder SetName(string name)
        {
            _value.SetName(name);
            return this;
        }

        public PatternMethodBuilder SetReturnType(string returnType)
        {
            _value.SetReturnType(returnType);
            return this;
        }

        public PatternMethodBuilder SetBody(string body)
        {
            _value.SetBody(body);
            return this;
        }

        public PatternMethodBuilder RemoveParameter(PatternParameter parameter)
        {
            _value.RemoveParameter(parameter);
            return this;
        }

        public PatternMethodBuilder HasImplementation()
        {
            _value.SetHasImplementation();
            return this;
        }

        public PatternMethodBuilder HasNoImplementation()
        {
            _value.SetHasNoImplementation();
            return this;
        }

        public PatternMethodBuilder SetAbstarct()
        {
            _value.SetAbstract();
            return this;
        }

        public PatternMethodBuilder SetNonAbstarct()
        {
            _value.SetNonAbstract();
            return this;
        }
    }
}
