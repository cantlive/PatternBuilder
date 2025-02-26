using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternClass : IPatternClass
    {
        public string Name { get; private set; }

        public IEnumerable<PatternParameter> Fields => _fields;

        public IEnumerable<IPatternMethod> Methods => _methods;

        public bool IsAbstract { get; private set; }

        public string ParentClass { get; private set; }

        private readonly List<PatternParameter> _fields;

        private readonly List<IPatternMethod> _methods;

        internal PatternClass(string name)
        {
            Name = name;
            _fields = new List<PatternParameter>();
            _methods = new List<IPatternMethod>();
        }

        internal void SetAbstract()
        {
            IsAbstract = true;

            foreach (IPatternMethod patternMethod in Methods)
                patternMethod.IsAbstract = true;
        }

        internal void SetParentClass(string parentClass)
        {
            ParentClass = parentClass;
        }

        internal void AddField(PatternParameter field) => _fields.Add(field);

        internal void AddMethod(IPatternMethod method) => _methods.Add(method);
    }
}
