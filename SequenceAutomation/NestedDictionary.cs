using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    /*
     * References: https://stackoverflow.com/questions/12543094/nested-dictionary-collection-in-net
     */
    public class NestedDictionary<K, V> : Dictionary<K, NestedDictionary<K, V>>
    {
        public V Value { set; get; }

        public new NestedDictionary<K, V> this[K key]
        {
            set { base[key] = value; }

            get
            {
                if (!Keys.Contains(key))
                {
                    base[key] = new NestedDictionary<K, V>();
                }
                return base[key];
            }
        }
    }
}
