using UnityEngine;

[System.Serializable]
public abstract class BaseAbility
{
    public BaseAbilityData Data;

    public virtual void Action(Unit _caster) // Send data package
    {
        if (EnergyTimeCheck(_caster))
        {
            _caster.ChangeEnergy(-Data.EPCost);
            _caster.ChangeTime(-Data.TPCost);

            Debug.Log($"{_caster.name} used ability {Data.Title}");
        }
    }

    protected virtual bool EnergyTimeCheck(Unit _caster)
    {
        if (_caster.UnitStats.Energy < Data.EPCost || _caster.UnitStats.Time < Data.TPCost)
        {
            return false;
        }
        return true;
    }
}

