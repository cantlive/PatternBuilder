using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternClass : IPatternClass
    {
        public string Name { get; internal set; }

        public IEnumerable<PatternParameter> Fields => FieldsByName.Values;

        public IEnumerable<IPatternMethod> Methods => MethodsByName.Values;

        public bool IsAbstract
        {
            get => _isAbstract;
            internal set
            {
                _isAbstract = value;

                foreach (IPatternMethod patternMethod in Methods)
                {
                    patternMethod.IsAbstract = value;
                    if (value)
                        patternMethod.Body = string.Empty;
                }
            }
        }

        public string ParentClass { get; internal set; }

        internal Dictionary<string, PatternParameter> FieldsByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsByName = new Dictionary<string, IPatternMethod>();

        private bool _isAbstract;

        internal void RemoveField(string name) => FieldsByName.Remove(name);

        internal void RemoveMethod(string name) => MethodsByName.Remove(name);
    }
}
