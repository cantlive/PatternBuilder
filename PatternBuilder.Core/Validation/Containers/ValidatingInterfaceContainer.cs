using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Validation.Containers
{
    internal sealed class ValidatingInterfaceContainer : ValidatingContainer<string, IPatternInterface>
    {
        public ValidatingInterfaceContainer() : base() { }

        public ValidatingInterfaceContainer(ValidatingInterfaceContainer validatingInterfaceContainer) : base(validatingInterfaceContainer) { }

        protected override string GetKey(IPatternInterface iface) => iface.Name;

        protected override string GetValidatingParameterName() => "interface";

        protected override void ValidateAdd(IPatternInterface iface)
        {
            PatternValidator.ThrowIfNullArgument(iface, nameof(iface));
            PatternValidator.ValidateUniqueInterface(_items, iface);
        }

        protected override void ValidateRemove(string key)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(key, GetValidatingParameterName());
        }
    }
}
