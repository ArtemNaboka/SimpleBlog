using System;
using System.Collections.Generic;

namespace Blog.Business.Infrastructure
{
    public static class Extensions
    {
        public static TKey GetKeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value)
        {
            if (dict == null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            foreach (var dictKey in dict.Keys)
            {
                if (dict[dictKey].Equals(value))
                {
                    return dictKey;
                }
            }

            throw new ArgumentException("Dictionary doesn't contain this value");
        }
    }
}