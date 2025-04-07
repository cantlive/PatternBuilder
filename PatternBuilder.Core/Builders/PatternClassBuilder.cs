using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternClassBuilder : IPatternClassBuilder
    {
        private readonly ValidatingParameterContainer _fieldContainer = new ValidatingParameterContainer("field", PatternClass.CONTAINER_NAME);
        private readonly ValidatingMethodContainer _methodContainer = new ValidatingMethodContainer(PatternClass.CONTAINER_NAME);

        private string _name;
        private string _parentClass;
        private bool _isAbstract;

        public IPatternClassBuilder AddField(string parameterType, string parameterName)
        {
            return AddField(new PatternParameter(parameterType, parameterName));
        }

        public IPatternClassBuilder AddMethod(IPatternMethod method)
        {
            _methodContainer.Add(method);
            return this;
        }

        public IPatternClass Build()
        {
            var patternClass = new PatternClass();

            patternClass.SetName(_name);
            patternClass.SetParentClass(_parentClass);
            if (_isAbstract)
                patternClass.SetAbstract();
            else
                patternClass.SetNonAbstract();
            patternClass.FieldContainer = new ValidatingParameterContainer(_fieldContainer);
            patternClass.MethodContainer = new ValidatingMethodContainer(_methodContainer);

            return patternClass;
        }

        public void Clear()
        {
            _name = string.Empty;
            _parentClass = string.Empty;
            _isAbstract = false;
            _methodContainer.Clear();
            _fieldContainer.Clear();
        }

        public IPatternClassBuilder RemoveField(string name)
        {
            _fieldContainer.Remove(name);
            return this;
        }

        public IPatternClassBuilder RemoveMethod(string signature)
        {
            _methodContainer.Remove(signature);
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
            return this;
        }

        public IPatternClassBuilder SetNonAbstract()
        {
            _isAbstract = false;
            return this;
        }

        public IPatternClassBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPatternClassBuilder SetParentClass(string parentClass)
        {
            _parentClass = parentClass;
            return this;
        }

        private PatternClassBuilder AddField(PatternParameter field)
        {
            _fieldContainer.Add(field);
            return this;
        }
    }
}
