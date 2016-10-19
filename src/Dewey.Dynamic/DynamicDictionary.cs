using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Dewey.Dynamic
{
    /// <summary>
    /// A dynamic key/value dictionary for converting an object to a dynamic and back
    /// </summary>
    public class DynamicDictionary : DynamicObject, IEnumerable
    {
        private DynamicInternalDictionary dictionary = new DynamicInternalDictionary();

        /// <summary>
        /// Get the Dynamic Internal Dictionary
        /// </summary>
        /// <returns>The Dynamic InternalDictionary</returns>
        public DynamicInternalDictionary GetDictionary() => dictionary;

        /// <summary>
        /// Add a key/value pair
        /// </summary>
        /// <param name="key">The key to add</param>
        /// <param name="value">The value to add</param>
        public void Add(string key, object value) => dictionary.Add(key, value);

        /// <summary>
        /// Get the member names in the dictionary
        /// </summary>
        /// <returns>List of the member names</returns>
        public override IEnumerable<string> GetDynamicMemberNames() => dictionary.Keys;

        /// <summary>
        /// Try to get a member value by name
        /// </summary>
        /// <param name="binder">The member binder to get</param>
        /// <param name="result">The resulting value</param>
        /// <returns>True if member found, False otherwise</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = dictionary[binder.Name];

            return true;
        }

        /// <summary>
        /// Try to set a member value by name
        /// </summary>
        /// <param name="binder">The member binder to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>True if success, False otherwise</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;

            return true;
        }

        /// <summary>
        /// Get the dictionary enumerator
        /// </summary>
        /// <returns>The dictionary enumerator</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => ((IDictionary<string, object>)dictionary).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();
    }
}
