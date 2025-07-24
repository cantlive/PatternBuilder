using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternMethod : PatternPrimitiveBase, IPatternPrimitive
    {
        internal ValidatingPatternPrimitiveContainer<PatternParameter> ParameterContainer = new ValidatingPatternPrimitiveContainer<PatternParameter>("method");

        internal PatternMethod(string name) : base(name) { }

        public static string SystemName => "method";

        public static string DefaultName => "Method1";

        public override string UniqueKey => GetSignature();

        public string ReturnType { get; private set; } = "void";

        public IEnumerable<PatternParameter> Parameters => ParameterContainer.Items;

        public bool IsAbstract { get; private set; }

        public bool HasImplementation { get; internal set; } = true;

        public string Body { get; private set; }

        public PatternParameter AddParameter(string name, string type = "")
        {
            var parameter = new PatternParameter(name, type);
            ParameterContainer.Add(parameter);

            return parameter;
        }

        public void RemoveParameter(PatternParameter parameter) => ParameterContainer.Remove(parameter);

        public void SetReturnType(string returnType)
        {
            ReturnType = returnType;
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

            return string.Join(";", ReturnType, Name, string.Join(";", Parameters.Select(p => $"{p.Type}{p.Name}")));
        }
    }
}
