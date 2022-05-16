using UnityEngine;
using System.Collections.Generic;

public class Unit : Selectable
{
    [SerializeField] private UnitData unitData;
    public UnitData UnitData => unitData;
    public UnitStats UnitStats { get; private set; } = new UnitStats();

    protected override void Start()
    {
        base.Start();

        UnitStats.MaxHealth = unitData.MaxHealth;
        UnitStats.Health = unitData.MaxHealth;
        UnitStats.HealthRegen = unitData.HealthRegen;

        UnitStats.MaxEnergy = unitData.MaxEnergy;
        UnitStats.Energy = unitData.MaxEnergy;
        UnitStats.EnergyRegen = unitData.EnergyRegen;

        UnitStats.MaxTime = unitData.MaxTime;
        UnitStats.Time = unitData.MaxTime;

        UnitStats.Power = unitData.Power;
        UnitStats.Defence = unitData.Defence;

        UnitStats.UnitAspects = unitData.UnitAspects;
        UnitStats.InnerAbilities = unitData.InnerAbilities;

        UnitStats.CardDeckManager.DrawPile = unitData.StartingDeck;

        UnitStats.CardDeckManager.DrawCard(3);
    }

    public void SetTeamId(int teamId)
    {
        UnitStats.TeamId = teamId;
    }

    public void HandleEvent(UnitEvent unitEvent)
    {
        foreach (var effect in UnitStats.Effects)
        {
            var fullyNegated = effect.CheckEvent(unitEvent);

            if (fullyNegated)
            {
                return;
            }
        }

        switch (unitEvent.Type)
        {
            case UnitEventType.HealthChanged:
                ChangeHealth(unitEvent.EventValues[0]);
                break;
            case UnitEventType.EnergyChanged:
                ChangeEnergy(unitEvent.EventValues[0]);
                break;
            case UnitEventType.TimeChanged:
                ChangeTime(unitEvent.EventValues[0]);
                break;

            case UnitEventType.CardDrawn:
                UnitStats.CardDeckManager.DrawCard(unitEvent.EventValues[0]);
                break;
            case UnitEventType.CardDiscarded:
                UnitStats.CardDeckManager.DiscardCard(unitEvent.EventValues[0], unitEvent.EventValues[1] != 0);
                break;
            case UnitEventType.AbilityUsed:
                break;
            case UnitEventType.CardUsed:
                break;

            case UnitEventType.Moved:
                break;

            case UnitEventType.EffectReceived:
                break;
            case UnitEventType.EffectEnded:
                break;
        }
    }

    public virtual void ChangeHealth(int value)
    {
        UnitStats.Health = Mathf.Clamp(UnitStats.Health + value, 0, UnitStats.MaxHealth);

        if (UnitStats.Health <= 0)
        {
            Die();
        }
        if (value < 0)
        {
            Debug.Log($"{name} took {value} points of damage ({UnitStats.Health} / {UnitStats.MaxHealth})");
            // Damage Indication
        }
    }
    protected virtual void Die()
    {
        Debug.Log($"{name} has been defeated.");
        Destroy(gameObject);
    }
    public virtual bool ChangeEnergy(int _value)
    {
        if (UnitStats.Energy + _value < 0)
        {
            return false;
        }
        UnitStats.Energy = Mathf.Clamp(UnitStats.Energy + _value, 0, UnitStats.MaxEnergy);

        return true;
    }
    public virtual bool ChangeTime(int _value)
    {
        if (UnitStats.Time + _value < 0)
        {
            return false;
        }
        UnitStats.Time = Mathf.Clamp(UnitStats.Time + _value, 0, UnitStats.MaxTime);

        return true;
    }
}