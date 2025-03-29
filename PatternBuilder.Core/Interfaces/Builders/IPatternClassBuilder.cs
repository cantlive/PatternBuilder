using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternClassBuilder
    {
        IPatternClassBuilder SetName(string name);

        IPatternClassBuilder SetClass(IPatternClass patternClass);

        IPatternClassBuilder SetAbstractClass();

        IPatternClassBuilder SetParentClass(string parent);

        IPatternClassBuilder RemoveParentClass();

        IPatternClassBuilder AddField(string parameterType, string parameterName);

        IPatternClassBuilder AddMethod(IPatternMethod method);

        IPatternClass Build();

        void Clear();
    }
}
