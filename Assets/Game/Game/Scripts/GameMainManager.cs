using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager Instance;

    public UIManager UIManager;
    public GridManager GridManager;
    public SelectionManager SelectionManager;
    public TurnManager TurnManager;
    public AbilityManager AbilityManager;
    public UnitManager UnitManager;
    public List<PlayerManager> Players = new List<PlayerManager>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
