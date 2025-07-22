using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternMethodBuilder
    {
        private PatternMethod _patternMethod = new PatternMethod();

        public static PatternMethod Empty => new PatternMethod();

        public PatternMethodBuilder AddParameter(string type, string name)
        {
            _patternMethod.AddParameter(type, name);
            return this;
        }

        public PatternMethod Build()
        {
            return _patternMethod;
        }

        public void Clear()
        {
            _patternMethod = new PatternMethod();
        }

        public PatternMethodBuilder SetVoidMethod(string name) => SetMethod("void", name);

        public PatternMethodBuilder SetMethod(string returnType, string name)
        {
            _patternMethod = new PatternMethod();
            _patternMethod.SetName(name);
            _patternMethod.SetReturnType(returnType);

            return this;
        }

        public PatternMethodBuilder SetName(string name)
        {
            _patternMethod.SetName(name);
            return this;
        }

        public PatternMethodBuilder SetReturnType(string returnType)
        {
            _patternMethod.SetReturnType(returnType);
            return this;
        }

        public PatternMethodBuilder SetBody(string body)
        {
            _patternMethod.SetBody(body);
            return this;
        }

        public PatternMethodBuilder RemoveParameter(PatternParameter parameter)
        {
            _patternMethod.RemoveParameter(parameter);
            return this;
        }

        public PatternMethodBuilder HasImplementation()
        {
            _patternMethod.SetHasImplementation();
            return this;
        }

        public PatternMethodBuilder HasNoImplementation()
        {
            _patternMethod.SetHasNoImplementation();
            return this;
        }

        public PatternMethodBuilder SetAbstarct()
        {
            _patternMethod.SetAbstract();
            return this;
        }

        public PatternMethodBuilder SetNonAbstarct()
        {
            _patternMethod.SetNonAbstract();
            return this;
        }
    }
}
