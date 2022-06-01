using System;

namespace System
{
    static class RandomExtensions
    {
        public static T NewItem<T>(this Random rnd, params T[] items) => items[rnd.Next(items.Length)];
    }
}
