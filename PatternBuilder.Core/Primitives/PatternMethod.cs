using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternMethod : IPatternPrimitive
    {
        internal ValidatingPatternPrimitiveContainer<PatternParameter> ParameterContainer = new ValidatingPatternPrimitiveContainer<PatternParameter>("method");

        internal PatternMethod() { }

        public static string SystemName => "method";

        public string Name { get; private set; }

        public string UniqueKey => GetSignature();

        public string ReturnType { get; private set; }

        public IEnumerable<PatternParameter> Parameters => ParameterContainer.Items;

        public bool IsAbstract { get; private set; }

        public bool HasImplementation { get; internal set; } = true;

        public string Body { get; private set; }

        public PatternParameter AddParameter(string type, string name)
        {
            var parameter = new PatternParameter(type, name);
            ParameterContainer.Add(parameter);

            return parameter;
        }

        public void RemoveParameter(PatternParameter parameter) => ParameterContainer.Remove(parameter);

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

        public void SetHasImplementation()
        {
            HasImplementation = true;
        }

        public void SetHasNoImplementation()
        {
            HasImplementation = false;
        }

        private string GetSignature()
        {
            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(ReturnType) && ParameterContainer.Count == 0)
                return string.Empty;

            return $"{ReturnType};{Name};{string.Join(";", Parameters.Select(p => $"{p.Type}{p.Name}"))}";
        }
    }
}
