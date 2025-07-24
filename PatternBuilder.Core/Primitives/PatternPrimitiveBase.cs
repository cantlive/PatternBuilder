using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;
using System.Reflection;

namespace PatternBuilder.Core.Primitives
{
    public abstract class PatternPrimitiveBase
    {
        public string Name { get; protected set; }

        public virtual string UniqueKey => Name;

        protected PatternPrimitiveBase(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public static T CreateWithName<T>(string name) where T : IPatternPrimitive
        {
            var ctor = typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new[] { typeof(string) },
                null);

            if (ctor == null)
                throw new InvalidOperationException($"{typeof(T).Name} must have a constructor with a single string parameter.");

            return (T)ctor.Invoke(new object[] { name });
        }
    }
}
