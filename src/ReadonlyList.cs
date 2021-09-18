using System;
using System.Collections;
using System.Collections.Generic;

public class ReadOnlyList<T> : ICloneable, IReadOnlyList<T>
{
    private readonly T[] _innerCollection;



    public int Count => _innerCollection.Length;

    public T this[int index] => _innerCollection[index];

    public ReadOnlyList(params T[] collection)
    {
        _innerCollection = new T[collection.Length];
        collection.CopyTo(_innerCollection, 0);
    }

    public ReadOnlyList(ICollection<T> collection)
    {
        _innerCollection = new T[collection.Count];
        int i = 0;
        foreach (var item in collection)
        {
            _innerCollection[i++] = item;
        }
    }



    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _innerCollection)
        {
            yield return item;
        }
    }

    public object Clone()
    {
        var collection = new T[_innerCollection.Length];
        if (typeof(T) is ICloneable)
        {
            for (int i = 0; i < _innerCollection.Length; i++)
            {
                collection[i] = (T)(((ICloneable)_innerCollection[i]).Clone());
            }
            return new ReadOnlyList<T>(collection);
        }
        _innerCollection.CopyTo(collection, 0);
        return new ReadOnlyList<T>(collection);
    }

    public T[] ToArray()
    {
        var result = new T[_innerCollection.Length];
        _innerCollection.CopyTo(result, 0);
        return result;
    }
}