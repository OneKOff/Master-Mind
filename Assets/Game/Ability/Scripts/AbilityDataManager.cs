using UnityEngine;
using System.Collections.Generic;

public class AbilityDataManager : MonoBehaviour
{
    [SerializeField] private AspectData aspectIcons;
    [SerializeField] private List<AbilityHolder> abilityHolders;

    public Ability GetAbility(AbilityType type)
    {
        foreach (var holder in abilityHolders)
        {
            if (holder.Matches(type))
            {
                return holder.Ability;
            }
        }

        return null;
    }
}
