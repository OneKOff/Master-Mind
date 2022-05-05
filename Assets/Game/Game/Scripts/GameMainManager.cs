using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager Instance;

    public UIManager UIManager;
    public GridManager GridManager;
    public TurnManager TurnManager;
    public AbilityManager AbilityManager;
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
