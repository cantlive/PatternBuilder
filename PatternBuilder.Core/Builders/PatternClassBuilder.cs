using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public class PatternClassBuilder : IPatternClassBuilder
    {
        private PatternClass _patternClass;

        private string _name;
        private string _parentClass;
        private bool _isAbstract;
        private List<IPatternMethod> _methods = new List<IPatternMethod>();
        private List<PatternParameter> _fields = new List<PatternParameter>();

        public PatternClassBuilder(string name)
        {
            _name = name;
        }

        public PatternClassBuilder(IPatternClass patternClass)
        {
            SetClass(patternClass);
        }

        public IPatternClassBuilder AddField(string parameterType, string parameterName)
        {
            return AddField(new PatternParameter(parameterType, parameterName));
        }

        public IPatternClassBuilder AddMethod(IPatternMethod method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            _methods.Add(method);

            return this;
        }

        public IPatternClass Build()
        {
            if (_patternClass == null)
                _patternClass = new PatternClass();

            _patternClass.Name = _name;
            _patternClass.ParentClass = _parentClass;
            _patternClass.IsAbstract = _isAbstract;
            _patternClass.FieldsByName = _fields.ToDictionary(f => f.Name);
            _patternClass.MethodsByName = _methods.ToDictionary(m => m.Name);

            return _patternClass;
        }

        public void Clear()
        {
            _patternClass = null;
            _methods.Clear();
            _fields.Clear();
        }

        public IPatternClassBuilder RemoveField(string name)
        {
            _patternClass.RemoveField(name);
            return this;
        }

        public IPatternClassBuilder RemoveMethod(string name)
        {
            _patternClass.RemoveMethod(name);
            return this;
        }

        public IPatternClassBuilder RemoveParentClass()
        {
            _parentClass = string.Empty;
            return this;
        }

        public IPatternClassBuilder SetAbstractClass()
        {
            _isAbstract = true;
            return this;
        }

        public IPatternClassBuilder SetNonAbstractClass()
        {
            _isAbstract = false;
            return this;
        }

        public IPatternClassBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPatternClassBuilder SetClass(IPatternClass patternClass)
        {
            if (patternClass == null)
                throw new ArgumentNullException(nameof(patternClass));

            _patternClass = (PatternClass)patternClass;
            return this;
        }

        public IPatternClassBuilder SetParentClass(string parentClass)
        {
            _parentClass = parentClass;
            return this;
        }

        private IPatternClassBuilder AddField(PatternParameter field)
        {
            if (field == null)
                throw new ArgumentNullException("field");

            _fields.Add(field);

            return this;
        }
    }
}
