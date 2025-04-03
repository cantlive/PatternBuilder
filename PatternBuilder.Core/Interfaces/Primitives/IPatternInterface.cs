using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPatternInterface
    {
        string Name { get; }

        IEnumerable<PatternParameter> Properties { get; }

        IEnumerable<IPatternMethod> Methods { get; }

        void AddProperty(PatternParameter property);

        void RemoveProperty(string name);

        void AddMethod(IPatternMethod method);

        void RemoveMethod(string name);
    }
}
