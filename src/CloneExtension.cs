using System;
using System.Collections.Generic;

public static class CloneExtension
{
    public static List<T> Clone<T>(this List<T> list) where T : ICloneable
    {
        List<T> result = new(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            result[i] = (T)list[i].Clone();
        }
        return result;
    }
}