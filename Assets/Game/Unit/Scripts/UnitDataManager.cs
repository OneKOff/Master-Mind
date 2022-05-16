using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitDataManager : MonoBehaviour
{
    public List<UnitData> Units;

    public Unit SpawnUnit(UnitData data, int x, int y, int teamId)
    {
        var unit = Instantiate(data.UnitPrefab, GameMainManager.Instance.GridManager.NodesGrid[x, y].transform, transform);

        return unit;
    }
}
