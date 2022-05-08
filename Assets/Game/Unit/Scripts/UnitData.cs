using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Entity/Unit Data")]
public class UnitData : ScriptableObject
{
    public int MaxHealth;
    public int HealthRegen;

    public int MaxEnergy;
    public int EnergyRegen;

    public int MaxTime;

    public int Power;
    public int Defence;

    public List<AspectDedication> UnitAspects;
    public List<AbilityType> InnerAbilities;

    public List<Card> StartingDeck = new List<Card>();
}
