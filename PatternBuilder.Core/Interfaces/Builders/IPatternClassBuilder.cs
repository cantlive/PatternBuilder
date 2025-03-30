using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternClassBuilder
    {
        IPatternClassBuilder SetName(string name);

        IPatternClassBuilder SetClass(IPatternClass patternClass);

        IPatternClassBuilder SetAbstract();

        IPatternClassBuilder SetNonAbstract();

        IPatternClassBuilder SetParentClass(string parent);

        IPatternClassBuilder RemoveParentClass();

        IPatternClassBuilder AddField(string parameterType, string parameterName);

        IPatternClassBuilder AddMethod(IPatternMethod method);

        IPatternClassBuilder RemoveField(string name);

        IPatternClassBuilder RemoveMethod(string name);

        IPatternClass Build();

        void Clear();
    }
}
