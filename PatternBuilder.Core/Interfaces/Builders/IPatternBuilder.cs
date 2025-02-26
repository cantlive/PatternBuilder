using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternBuilder
    {
        IPatternBuilder AddClass(IPatternClass patternClass);

        IPatternBuilder AddInterface(IPatternInterface patternInterface);

        IPattern Build();

        void Clear();
    }
}
