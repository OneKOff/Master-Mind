using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] protected AbilityData ab;

    public virtual void Action(Unit _caster) // Send data package
    {
        if (EnergyTimeCheck(_caster))
        {
            _caster.ChangeEnergy(-ab.EPCost);
            _caster.ChangeTime(-ab.TPCost);
            
            Debug.Log(_caster.name + " used ability " + name + ".");
        }
    }

    protected virtual bool EnergyTimeCheck(Unit _caster)
    {
        if (_caster.Energy < ab.EPCost || _caster.Time < ab.TPCost)
        {
            return false;
        }
        return true;
    }
}
