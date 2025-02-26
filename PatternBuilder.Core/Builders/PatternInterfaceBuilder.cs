using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
namespace PatternBuilder.Core.Builders
{
    public class PatternInterfaceBuilder
    {
        private PatternInterface _patternInterface;

        public PatternInterfaceBuilder SetInterface(string name)
        {
            _patternInterface = new PatternInterface(name);
            return this;
        }

        public PatternInterfaceBuilder AddMethod(IPatternMethod method)
        {
            ThrowIfInterfaceWasNotInitialized();

            if (method == null)
                throw new ArgumentNullException("method");

            _patternInterface.AddMethod(method);
            return this;
        }

        public IPatternInterface Build()
        {
            ThrowIfInterfaceWasNotInitialized();

            return _patternInterface;
        }

        public void Clear()
        {
            _patternInterface = null;
        }

        private void ThrowIfInterfaceWasNotInitialized()
        {
            if (_patternInterface == null)
                throw new InvalidOperationException("The interface was not initialized.");
        }
    }
}
