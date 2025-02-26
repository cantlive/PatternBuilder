using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternInterface : IPatternInterface
    {
        public string Name { get; private set; }        

        public IEnumerable<IPatternMethod> Methods => _methods;

        private List<IPatternMethod> _methods;

        internal PatternInterface(string name)
        {
            Name = name;
            _methods = new List<IPatternMethod>();
        }

        internal void AddMethod(IPatternMethod method) => _methods.Add(method);
    }
}
