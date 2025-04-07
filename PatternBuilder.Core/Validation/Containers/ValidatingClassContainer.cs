using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Validation.Containers
{
    internal sealed class ValidatingClassContainer : ValidatingContainer<string, IPatternClass>
    {
        public ValidatingClassContainer() : base() { }

        public ValidatingClassContainer(ValidatingClassContainer validatingClassContainer) : base(validatingClassContainer) { }

        protected override string GetValidatingParameterName() => "class";

        protected override string GetKey(IPatternClass patternClass) => patternClass.Name;

        protected override void ValidateAdd(IPatternClass patternClass)
        {
            PatternValidator.ThrowIfNullArgument(patternClass, nameof(patternClass));
            PatternValidator.ValidateUniqueClass(_items, patternClass);
        }

        protected override void ValidateRemove(string key)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(key, GetValidatingParameterName());
        }
    }
}
