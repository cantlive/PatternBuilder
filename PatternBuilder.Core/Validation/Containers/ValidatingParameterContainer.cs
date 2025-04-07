using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Validation.Containers
{
    internal sealed class ValidatingParameterContainer : ValidatingContainer<string, PatternParameter>
    {
        private readonly string _parameterName;
        private readonly string _containerName;

        public ValidatingParameterContainer(string parameterName, string containerName)
        {
            _parameterName = parameterName;
            _containerName = containerName;
        }

        public ValidatingParameterContainer(ValidatingParameterContainer validatingParameterContainer) : base(validatingParameterContainer)
        {
            _parameterName = validatingParameterContainer._parameterName;
            _containerName = validatingParameterContainer._containerName;
        }

        protected override string GetKey(PatternParameter field) => field.Name;

        protected override string GetValidatingParameterName() => _parameterName;

        protected override void ValidateAdd(PatternParameter parameter)
        {
            PatternValidator.ThrowIfNullArgument(parameter, GetValidatingParameterName());
            PatternValidator.ValidateUniqueParameter(_items, parameter, GetValidatingParameterName(), _containerName);
        }

        protected override void ValidateRemove(string key)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(key, GetValidatingParameterName());
        }
    }
}
