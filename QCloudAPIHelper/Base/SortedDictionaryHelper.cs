using System.Collections.Generic;
using System.Linq;

namespace QCloudAPIHelper.Base
{
    public static class SortedDictionaryHelper
    {
        public static void AddRange<TKey, TValue>(this SortedDictionary<TKey, TValue> target, SortedDictionary<TKey, TValue> source)
        {
            if (target == null)
            {
                target = new SortedDictionary<TKey, TValue>();
            }
            if (source != null && source.Any())
            {
                foreach (var item in source)
                {
                    if (target.ContainsKey(item.Key))
                    {
                        target[item.Key] = item.Value;
                    }
                    else
                    {
                        target.Add(item.Key, item.Value);
                    }
                }
            }
        }
    }
}