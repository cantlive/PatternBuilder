using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternMethod : IPatternMethod
    {
        public string Name => _name;

        public string ReturnType => _returnType;

        public IEnumerable<PatternParameter> Parameters => _parameters;

        public bool IsAbstract
        {
            get => _isAbstract;
            set => _isAbstract = value;
        }

        private bool _isAbstract;

        private readonly string _name;

        private readonly string _returnType;

        private readonly IEnumerable<PatternParameter> _parameters;

        public PatternMethod(string name, string returnType, IEnumerable<PatternParameter> parameters)
            : this(name, returnType)
        {
            _parameters = parameters;
        }

        public PatternMethod(string returnType, string name)
        {
            _returnType = returnType;
            _name = name;
        }
    }

    public class PatternVoidMethod(string name, IEnumerable<PatternParameter> parameters) : PatternMethod(name, "void", parameters);
}
