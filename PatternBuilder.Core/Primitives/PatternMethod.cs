using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternMethod : IPatternMethod
    {
        internal Dictionary<string, PatternParameter> ParametersByName = new Dictionary<string, PatternParameter>();

        internal PatternMethod()
        {
            
        }

        public string Name { get; internal set; }

        public string ReturnType { get; internal set; }

        public IEnumerable<PatternParameter> Parameters => ParametersByName.Values;

        public bool IsAbstract { get; internal set; }

        public bool HasImplementation { get; internal set; } = true;

        public string Body { get; internal set; }

        internal void RemoveParameter(string name) => ParametersByName.Remove(name);

        public string GetSignature()
        {
            return $"{ReturnType};{Name};{string.Join(";", Parameters.Select(p => $"{p.Type}{p.Name}"))}";
        }

        public void SetAbstract()
        {
            IsAbstract = true;
            HasImplementation = false;
            Body = string.Empty;
        }

        public void SetNonAbstract()
        {
            IsAbstract = false;
            HasImplementation = true;
        }
    }
}
