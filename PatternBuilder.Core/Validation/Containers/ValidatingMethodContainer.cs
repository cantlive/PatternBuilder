using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Validation.Containers
{
    internal sealed class ValidatingMethodContainer : ValidatingContainer<string, IPatternMethod>
    {
        private readonly string _containerName;

        public ValidatingMethodContainer(string containerName)
        {
            _containerName = containerName;
        }

        public ValidatingMethodContainer(ValidatingMethodContainer validatingMethodContainer) : base(validatingMethodContainer)
        {
            _containerName = validatingMethodContainer._containerName;
        }

        protected override string GetKey(IPatternMethod method) => method.GetSignature();

        protected override string GetValidatingParameterName() => "method";

        protected override void ValidateAdd(IPatternMethod method)
        {
            PatternValidator.ThrowIfNullArgument(method, nameof(method));
            PatternValidator.ValidateUniqueMethod(_items, method, _containerName);
        }

        protected override void ValidateRemove(string key)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(key, GetValidatingParameterName());
        }
    }
}
