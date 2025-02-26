using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternClass : IPatternClass
    {
        public string Name => _name;

        public IEnumerable<PatternParameter> Fields => _fields;

        public IEnumerable<IPatternMethod> Methods => _methods;

        public bool IsAbstract => _isAbstract;

        public string ParentClass => _parentClass;

        private readonly string _name;

        private bool _isAbstract;

        private string _parentClass;

        private readonly List<PatternParameter> _fields;

        private readonly List<IPatternMethod> _methods;

        public PatternClass(string name)
        {
            _name = name;
            _fields = new List<PatternParameter>();
            _methods = new List<IPatternMethod>();
        }

        internal void SetAbstract()
        {
            _isAbstract = true;

            foreach (IPatternMethod patternMethod in Methods)
                patternMethod.IsAbstract = true;
        }

        internal void SetParentClass(string parentClass)
        {
            _parentClass = parentClass;
        }

        internal void AddField(PatternParameter field)
        {
            if (field == null)
                throw new ArgumentNullException("field");

            _fields.Add(field);
        }

        internal void AddMethod(IPatternMethod method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            _methods.Add(method);
        }
    }
}
