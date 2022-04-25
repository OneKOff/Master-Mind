using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "AbilityData")]
public class AbilityData : ScriptableObject
{
    public Sprite icon;
    public int EPCost, TPCost;
    public int Range, Area;
    public List<int> Values;
}
