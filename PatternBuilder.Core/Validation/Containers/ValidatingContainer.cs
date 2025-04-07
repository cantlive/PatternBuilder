namespace PatternBuilder.Core.Validation.Containers
{
    internal abstract class ValidatingContainer<TKey, TValue>
    {
        protected readonly Dictionary<TKey, TValue> _items;

        protected ValidatingContainer()
        {
            _items = new Dictionary<TKey, TValue>();
        }

        protected ValidatingContainer(ValidatingContainer<TKey, TValue> validatingContainer)
        {
            _items = new Dictionary<TKey, TValue>(validatingContainer._items);
        }

        public IEnumerable<TValue> Items => _items.Values;
        public int Count => _items.Count;

        protected abstract string GetValidatingParameterName();
        protected abstract TKey GetKey(TValue item);
        protected abstract void ValidateAdd(TValue item);
        protected abstract void ValidateRemove(TKey key);

        public void Add(TValue item)
        {
            ValidateAdd(item);
            _items.Add(GetKey(item), item);
        }

        public bool Remove(TKey key)
        {
            ValidateRemove(key);
            return _items.Remove(key);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool ContainsKey(TKey key) => _items.ContainsKey(key);
    }
}
