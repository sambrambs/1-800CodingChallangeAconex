using System.Collections.Generic;

namespace CodingChallange1_800Application.Utils
{
    public static class Dictionaries
    {
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            return dictionary.GetValueOrDefault(key, default(V));
        }
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
        {
            V result;
            if (!dictionary.TryGetValue(key, out result))
            {
                return defaultValue;
            }
            return result;
        }
    }
}