using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternInterfaceBuilder : IPatternInterfaceBuilder
    {
        private readonly ValidatingParameterContainer _propertyContainer = new ValidatingParameterContainer("property", PatternInterface.CONTAINER_NAME);
        private readonly ValidatingMethodContainer _methodContainer = new ValidatingMethodContainer(PatternInterface.CONTAINER_NAME);

        private string _name;

        public IPatternInterfaceBuilder AddProperty(string parameterType, string parameterName)
        {
            return AddProperty(new PatternParameter(parameterType, parameterName));
        }

        public IPatternInterfaceBuilder AddMethod(IPatternMethod method)
        {
            // TODO: Need to validate in PatternValidator
            if (method.HasImplementation)
                throw new InvalidOperationException($"Method '{method.Name}' must be without implementation.");

            _methodContainer.Add(method);
            return this;
        }

        public IPatternInterface Build()
        {
            var patternInterface = new PatternInterface();

            patternInterface.SetName(_name);
            patternInterface.PropertyContainer = new ValidatingParameterContainer(_propertyContainer);
            patternInterface.MethodContainer = new ValidatingMethodContainer(_methodContainer);

            return patternInterface;
        }

        public void Clear()
        {
            _name = string.Empty;
            _methodContainer.Clear();
            _propertyContainer.Clear();
        }

        public IPatternInterfaceBuilder RemoveProperty(string name)
        {
            _propertyContainer.Remove(name);
            return this;
        }

        public IPatternInterfaceBuilder RemoveMethod(string signature)
        {
            _methodContainer.Remove(signature);
            return this;
        }

        public IPatternInterfaceBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        private PatternInterfaceBuilder AddProperty(PatternParameter property)
        {
            _propertyContainer.Add(property);
            return this;
        }
    }
}
