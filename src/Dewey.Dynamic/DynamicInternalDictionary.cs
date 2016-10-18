using System.Collections;
using System.Collections.Generic;

namespace Dewey.Dynamic
{
    public class DynamicInternalDictionary : IDictionary<string, object>
    {
        protected Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                object val = null;

                _dictionary.TryGetValue(key, out val);

                return val;
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        public bool IsReadOnly => false;

        public void Add(string key, object value) => _dictionary.Add(key, value);

        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

        public ICollection<string> Keys => _dictionary.Keys;

        public bool Remove(string key) => _dictionary.Remove(key);

        public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

        public ICollection<object> Values => _dictionary.Values;

        public void Add(KeyValuePair<string, object> item) => ((IDictionary<string, object>)_dictionary).Add(item);

        public void Clear() => _dictionary.Clear();

        public bool Contains(KeyValuePair<string, object> item) => ((IDictionary<string, object>)_dictionary).Contains(item);

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => ((IDictionary<string, object>)_dictionary).CopyTo(array, arrayIndex);

        public int Count => _dictionary.Count;

        public bool Remove(KeyValuePair<string, object> item) => Remove(item);

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => ((IDictionary<string, object>)_dictionary).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();
    }
}
