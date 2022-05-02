using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitData : DamageableData
{
    public int MaxEnergy;
    public int MaxTime;

    public List<AspectType> UnitAspects;
    public List<Ability> InnerAbilities;
}
