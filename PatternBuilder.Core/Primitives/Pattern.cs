using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilder.Core.Primitives
{
    public sealed class Pattern : PatternPrimitiveBase, IPatternPrimitive
    {
        internal ValidatingPatternPrimitiveContainer<PatternClass> ClassContainer = new ValidatingPatternPrimitiveContainer<PatternClass>(SystemName);

        internal ValidatingPatternPrimitiveContainer<PatternInterface> InterfaceContainer = new ValidatingPatternPrimitiveContainer<PatternInterface>(SystemName);

        internal Pattern(string name) : base(name) { }

        public static string SystemName => "pattern";

        public static string DefaultName => "Pattern1";

        public IEnumerable<PatternClass> Classes => ClassContainer.Items;
        public IEnumerable<PatternInterface> Interfaces => InterfaceContainer.Items;

        public void AddClass(PatternClass patternClass) => ClassContainer.Add(patternClass);

        public void AddInterface(PatternInterface patternInterface) => InterfaceContainer.Add(patternInterface);

        public void RemoveClass(PatternClass patternClass) => ClassContainer.Remove(patternClass);

        public void RemoveInterface(PatternInterface patternInterface) => InterfaceContainer.Remove(patternInterface);
    }
}
