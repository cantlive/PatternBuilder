using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternMethod
    {
        string Name { get; }

        string ReturnType { get; }

        bool IsAbstract { get; }

        bool HasImplementation { get; }

        IEnumerable<PatternParameter> Parameters { get; }

        string Body { get; }

        string GetSignature();

        void SetAbstract();

        void SetNonAbstract();
    }
}
