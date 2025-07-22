using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class Pattern : IPatternPrimitive
    {
        private string _name;

        internal ValidatingPatternPrimitiveContainer<PatternClass> ClassContainer = new ValidatingPatternPrimitiveContainer<PatternClass>(SystemName);

        internal ValidatingPatternPrimitiveContainer<PatternInterface> InterfaceContainer = new ValidatingPatternPrimitiveContainer<PatternInterface>(SystemName);

        internal Pattern() { }

        public static string SystemName => "pattern";

        public string Name { get; private set; }

        public string UniqueKey => Name;

        public IEnumerable<PatternClass> Classes => ClassContainer.Items;
        public IEnumerable<PatternInterface> Interfaces => InterfaceContainer.Items;

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddClass(PatternClass patternClass) => ClassContainer.Add(patternClass);

        public void AddInterface(PatternInterface patternInterface) => InterfaceContainer.Add(patternInterface);

        public void RemoveClass(PatternClass @class) => ClassContainer.Remove(@class);

        public void RemoveInterface(PatternInterface @interface) => InterfaceContainer.Remove(@interface);
    }
}
