using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternInterface
    {
        string Name { get; }

        IEnumerable<PatternParameter> Properties { get; }

        IEnumerable<IPatternMethod> Methods { get; }
    }
}
