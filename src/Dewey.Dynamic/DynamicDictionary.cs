using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Dewey.Dynamic
{
    public class DynamicDictionary : DynamicObject, IEnumerable
    {
        protected DynamicInternalDictionary dictionary = new DynamicInternalDictionary();

        public DynamicInternalDictionary GetDictionary() => dictionary;

        public void Add(string key, object value) => dictionary.Add(key, value);

        public override IEnumerable<string> GetDynamicMemberNames() => dictionary.Keys;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = dictionary[binder.Name];

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;

            return true;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => ((IDictionary<string, object>)dictionary).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();
    }
}
