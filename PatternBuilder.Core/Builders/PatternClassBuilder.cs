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
        private Dictionary<string, IPatternMethod> _methodsByName = new Dictionary<string, IPatternMethod>();
        private Dictionary<string, PatternParameter> _fieldsByName = new Dictionary<string, PatternParameter>();

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

            _methodsByName.Add(method.Name, method);

            return this;
        }

        public IPatternClass Build()
        {
            if (_patternClass == null)
                _patternClass = new PatternClass();

            _patternClass.Name = _name;
            _patternClass.ParentClass = _parentClass;
            _patternClass.IsAbstract = _isAbstract;
            _patternClass.FieldsByName = new Dictionary<string, PatternParameter>(_fieldsByName);
            _patternClass.MethodsByName = new Dictionary<string, IPatternMethod>(_methodsByName);

            return _patternClass;
        }

        public void Clear()
        {
            _patternClass = null;
            _name = string.Empty;
            _parentClass = string.Empty;
            _isAbstract = false;
            _methodsByName.Clear();
            _fieldsByName.Clear();
        }

        public IPatternClassBuilder RemoveField(string name)
        {
            if (_patternClass == null)
                _fieldsByName.Remove(name);
            else
                _patternClass.RemoveField(name);

            return this;
        }

        public IPatternClassBuilder RemoveMethod(string name)
        {
            if (_patternClass == null)
                _methodsByName.Remove(name);
            else
                _patternClass.RemoveMethod(name);

            return this;
        }

        public IPatternClassBuilder RemoveParentClass()
        {
            _parentClass = string.Empty;
            return this;
        }

        public IPatternClassBuilder SetAbstract()
        {
            _isAbstract = true;
            foreach (IPatternMethod method in _methodsByName.Values)
            {
                method.IsAbstract = true;
                method.Body = string.Empty;
            }

            return this;
        }

        public IPatternClassBuilder SetNonAbstract()
        {
            _isAbstract = false;
            foreach (IPatternMethod method in _methodsByName.Values)
                method.IsAbstract = false;

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

            _fieldsByName.Add(field.Name, field);

            return this;
        }
    }
}
