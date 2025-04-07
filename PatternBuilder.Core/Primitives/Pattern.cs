using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation.Containers;

namespace PatternBuilder.Core.Primitives
{
    public sealed class Pattern : IPattern
    {
        internal ValidatingClassContainer ClassContainer = new ValidatingClassContainer();

        internal ValidatingInterfaceContainer InterfaceContainer = new ValidatingInterfaceContainer();

        internal Pattern() { }

        public IEnumerable<IPatternClass> Classes => ClassContainer.Items;
        public IEnumerable<IPatternInterface> Interfaces => InterfaceContainer.Items;

        public void AddClass(IPatternClass patternClass) => ClassContainer.Add(patternClass);

        public void AddInterface(IPatternInterface patternInterface) => InterfaceContainer.Add(patternInterface);

        public void RemoveClass(string name) => ClassContainer.Remove(name);

        public void RemoveInterface(string name) => InterfaceContainer.Remove(name);
    }
}
