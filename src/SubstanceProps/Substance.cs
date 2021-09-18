using System;

public class Substance : ICloneable, IEquatable<Substance>
{
    public const float NormalTemperature = 20;

    private float _currentTemperature;
    public readonly ReadOnlyList<Element> Elements;



    public float CurrentTemperature => _currentTemperature;

    public Substance(params Element[] elements)
    {
        Elements = new(elements);
    }

    public Substance(float temperature, params Element[] elements) : this(elements)
    {
        _currentTemperature = temperature;
    }



    public object Clone()
    {
        return new Substance(_currentTemperature, Elements.ToArray());
    }

    public bool Equals(Substance other)
    {
        if (_currentTemperature != other._currentTemperature)
        {
            return false;
        }
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i] != other.Elements[i])
            {
                return false;
            }
        }
        return true;
    }

    public void AffectTemperature(float delta)
    {
        _currentTemperature += delta;
    }

    public string GetHashCodeString()
    {
        string result = string.Empty;
        foreach (var item in Elements)
        {
            result += item;
        }
        return result;
    }
}