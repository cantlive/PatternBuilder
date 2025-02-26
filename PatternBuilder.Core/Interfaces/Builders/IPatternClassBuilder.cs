using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternClassBuilder
    {
        IPatternClassBuilder SetClass(string name);

        IPatternClassBuilder SetAbstractClass();

        IPatternClassBuilder SetParentClass(string parent);

        IPatternClassBuilder AddField(string parameterType, string parameterName);

        IPatternClassBuilder AddMethod(IPatternMethod method);

        IPatternClass Build();

        void Clear();
    }
}
