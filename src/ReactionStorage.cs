using System.Collections.Immutable;

public static class ReactionStorage
{
    public static ImmutableArray<Reaction> Reactions;



    static ReactionStorage()
    {
        
    }



    public static Reaction FindReaction(Substance[] substances)
    {
        int hash = Reaction.GetHashCode(substances);
        foreach (var item in Reactions)
        {
            if (hash == item.GetHashCode() && item.IsReaction(substances))
            {
                return item;
            }
        }
        return Reaction.NoReaction;
    }
}