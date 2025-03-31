using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternMethod : IPatternMethod
    {
        public string Name { get; internal set; }

        public string ReturnType { get; internal set; }

        public IEnumerable<PatternParameter> Parameters => ParametersByName.Values;

        public bool IsAbstract { get; set; }

        public bool HasImplementation { get; set; } = true;

        public string Body { get; set; }

        internal Dictionary<string, PatternParameter> ParametersByName = new Dictionary<string, PatternParameter>();

        internal PatternMethod()
        {
            
        }

        internal void RemoveParameter(string name) => ParametersByName.Remove(name);

        public string GetSignature()
        {
            return $"{ReturnType};{Name};{string.Join(";", Parameters.Select(p => $"{p.Type}{p.Name}"))}";
        }
    }
}
