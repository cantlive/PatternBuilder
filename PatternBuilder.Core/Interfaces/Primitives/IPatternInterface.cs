namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternInterface
    {
        string Name { get; }

        IEnumerable<IPatternMethod> Methods { get; }
    }
}
