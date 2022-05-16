using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldSpaceBarsUI : MonoBehaviour
{
    [SerializeField] private WorldSpaceUnitBarSet unitBarSetPrefab;
    [HideInInspector] public List<WorldSpaceUnitBarSet> UnitBarSets;

    public void CreateUnitBarSets()
    {
        foreach (var selectable in GameMainManager.Instance.EntityManager.Selectables)
        {
            if (selectable is Unit)
            {
                UnitBarSets.Add(Instantiate(unitBarSetPrefab, selectable.transform.position, Quaternion.identity, transform));
            }
        }
    }
}
