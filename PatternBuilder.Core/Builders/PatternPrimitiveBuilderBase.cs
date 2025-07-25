using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Builders
{
    public abstract class PatternPrimitiveBuilderBase<TBuilder, T>
    where TBuilder : PatternPrimitiveBuilderBase<TBuilder, T>
    where T : PatternPrimitiveBase, IPatternPrimitive
    {
        protected T _value = Empty;

        public static T Empty => PatternPrimitiveBase.CreateWithName<T>(T.DefaultName);

        public T Build()
        {
            return _value;
        }

        public void Clear()
        {
            _value = Empty;
        }

        public TBuilder SetName(string name)
        {
            _value.SetName(name);
            return (TBuilder)this;
        }
    }
}
