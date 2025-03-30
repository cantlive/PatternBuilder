using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternClass : IPatternClass
    {
        public string Name { get; internal set; }

        public IEnumerable<PatternParameter> Fields => FieldsByName.Values;

        public IEnumerable<IPatternMethod> Methods => MethodsByName.Values;

        public bool IsAbstract { get; internal set; }

        public string ParentClass { get; internal set; }

        internal Dictionary<string, PatternParameter> FieldsByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsByName = new Dictionary<string, IPatternMethod>();

        internal void RemoveField(string name) => FieldsByName.Remove(name);

        internal void RemoveMethod(string name) => MethodsByName.Remove(name);
    }
}
