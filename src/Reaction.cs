using System;
using System.Collections.Generic;

public class Reaction
{
    public static readonly Reaction NoReaction = new(new ReadOnlyList<Substance>(), null, 0);

    private readonly Substance _result;
    private readonly ReadOnlyList<Substance> _substances;
    public readonly float DelaySeconds;



    public Substance Result => _result.Clone() as Substance;

    // public ReadOnlyList<Substance> Substances =>

    public Reaction(ReadOnlyList<Substance> substances, Substance result, float delaySeconds = 0)
    {
        _result = result;
        _substances = substances;
        DelaySeconds = delaySeconds;
    }



    public bool IsReaction(Substance[] substances)
    {
        if (substances.Length != _substances.Count)
        {
            return false;
        }
        LinkedList<Substance> innerSubstances = new LinkedList<Substance>(_substances);
        foreach (var item in substances)
        {
            if (!(innerSubstances.Contains(item)))
            {
                return false;
            }
            innerSubstances.Remove(item);
        }
        return true;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static int GetHashCode(Substance[] substances)
    {
        throw new NotImplementedException();
    }
}