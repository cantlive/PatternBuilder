using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class Pattern : IPattern
    {
        private readonly Dictionary<string, IPatternClass> _classes = new Dictionary<string, IPatternClass>();
        private readonly Dictionary<string, IPatternInterface> _interfaces = new Dictionary<string, IPatternInterface>();

        public IEnumerable<IPatternClass> Classes => _classes.Values;
        public IEnumerable<IPatternInterface> Interfaces => _interfaces.Values;

        public void AddClass(IPatternClass patternClass)
        {
            ArgumentNullException.ThrowIfNull(patternClass);

            if (_classes.ContainsKey(patternClass.Name))
                throw new InvalidOperationException($"Class '{patternClass.Name}' already exists in the pattern.");

            _classes.Add(patternClass.Name, patternClass);
        }

        public void AddInterface(IPatternInterface patternInterface)
        {
            ArgumentNullException.ThrowIfNull(patternInterface);

            if (_interfaces.ContainsKey(patternInterface.Name))
                throw new InvalidOperationException($"Interface '{patternInterface.Name}' already exists in the pattern.");

            _interfaces.Add(patternInterface.Name, patternInterface);
        }

        public void RemoveClass(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            _classes.Remove(name);
        }

        public void RemoveInterface(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            _interfaces.Remove(name);
        }
    }
}
