using System.Collections.Generic;

public class Effect
{
    public List<int> EffectValues;
    public int Duration;
    public int Priority;

    public virtual bool CheckEvent(UnitEvent unitEvent) // If false, event is negated
    {
        return false;
    }

    public virtual bool NegateEffect() // If true, destroy this effect
    {
        return false;
    }
}