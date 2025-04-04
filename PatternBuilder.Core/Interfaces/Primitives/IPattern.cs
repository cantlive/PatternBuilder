namespace PatternBuilder.Core.Interfaces.Primitives
{
    public interface IPattern
    {
        IEnumerable<IPatternClass> Classes { get; }

        IEnumerable<IPatternInterface> Interfaces { get; }

        void AddClass(IPatternClass patternClass);

        void AddInterface(IPatternInterface patternInterface);

        void RemoveClass(string name);

        void RemoveInterface(string name);
    }
}
