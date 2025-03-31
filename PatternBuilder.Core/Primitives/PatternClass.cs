using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternClass : IPatternClass
    {
        public string Name { get; internal set; }

        public IEnumerable<PatternParameter> Fields => FieldsByName.Values;

        public IEnumerable<IPatternMethod> Methods => MethodsBySignature.Values;

        public bool IsAbstract { get; internal set; }

        public string ParentClass { get; internal set; }

        internal Dictionary<string, PatternParameter> FieldsByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsBySignature = new Dictionary<string, IPatternMethod>();

        internal PatternClass()
        {
            
        }

        internal void RemoveField(string name) => FieldsByName.Remove(name);

        internal void RemoveMethod(string signature) => MethodsBySignature.Remove(signature);
    }
}
