using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public abstract class PatternBuilderBase<T> where T : IPatternPrimitive
    {
        protected T _value = Empty;

        public static T Empty => PatternPrimitiveBase.CreateWithName<T>(T.DefaultName);

        public void Clear()
        {
            _value = Empty;
        }

        public T Build()
        {
            return _value;
        }
    }
}
