using UnityEngine;
using System.Collections.Generic;

public abstract class BaseAbilityData : ScriptableObject
{
    public string Title;
    public Sprite Icon;
    public string Info;
    public int EPCost;
    public int TPCost;
    public int Range;
    public SearchType UsageSearchType;
    public int Area;
    public SearchType EffectSearchType;
    public List<AspectType> Aspects;
}
