using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Interfaces.Builders
{
    public interface IPatternInterfaceBuilder
    {
        IPatternInterfaceBuilder SetName(string name);

        IPatternInterfaceBuilder AddProperty(string parameterType, string parameterName);

        IPatternInterfaceBuilder AddMethod(IPatternMethod method);

        IPatternInterfaceBuilder RemoveProperty(string name);

        IPatternInterfaceBuilder RemoveMethod(string name);

        IPatternInterface Build();

        void Clear();
    }
}
