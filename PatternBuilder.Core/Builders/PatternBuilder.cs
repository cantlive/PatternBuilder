using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternBuilder : PatternPrimitiveBuilderBase<PatternBuilder, Pattern>
    {
        public PatternBuilder AddClass(PatternClass patternClass)
        {
            _value.AddClass(patternClass);
            return this;
        }

        public PatternBuilder AddInterface(PatternInterface patternInterface)
        {
            _value.AddInterface(patternInterface);
            return this;
        }

        public PatternBuilder RemoveClass(PatternClass @class)
        {
            _value.RemoveClass(@class);
            return this;
        }

        public PatternBuilder RemoveInterface(PatternInterface @interface)
        {
            _value.RemoveInterface(@interface);
            return this;
        }
    }
}
