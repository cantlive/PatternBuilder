using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternBuilder
    {
        private Pattern _pattern = new Pattern();

        public PatternBuilder AddClass(PatternClass patternClass)
        {
            _pattern.AddClass(patternClass);
            return this;
        }

        public PatternBuilder AddInterface(PatternInterface patternInterface)
        {
            _pattern.AddInterface(patternInterface);
            return this;
        }

        public PatternBuilder RemoveClass(PatternClass @class)
        {
            _pattern.RemoveClass(@class);
            return this;
        }

        public PatternBuilder RemoveInterface(PatternInterface @interface)
        {
            _pattern.RemoveInterface(@interface);
            return this;
        }

        public Pattern Build()
        {
            return _pattern;
        }

        public void Clear()
        {
            _pattern = new Pattern();
        }

        public void SetName(string name)
        {
            _pattern.SetName(name);
        }
    }
}
