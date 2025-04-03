using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternMethodBuilder
    {
        IPatternMethodBuilder SetMethod(string returnType, string name, params PatternParameter[] parameters);

        IPatternMethodBuilder SetName(string name);

        IPatternMethodBuilder SetReturnType(string returnType);

        IPatternMethodBuilder SetBody(string body);

        IPatternMethodBuilder SetAbstarct();

        IPatternMethodBuilder SetNonAbstarct();

        IPatternMethodBuilder HasNoImplementation();

        IPatternMethodBuilder AddParameter(string type, string name);

        IPatternMethodBuilder RemoveParameter(string name);

        IPatternMethod Build();

        void Clear();
    }
}
