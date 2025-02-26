using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternMethodBuilder
    {
        IPatternMethodBuilder SetMethod(string returnType, string name);

        IPatternMethodBuilder AddParameter(string parameterType, string parameterName);

        IPatternMethod Build();

        void Clear();
    }
}
