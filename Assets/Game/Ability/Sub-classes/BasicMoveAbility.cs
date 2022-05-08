using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveAbility : Ability
{
    public override AbilityFailReason Action(Unit caster, int targetX, int targetY)
    {
        var failReason = EnergyTimeCheck(caster);

        if (failReason != AbilityFailReason.None) { return failReason; }

        caster.ChangeEnergy(-Data.EPCost);
        caster.ChangeTime(-Data.TPCost);

        // Do stuff

        Debug.Log($"{caster.name} used ability {Data.Title}");

        return failReason;
    }

    public override List<PathNode> GetUsageArea(Unit caster)
    {
        return base.GetUsageArea(caster);
    }

    public override List<PathNode> GetEffectArea(int targetX, int targetY)
    {
        return base.GetEffectArea(targetX, targetY);
    }
}
