using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StarsProject.Misc
{
    [Serializable]
    public class SerializableDictionary<K,V>
    {
        [SerializeField] private K[] keys;
        [SerializeField] private V[] values;

        public Dictionary<K, V> Dictionary
        {
            get
            {
                if (dictionary == null)
                {
                    dictionary = new Dictionary<K, V>();

                    for (var i = 0; i < keys.Length; i++)
                    {
                        dictionary.Add(keys[i], values[i]);
                    }
                }

                return dictionary;
            }
        }

        private Dictionary<K, V> dictionary;
        
        public SerializableDictionary(Dictionary<K,V> dictionary)
        {
            keys = dictionary.Keys.ToArray();
            values = dictionary.Values.ToArray();
        }
    }
}