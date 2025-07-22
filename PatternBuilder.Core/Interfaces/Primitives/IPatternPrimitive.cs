namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternPrimitive
    {
        string Name { get; }
        static abstract string SystemName { get; }
        string UniqueKey { get; }
    }
}
