using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternPrimitiveBuilder : PatternPrimitiveBuilderBase<PatternPrimitiveBuilder, Pattern>
    {
        public PatternPrimitiveBuilder AddClass(PatternClass patternClass)
        {
            _value.AddClass(patternClass);
            return this;
        }

        public PatternPrimitiveBuilder AddInterface(PatternInterface patternInterface)
        {
            _value.AddInterface(patternInterface);
            return this;
        }

        public PatternPrimitiveBuilder RemoveClass(PatternClass @class)
        {
            _value.RemoveClass(@class);
            return this;
        }

        public PatternPrimitiveBuilder RemoveInterface(PatternInterface @interface)
        {
            _value.RemoveInterface(@interface);
            return this;
        }
    }
}
