using System.Collections;
using System.Collections.Generic;

namespace Dewey.Dynamic
{
    /// <summary>
    /// A dictionary for dynamic objects
    /// </summary>
    public class DynamicInternalDictionary : IDictionary<string, object>
    {
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets a dictionary value by key
        /// </summary>
        /// <param name="key">The key of the dictionary item</param>
        /// <returns>The value of the get by key</returns>
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

        /// <summary>
        /// Whether the internal dictionary is readonly
        /// TODO: Implement ReadOnly DynamicInternalDictionary
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a value to the dictionary by key
        /// </summary>
        /// <param name="key">The key of the dictionary item</param>
        /// <param name="value">The value of the dictionary item</param>
        public void Add(string key, object value) => _dictionary.Add(key, value);

        /// <summary>
        /// Determines whether the dictionary contains a given key
        /// </summary>
        /// <param name="key">The key of the dictionary item</param>
        /// <returns>True if dictionary contains key, False otherwise</returns>
        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

        /// <summary>
        /// A list of the dictionary keys
        /// </summary>
        public ICollection<string> Keys => _dictionary.Keys;

        /// <summary>
        /// Remove a value from the dictionary by key
        /// </summary>
        /// <param name="key">The key of the dictionary item</param>
        /// <returns>True if successful, False otherwise</returns>
        public bool Remove(string key) => _dictionary.Remove(key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">The key of the dictionary item</param>
        /// <param name="value">The value of the dictionary item</param>
        /// <returns></returns>
        public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

        /// <summary>
        /// A list of the dictionary values
        /// </summary>
        public ICollection<object> Values => _dictionary.Values;

        /// <summary>
        /// Add a value to the dictionary by key/value pair
        /// </summary>
        /// <param name="item">The key/value pair of the dictionary item</param>
        public void Add(KeyValuePair<string, object> item) => ((IDictionary<string, object>)_dictionary).Add(item);

        /// <summary>
        /// Clear the dictionary of all values
        /// </summary>
        public void Clear() => _dictionary.Clear();

        /// <summary>
        /// Determine whether the dictionary contains a key/value pair
        /// </summary>
        /// <param name="item">The key/value pair of the dictionary item</param>
        /// <returns>True if the dictionary contains a key/value pair, False otherwise</returns>
        public bool Contains(KeyValuePair<string, object> item) => ((IDictionary<string, object>)_dictionary).Contains(item);

        /// <summary>
        /// Copy an array of key/value pairs to an index in the dictionary
        /// </summary>
        /// <param name="array">The array of key/value pairs</param>
        /// <param name="arrayIndex">The index to copy the key/pair array to.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => ((IDictionary<string, object>)_dictionary).CopyTo(array, arrayIndex);

        /// <summary>
        /// Count the number of items in the dictionary
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Remove a key/value pair from the dictionary
        /// </summary>
        /// <param name="item">The key/value pair of the dictionary item</param>
        /// <returns>True if successful, False otherwise</returns>
        public bool Remove(KeyValuePair<string, object> item) => Remove(item);

        /// <summary>
        /// Get the dictionary key/value pair enumerator
        /// </summary>
        /// <returns>The dictionary key/value pair enumerator</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => ((IDictionary<string, object>)_dictionary).GetEnumerator();

        /// <summary>
        /// Get the enumerator from the dictionary
        /// </summary>
        /// <returns>The dictionary enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();
    }
}
