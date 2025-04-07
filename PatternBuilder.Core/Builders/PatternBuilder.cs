using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Builders
{
    public class PatternBuilder : IPatternBuilder
    {
        private readonly ValidatingClassContainer _classContainer = new ValidatingClassContainer();

        private readonly ValidatingInterfaceContainer _interfaceContainer = new ValidatingInterfaceContainer();

        public IPatternBuilder AddClass(IPatternClass patternClass)
        {
            _classContainer.Add(patternClass);
            return this;
        }

        public IPatternBuilder AddInterface(IPatternInterface patternInterface)
        {
            _interfaceContainer.Add(patternInterface);
            return this;
        }

        public IPatternBuilder RemoveClass(string className)
        {
            _classContainer.Remove(className);
            return this;
        }

        public IPatternBuilder RemoveInterface(string interfaceName)
        {
            _interfaceContainer.Remove(interfaceName);
            return this;
        }

        public IPattern Build()
        {
            var pattern = new Pattern();
            pattern.ClassContainer = new ValidatingClassContainer(_classContainer);
            pattern.InterfaceContainer = new ValidatingInterfaceContainer(_interfaceContainer);

            return pattern;
        }

        public void Clear()
        {
            _classContainer.Clear();
            _interfaceContainer.Clear();
        }
    }
}
