using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternMethod : IPatternMethod
    {
        internal Dictionary<string, PatternParameter> ParametersByName = new Dictionary<string, PatternParameter>();

        internal PatternMethod()
        {
            
        }

        public string Name { get; private set; }

        public string ReturnType { get; private set; }

        public IEnumerable<PatternParameter> Parameters => ParametersByName.Values;

        public bool IsAbstract { get; private set; }

        public bool HasImplementation { get; internal set; } = true;

        public string Body { get; private set; }

        public void AddParameter(string type, string name)
        {
            ParametersByName.Add(name, new PatternParameter(type, name));
        }

        public void RemoveParameter(string name) => ParametersByName.Remove(name);

        public string GetSignature()
        {
            return $"{ReturnType};{Name};{string.Join(";", Parameters.Select(p => $"{p.Type}{p.Name}"))}";
        }

        public void SetReturnType(string returnType)
        {
            ReturnType = returnType;
        }

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public void SetBody(string body)
        {
            Body = body;
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
