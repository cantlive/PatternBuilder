using PatternBuilder.Core.Interfaces.Primitives;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("PatternBuilder.Tests")]

namespace PatternBuilder.Core.Validation
{
    internal sealed class ValidatingPatternPrimitiveContainer<T> where T : IPatternPrimitive
    {
        private readonly Dictionary<string, T> _items;
        private readonly string _containerName;
        private readonly string _parameterName;

        internal ValidatingPatternPrimitiveContainer(string containerName, string parameterName = "")
        {
            _items = new Dictionary<string, T>();
            _containerName = containerName;
            _parameterName = parameterName;
        }

        private string ParameterName => string.IsNullOrWhiteSpace(_parameterName) ? T.SystemName : _parameterName;
        public IEnumerable<T> Items => _items.Values;
        public int Count => _items.Count;

        public void Add(T primitive)
        {
            ValidatePrimitiveNullOrKeyWhiteSpace(primitive);
            ValidatePrimitiveUnique(primitive);

            _items.Add(primitive.UniqueKey, primitive);
        }

        public bool Remove(T primitive)
        {
            ValidatePrimitiveNullOrKeyWhiteSpace(primitive);

            return _items.Remove(primitive.UniqueKey);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool ContainsKey(string key) => _items.ContainsKey(key);

        private void ValidatePrimitiveNullOrKeyWhiteSpace(T primitive)
        {
            string parameterName = string.IsNullOrWhiteSpace(_parameterName) ? T.SystemName : _parameterName;
            PatternValidator.ThrowIfNullArgument(primitive, ParameterName);
            PatternValidator.ThrowIfNullOrWhiteSpace(primitive.UniqueKey, $"{ParameterName} key");
        }

        private void ValidatePrimitiveUnique(T primitive)
        {
            PatternValidator.ValidateUniquePatternPrimitive(_items, primitive, _containerName, ParameterName);
        }
    }
}
