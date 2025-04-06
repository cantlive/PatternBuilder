using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Builders
{
    public class PatternBuilder : IPatternBuilder
    {
        private readonly Dictionary<string, IPatternClass> _classes = new Dictionary<string, IPatternClass>();
        private readonly Dictionary<string, IPatternInterface> _interfaces = new Dictionary<string, IPatternInterface>();

        public IPatternBuilder AddClass(IPatternClass patternClass)
        {
            PatternValidator.ThrowIfNullArgument(patternClass, nameof(patternClass));
            PatternValidator.ValidateUniqueClass(_classes, patternClass);

            _classes.Add(patternClass.Name, patternClass);

            return this;
        }

        public IPatternBuilder AddInterface(IPatternInterface patternInterface)
        {
            PatternValidator.ThrowIfNullArgument(patternInterface, nameof(patternInterface));
            PatternValidator.ValidateUniqueInterface(_interfaces, patternInterface);

            _interfaces.Add(patternInterface.Name, patternInterface);

            return this;
        }

        public IPatternBuilder RemoveClass(string className)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(className, nameof(className));
            _classes.Remove(className);

            return this;
        }

        public IPatternBuilder RemoveInterface(string interfaceName)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(interfaceName, nameof(interfaceName));
            _interfaces.Remove(interfaceName);

            return this;
        }

        public IPattern Build()
        {
            var pattern = new Pattern();

            foreach (var patternClass in _classes.Values)
            {
                pattern.AddClass(patternClass);
            }

            foreach (var patternInterface in _interfaces.Values)
            {
                pattern.AddInterface(patternInterface);
            }

            return pattern;
        }

        public void Clear()
        {
            _classes.Clear();
            _interfaces.Clear();
        }
    }
}
