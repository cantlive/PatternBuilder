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

        void SetName(string name);

        void SetParentClass(string parentClass);

        void SetAbstract();

        void SetNonAbstract();

        void AddField(PatternParameter field);

        void RemoveField(string name);

        void AddMethod(IPatternMethod method);

        void RemoveMethod(string name);
    }
}
