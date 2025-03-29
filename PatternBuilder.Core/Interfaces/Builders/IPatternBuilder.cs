using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternBuilder
    {
        IPatternBuilder AddClass(IPatternClass patternClass);

        IPatternBuilder AddClass(string name);

        IPatternBuilder AddInterface(IPatternInterface patternInterface);

        IPatternBuilder AddInterface(string name);

        IPattern Build();

        void Clear();
    }
}
