using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStats
{
    public int MaxHealth;
    public int HealthRegen;
    public int Health;

    public int MaxEnergy;
    public int EnergyRegen;
    public int Energy;

    public int MaxTime;
    public int Time;

    public int Power;
    public int Defence;

    public List<AspectDedication> UnitAspects;
    public List<AbilityType> InnerAbilities;
}