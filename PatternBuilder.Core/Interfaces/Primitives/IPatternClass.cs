using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternClass
    {
        string Name { get; }

        bool IsAbstract { get; }

        IEnumerable<PatternParameter> Fields { get; }

        IEnumerable<IPatternMethod> Methods { get; }

        string ParentClass { get; }
    }
}
