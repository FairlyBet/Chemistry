using System;
using System.Collections.Generic;

public static class Flask
{
    private static readonly List<Substance> _currentContent;
    public static event Action<Substance> OnSubstanceAdding;
    public static event Action<Reaction> OnReactionOccur;



    public static List<Substance> CurrentContent => _currentContent.Clone<Substance>();

    static Flask()
    {
        _currentContent = new();
    }



    public static void AddSubstance(Substance substance)
    {
        _currentContent.Add(substance);
        OnSubstanceAdding?.Invoke(substance);
        var reaction = ReactionStorage.FindReaction(_currentContent.ToArray());
        if (reaction != Reaction.NoReaction)
        {
            OnReactionOccur?.Invoke(reaction);
            _currentContent.Clear();
            _currentContent.Add(reaction.Result);
        }
    }
}