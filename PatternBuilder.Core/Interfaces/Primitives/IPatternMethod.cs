using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternMethod
    {
        string Name { get; }

        string ReturnType { get; }

        bool IsAbstract { get; internal set; }

        IEnumerable<PatternParameter> Parameters { get; }
    }
}
