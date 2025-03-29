using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternMethodBuilder
    {
        IPatternMethodBuilder SetMethod(string returnType, string name);

        IPatternMethodBuilder SetMethod(IPatternMethod patternMethod);

        IPatternMethodBuilder SetName(string name);

        IPatternMethodBuilder SetReturnType(string returnType);

        IPatternMethodBuilder SetBody(string body);

        IPatternMethodBuilder AddParameter(string parameterType, string parameterName);

        IPatternMethod Build();

        void Clear();
    }
}
