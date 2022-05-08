using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseAbility
{
    public BaseAbilityData Data;

    public List<PathNode> UsageArea = new List<PathNode>();
    public List<PathNode> EffectArea = new List<PathNode>();

    public virtual AbilityFailReason Action(Unit caster, int targetX, int targetY) // Send data package
    {
        var failReason = EnergyTimeCheck(caster);

        if (failReason != AbilityFailReason.None) { return failReason; }
        
        caster.ChangeEnergy(-Data.EPCost);
        caster.ChangeTime(-Data.TPCost);

        // Do stuff

        Debug.Log($"{caster.name} used ability {Data.Title}");

        return failReason;
    }

    public virtual List<PathNode> GetUsageArea(Unit caster)
    {


        return UsageArea;
    }

    public virtual List<PathNode> GetEffectArea(int targetX, int targetY)
    {
        // PathFinding

        return EffectArea;
    }

    protected virtual AbilityFailReason EnergyTimeCheck(Unit caster)
    {
        if (caster.UnitStats.Energy < Data.EPCost)
        {
            return AbilityFailReason.NotEnoughEnergy;
        }
        if (caster.UnitStats.Time < Data.TPCost)
        {
            return AbilityFailReason.NotEnoughTime;
        }
        return AbilityFailReason.None;
    }
}

