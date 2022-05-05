using UnityEngine;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
    public Selectable[] GridSelectables;

    private void Start()
    {
        GridSelectables = FindObjectsOfType<Selectable>();
    }
}
