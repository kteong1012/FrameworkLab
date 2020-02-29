using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionExtension
{
    public static bool TrySafelyAdd<TKey,TValue> (this Dictionary<TKey, TValue> dict,TKey key,TValue value)
    {
        if (dict.ContainsKey(key))
        {
            return false;
        }
        dict.Add(key, value);
        return true;
    }
    public static bool TrySafelyRemove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        if (!dict.ContainsKey(key))
        {
            return false;
        }
        dict.Remove(key);
        return true;
    }
}
