using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Validation.Containers
{
    internal sealed class ValidatingInterfaceContainer : ValidatingContainer<string, IPatternInterface>
    {
        public ValidatingInterfaceContainer() : base() { }

        public ValidatingInterfaceContainer(ValidatingInterfaceContainer validatingInterfaceContainer) : base(validatingInterfaceContainer) { }

        protected override string GetKey(IPatternInterface patternInterface) => patternInterface.Name;

        protected override string GetValidatingParameterName() => "interface";

        protected override void ValidateAdd(IPatternInterface patternInterface)
        {
            PatternValidator.ThrowIfNullArgument(patternInterface, nameof(patternInterface));
            PatternValidator.ValidateUniqueInterface(_items, patternInterface);
        }

        protected override void ValidateRemove(string key)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(key, GetValidatingParameterName());
        }
    }
}
