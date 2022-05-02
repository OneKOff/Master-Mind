using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance;

    [SerializeField] private AspectData aspectIcons;
    [SerializeField] private Dictionary<AbilityType, Ability> abilityHolder;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public Ability GetAbility(AbilityType abName)
    {
        if (abilityHolder.TryGetValue(abName, out Ability ability))
        {
            return ability;
        }

        return null;
    }
}
